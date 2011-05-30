using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InVision.Extensions;
using InVision.Native;

namespace ReverseGenerator.CSharp
{
	public class CSharpCppClassImplGenerator : CSharpGeneratorBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CSharpCppClassImplGenerator"/> class.
		/// </summary>
		/// <param name="configOptions">The config options.</param>
		public CSharpCppClassImplGenerator(ConfigOptions configOptions)
			: base(configOptions)
		{
		}

		/// <summary>
		/// Generates the content.
		/// </summary>
		/// <param name="types">The types.</param>
		protected override void GenerateContent(IEnumerable<Type> types)
		{
			IEnumerable<Type> wrapperTypes = Options.GetWrapperTypes(types);

			var defaultNamespaces = new[] {
				typeof (Handle).Namespace
			};

			IEnumerable<string> namespacesUsed = types.ScanNamespacesInMethodsOf();
			namespacesUsed = namespacesUsed.Union(types.ScanNamespacesInProperties());
			namespacesUsed = namespacesUsed.Union(defaultNamespaces);
			namespacesUsed = namespacesUsed.OrderBy(ns => ns, new NamespaceComparer());

			foreach (string namespaceUsed in namespacesUsed) {
				Writer.WriteLine("using {0};", namespaceUsed);
			}

			Writer.WriteLine();

			IEnumerable<IGrouping<string, Type>> groupedTypes = wrapperTypes.GroupBy(t => t.Namespace);

			foreach (var typeGroup in groupedTypes) {
				Writer.WriteLine("namespace {0}", typeGroup.Key);
				Writer.OpenBlock();
				{
					foreach (Type wrapperType in typeGroup) {
						WriteWrapperType(wrapperType);
						Writer.WriteLine();
					}
				}
				Writer.CloseBlock();
			}
		}


		/// <summary>
		/// Writes the type of the wrapper.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		private void WriteWrapperType(Type wrapperType)
		{
			string typeName = ConfigOptions.GetCSharpCppInstanceTypename(wrapperType);
			Type baseType = CppClassAttribute.GetBaseType(wrapperType);
			IEnumerable<Type> interfaces = CppClassAttribute.GetInterfaces(wrapperType, true);

			bool hasBaseType = baseType != null;
			bool hasInterfaces = interfaces.Count() > 0;

			Writer.WriteLine("[CppImplementation(typeof({0}))]", wrapperType.Name);
			Writer.WriteLine("internal unsafe class {0}", typeName);

			WriteInheritance(baseType, interfaces, hasBaseType, hasInterfaces);

			Writer.OpenBlock();
			{
				//WriteFields(wrapperType);
				WriteConstructors(wrapperType);
				WriteDestructor(wrapperType);
				//WriteProperties(wrapperType);
				WriteMethods(wrapperType);
			}
			Writer.CloseBlock();
		}

		/// <summary>
		/// Writes the constructors.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		private void WriteConstructors(Type wrapperType)
		{
			IEnumerable<MethodInfo> constructors = Options.GetConstructors(wrapperType);

			foreach (MethodInfo constructor in constructors) {
				ParameterInfo[] parameters = constructor.GetParameters();

				string parametersDef =
					(from p in parameters
					 let paramModification = ConfigOptions.GetCSharpParameterModifier(p)
					 select string.Format(
						"{0}{1} {2}",
						string.IsNullOrEmpty(paramModification)
							? string.Empty
							: string.Format("{0} ", paramModification),
						ConfigOptions.GetCSharpTypeString(p.ParameterType),
						p.Name)).Join(", ");

				string parametersList = GetParametersList(parameters);

				Writer.WriteLine("{0} {0}.{1}({2})",
								 wrapperType.Name,
								 constructor.Name,
								 parametersDef);

				Writer.OpenBlock();
				{
					Writer.WriteLine("Self = {0}.{1}({2});",
									 ConfigOptions.GetCSharpNativeTypename(wrapperType),
									 constructor.Name,
									 parametersList);
					Writer.WriteLine("return this;");
				}
				Writer.CloseBlock();
				Writer.WriteLine();
			}
		}

		/// <summary>
		/// Writes the destructor.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		private void WriteDestructor(Type wrapperType)
		{
			bool hasDestructor = Options.HasDestructor(wrapperType);
			bool hasBaseType = Options.HasBaseType(wrapperType);

			if (!hasDestructor && !hasBaseType)
				return;

			if (hasBaseType)
				return;

			MethodInfo destructor = Options.GetDestructor(wrapperType);

			Writer.WriteLine("{0} {1}.{2}()",
							 ConfigOptions.GetCSharpTypeString(destructor.ReturnType),
							 wrapperType.Name,
							 destructor.Name);

			Writer.OpenBlock();
			{
				Writer.WriteLine("{0}.{1}(Self);",
								 ConfigOptions.GetCSharpNativeTypename(wrapperType),
								 destructor.Name);
				Writer.WriteLine("Self = default(Handle);");
			}
			Writer.CloseBlock();
			Writer.WriteLine();
		}



		/// <summary>
		/// Writes the methods.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		private void WriteMethods(Type wrapperType)
		{
			IEnumerable<MethodInfo> methods = Options.GetMethods(wrapperType);

			foreach (MethodInfo method in methods) {
				var methodAttr = method.GetAttribute<MethodAttribute>(true);
				ParameterInfo[] parameters = method.GetParameters();

				string parametersDef =
					(from p in parameters
					 let paramModification = ConfigOptions.GetCSharpParameterModifier(p)
					 select string.Format(
						"{0}{1} {2}",
						string.IsNullOrEmpty(paramModification) ? paramModification : paramModification + " ",
						ConfigOptions.GetCSharpTypeString(p.ParameterType),
						p.Name)).Join(", ");

				string parametersList = GetParametersList(parameters);
				bool isProcedure = method.ReturnType == typeof(void);

				Writer.WriteLine("{0} {1}.{2}({3})",
								 ConfigOptions.GetCSharpTypeString(method.ReturnType),
								 GetTypename(method.DeclaringType),
								 method.Name,
								 parametersDef);

				Writer.OpenBlock();
				{
					if (!methodAttr.Static) {
						Writer.WriteLine("CheckMemberOnlyCall();");
						Writer.WriteLine();

						parametersList = string.Format("Self{0}{1}",
													   parameters.Length > 0 ? ", " : string.Empty,
													   parametersList);
					} else {
						Writer.WriteLine("CheckStaticOnlyCall();");
						Writer.WriteLine();
					}

					Writer.WriteLine("{0}{1}.{2}({3});",
									 isProcedure ? string.Empty : "var result = ",
									 ConfigOptions.GetCSharpNativeTypename(wrapperType),
									 method.Name,
									 parametersList);

					if (!isProcedure) {
						Writer.WriteLine();

						if (method.ReturnType.HasICppInterface())
							Writer.WriteLine("return HandleConvert.FromHandle<{0}>(result);", method.ReturnType.Name);
						else
							Writer.WriteLine("return result;");
					}
				}
				Writer.CloseBlock();
				Writer.WriteLine();
			}
		}

		/// <summary>
		/// Gets the parameters list.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <returns></returns>
		private static string GetParametersList(IEnumerable<ParameterInfo> parameters)
		{
			return (from p in parameters
					let paramModification = ConfigOptions.GetCSharpParameterModifier(p)
					let paramName =
						p.ParameterType.HasICppInterface() ? string.Format("HandleConvert.ToHandle({0})", p.Name) : p.Name
					select
						string.Format("{0}{1}", string.IsNullOrEmpty(paramModification) ? string.Empty : paramModification + " ",
									  paramName)).
				Join(", ");
		}

		/// <summary>
		/// Writes the inheritance.
		/// </summary>
		/// <param name="baseType">Type of the base.</param>
		/// <param name="interfaces">The interfaces.</param>
		/// <param name="hasBaseType">if set to <c>true</c> [has base type].</param>
		/// <param name="hasInterfaces">if set to <c>true</c> [has interfaces].</param>
		private void WriteInheritance(Type baseType, IEnumerable<Type> interfaces, bool hasBaseType, bool hasInterfaces)
		{
			Writer.Indent();

			if (hasBaseType) {
				Writer.BeginLine();
				Writer.Write(": {0}", ConfigOptions.GetCSharpCppInstanceTypename(baseType));
			} else {
				Writer.BeginLine();
				Writer.Write(": CppInstance");
			}

			if (hasInterfaces) {
				Writer.Write(", ");

				bool first = true;

				foreach (Type @interface in interfaces) {
					if (first)
						first = false;
					else
						Writer.Write(", ");

					string interfaceName = @interface.Name;

					if (@interface.IsGenericType)
						interfaceName = GetGenericTypename(@interface);

					Writer.Write(interfaceName);
				}
			}

			Writer.Write(Writer.NewLine);
			Writer.Deindent();
		}

		/// <summary>
		/// Gets the typename.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		private string GetTypename(Type type)
		{
			if (type.IsGenericType)
				return GetGenericTypename(type);

			return type.Name;
		}

		/// <summary>
		/// Gets the generic typename.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		private string GetGenericTypename(Type type)
		{
			var typename = new StringBuilder(type.Name.Substring(0, type.Name.IndexOf('`')));

			typename.Append("<");
			typename.Append(type.GetGenericArguments().Select(t => t.Name).Join(", "));
			typename.Append(">");

			return typename.ToString();
		}
	}
}
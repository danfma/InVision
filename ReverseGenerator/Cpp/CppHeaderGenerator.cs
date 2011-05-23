using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native;

namespace ReverseGenerator.Cpp
{
	public class CppHeaderGenerator : IGenerator
	{
		internal const BindingFlags MethodFlags =
			BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

		private string _defineFilename;
		private string _filename;
		private SourceWriter _writer;

		/// <summary>
		/// Gets the name of the project.
		/// </summary>
		/// <value>The name of the project.</value>
		protected string ProjectName
		{
			get { return ConfigOptions.ProjectName; }
		}

		/// <summary>
		/// Gets or sets the options.
		/// </summary>
		/// <value>The options.</value>
		protected ConfigOptions ConfigOptions { get; set; }

		#region IGenerator Members

		/// <summary>
		/// Generates the specified options.
		/// </summary>
		/// <param name="configOptions">The options.</param>
		/// <param name="types">The types.</param>
		public void Generate(ConfigOptions configOptions, IEnumerable<Type> types)
		{
			ConfigOptions = configOptions;

			_filename = (ProjectName + ".h").ToLower();
			_defineFilename = _filename.Replace('.', '_').ToUpper();

			using (_writer = new SourceWriter(Path.Combine(Path.GetFullPath(ConfigOptions.CppOutputDir), _filename)))
			{
				IEnumerable<Type> functionTypes = types.Where(t => t.HasAttribute<CppFunctionAttribute>());

				IEnumerable<Type> wrapperTypes = types.Where(t => t.HasAttribute<CppInterfaceAttribute>(true));

				IEnumerable<Type> enumerations = types.Where(t => t.IsEnum);

				IEnumerable<Type> valueObjects =
					types.Where(t => t.HasAttribute<CppValueObjectAttribute>() && t.IsValueType && !t.IsEnum);

				IEnumerable<Type> functionProviders =
					types.Where(
						t =>
						t.HasAttribute<CppTypeAttribute>() && !t.HasAttribute<CppInterfaceAttribute>(true) &&
						t.IsInterface);

				IEnumerable<Type> converters = types.Where(t => t.HasAttribute<HandleConverterAttribute>());

				WriteHeader();

				_writer.WriteLine("extern \"C\"");
				_writer.WriteLine("{");
				_writer.Indent();

				WriteEnumerations(enumerations);

				WritePrototypes(valueObjects);
				//WriteWrapperDescriptorPrototypes(wrapperTypes);
				WriteFunctionHandlers(functionTypes);

				WriteTypeDefinitions(valueObjects);
				//WriteWrapperDescriptorDefinitions(wrapperTypes);

				_writer.WriteLine();

				WriteFunctionProviders(functionProviders);
				WriteWrappersMethods(wrapperTypes);

				_writer.Deindent();
				_writer.WriteLine("}");
				_writer.WriteLine();

				WriteInlineConverters(converters.Union(wrapperTypes).Distinct());
				WriteFooter();

				_writer.Close();
			}
		}

		#endregion

		/// <summary>
		/// Writes the function handlers.
		/// </summary>
		/// <param name="functionTypes">The function types.</param>
		private void WriteFunctionHandlers(IEnumerable<Type> functionTypes)
		{
			functionTypes = functionTypes.Where(t => !t.IsGenericType);

			foreach (Type functionType in functionTypes)
			{
				MethodInfo invoke = functionType.GetMethod("Invoke");

				string returnTypename = ConfigOptions.ToCppTypename(functionType, invoke.ReturnType);
				string name = functionType.Name;
				string parameters = ConfigOptions.TranslateToCppParameters(invoke.GetParameters());

				_writer.WriteLine("typedef {0} (INV_CALL *{1})({2});",
								  returnTypename,
								  name,
								  parameters);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Gets the name of the external method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="method">The method.</param>
		/// <returns></returns>
		public static string GetExternalMethodName(Type type, MethodInfo method)
		{
			string functionName;
			string targetType = ConfigOptions.GetCppTypename(type);

			if (method.HasAttribute<ConstructorAttribute>())
			{
				functionName = "new" + targetType.ToLower().ToPascalCase();

				//ParameterInfo[] ctrParameters = method.GetParameters();
				//functionName = AddBySuffix(ctrParameters, functionName);
			}
			else if (method.HasAttribute<DestructorAttribute>())
			{
				functionName = "delete" + targetType.ToLower().ToPascalCase();
			}
			else
			{
				functionName = targetType.ToLower().ToPascalCase() + method.Name;

				if (IsOverloaded(method))
					functionName += GetNumberFromSequence(method);
			}

			if (IsOverloaded(method))
				functionName += "_m" + GetNumberFromSequence(method);

			return functionName.ToCStyle();
		}

		#region Converters

		/// <summary>
		/// Writes the inline converters.
		/// </summary>
		/// <param name="converters">The converters.</param>
		private void WriteInlineConverters(IEnumerable<Type> converters)
		{
			_writer.WriteLine();
			_writer.WriteLine("#ifdef __cplusplus");

			converters = converters.Where(t => !t.IsGenericTypeDefinition);

			var definitions =
				(from type in converters
				 let attribute = type.GetAttribute<CppTypeAttribute>(true)
				 select new {
					 attribute.DefinitionFile,
					 attribute.LocalDefinition
				 }).Distinct();

			foreach (var definition in definitions)
			{
				if (string.IsNullOrEmpty(definition.DefinitionFile))
					continue;

				if (definition.LocalDefinition)
					_writer.WriteLine("#include \"{0}\"", definition.DefinitionFile);
				else
					_writer.WriteLine("#include <{0}>", definition.DefinitionFile);
			}

			_writer.WriteLine();
			_writer.WriteLine("using namespace invision;");
			_writer.WriteLine();

			foreach (Type converter in converters)
			{
				WriteInlineConverter(converter);
			}

			_writer.WriteLine("#endif // __cplusplus");
		}

		/// <summary>
		/// Writes the inline converter.
		/// </summary>
		/// <param name="type">The converter.</param>
		private void WriteInlineConverter(Type type)
		{
			var attribute = type.GetAttribute<CppTypeAttribute>(true);

			_writer.WriteLine("inline {0}* as{1}(InvHandle self) {{",
							  attribute.GetCppFullName(type.Name),
							  attribute.Typename);

			_writer.Indent();
			_writer.WriteLine("return castHandle< {0} >(self);", attribute.GetCppFullName(type.Name));
			_writer.Deindent();
			_writer.WriteLine("}");
			_writer.WriteLine();
		}

		#endregion

		#region Enumerations

		/// <summary>
		/// Writes the enumerations.
		/// </summary>
		/// <param name="enumerations">The enumerations.</param>
		private void WriteEnumerations(IEnumerable<Type> enumerations)
		{
			foreach (Type enumeration in enumerations)
			{
				WriteEnumeration(enumeration);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the enumeration.
		/// </summary>
		/// <param name="enumeration">The enumeration.</param>
		private void WriteEnumeration(Type enumeration)
		{
			string enumTypeName = ConfigOptions.GetCppEnumName(enumeration);

			_writer.WriteLine("/*");
			_writer.WriteLine(" * Enumeration {0}", enumTypeName);
			_writer.WriteLine(" */");
			_writer.WriteLine("#define {0} _int", enumTypeName);

			var enumEntries =
				from enumName in Enum.GetNames(enumeration)
				select new { Name = enumName, Value = Convert.ToInt32(Enum.Parse(enumeration, enumName)) };

			foreach (var entry in enumEntries)
			{
				_writer.WriteLine(
					"#define {0} 0x{1}",
					(enumTypeName + "_" + entry.Name).ToCStyle().ToUpper(),
					entry.Value.ToString("X"));
			}

			_writer.WriteLine();
		}

		#endregion

		#region File Header / Footer

		/// <summary>
		/// Initializes the specified project name.
		/// </summary>
		private void WriteHeader()
		{
			_writer.WriteLine("#ifndef __{0}__", _defineFilename);
			_writer.WriteLine("#define __{0}__", _defineFilename);
			_writer.WriteLine();
			_writer.WriteLine("#include <InvisionHandle.h>");
			_writer.WriteLine();
		}

		/// <summary>
		/// Terminates this instance.
		/// </summary>
		public void WriteFooter()
		{
			_writer.WriteLine("#endif // __{0}__", _defineFilename);
		}

		#endregion

		#region Prototypes

		/// <summary>
		/// Writes the prototypes.
		/// </summary>
		/// <param name="types">The types.</param>
		private void WritePrototypes(IEnumerable<Type> types)
		{
			_writer.WriteLine("/*");
			_writer.WriteLine(" * Prototypes");
			_writer.WriteLine(" */");
			_writer.WriteLine();

			foreach (Type type in types)
			{
				WritePrototype(type);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the prototype.
		/// </summary>
		/// <param name="type">The type.</param>
		private void WritePrototype(Type type)
		{
			string cppTypename = ConfigOptions.GetCppTypename(type);

			_writer.WriteLine("struct {0};", cppTypename);
		}

		/// <summary>
		/// Writes the wrapper descriptor prototypes.
		/// </summary>
		/// <param name="wrapperTypes">The wrapper types.</param>
		private void WriteWrapperDescriptorPrototypes(IEnumerable<Type> wrapperTypes)
		{
			_writer.WriteLine("/*");
			_writer.WriteLine(" * Wrapper Descriptors");
			_writer.WriteLine(" */");
			_writer.WriteLine();

			foreach (Type type in wrapperTypes)
			{
				WriteWrapperDescriptorPrototype(type);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the wrapper descriptor prototype.
		/// </summary>
		/// <param name="type">The type.</param>
		private void WriteWrapperDescriptorPrototype(Type type)
		{
			string cppTypename = ConfigOptions.GetCppWrapperDescriptorTypename(type);

			_writer.WriteLine("struct {0};", cppTypename);
		}

		#endregion // prototypes

		#region Types definitions

		/// <summary>
		/// Writes the type definitions.
		/// </summary>
		/// <param name="types">The types.</param>
		private void WriteTypeDefinitions(IEnumerable<Type> types)
		{
			foreach (Type type in types)
			{
				var generator = new CppValueObjectGenerator(ConfigOptions, type);
				string filename = generator.Generate();

				_writer.WriteLine("#include \"{0}\"", filename);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the type definitions.
		/// </summary>
		/// <param name="types">The types.</param>
		private void WriteWrapperDescriptorDefinitions(IEnumerable<Type> types)
		{
			foreach (Type type in types)
			{
				var generator = new CppWraperDescriptorGenerator(ConfigOptions, type);
				string fileGenerated = generator.Generate();

				_writer.WriteLine("#include \"{0}\"", fileGenerated);
			}
		}

		#endregion

		#region Function generators

		/// <summary>
		/// Writes the function providers.
		/// </summary>
		/// <param name="functionProviders">The function providers.</param>
		private void WriteFunctionProviders(IEnumerable<Type> functionProviders)
		{
			foreach (Type functionProvider in functionProviders)
			{
				WriteFunctionProvider(functionProvider);
			}
		}

		/// <summary>
		/// Writes the function provider.
		/// </summary>
		/// <param name="functionProvider">The function provider.</param>
		private void WriteFunctionProvider(Type functionProvider)
		{
			WriteTypedFunctionProvider(functionProvider);
		}

		/// <summary>
		/// Writes the typed function provider.
		/// </summary>
		/// <param name="functionProvider">The function provider.</param>
		private void WriteTypedFunctionProvider(Type functionProvider)
		{
			if (!functionProvider.HasAttribute<CppTypeAttribute>())
				throw new NotSupportedException();

			var attribute = functionProvider.GetAttribute<CppTypeAttribute>(false);
			string targetType = attribute.Typename;
			MethodInfo[] methods = functionProvider.GetMethods(MethodFlags);

			_writer.WriteLine();
			_writer.WriteLine("/*");
			_writer.WriteLine(" * Function group: {0}", targetType);
			_writer.WriteLine(" */");
			_writer.WriteLine();

			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.IsPropertyMember())
					continue;

				WriteFunction(targetType, methodInfo);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the type method to function.
		/// </summary>
		/// <param name="targetType">Type of the target.</param>
		/// <param name="methodInfo">The method info.</param>
		private void WriteFunction(string targetType, MethodInfo methodInfo)
		{
			string functionName;
			string targetMethod;

			if (methodInfo.HasAttribute<ConstructorAttribute>())
			{
				functionName = "new" + targetType.ToLower().ToPascalCase();
				targetMethod = targetType;

				ParameterInfo[] ctrParameters = methodInfo.GetParameters();
				functionName = AddBySuffix(ctrParameters, functionName);
			}
			else if (methodInfo.HasAttribute<DestructorAttribute>())
			{
				functionName = "delete" + targetType.ToLower().ToPascalCase();
				targetMethod = "~" + targetType;
			}
			else
			{
				functionName = targetType.ToLower().ToPascalCase() + methodInfo.Name;
				targetMethod = methodInfo.Name.ToCamelCase();

				if (IsOverloaded(methodInfo))
					functionName += GetNumberFromSequence(methodInfo);
			}

			string parameters;

			if (methodInfo.HasAttribute<DestructorAttribute>())
			{
				parameters = "InvHandle self";
			}
			else if (methodInfo.HasAttribute<MethodAttribute>())
			{
				var attr = methodInfo.GetAttribute<MethodAttribute>(true);

				parameters = GetParametersString(methodInfo);

				if (!attr.Static)
					parameters = "InvHandle self" +
								 (!string.IsNullOrEmpty(parameters) ? (", " + parameters) : parameters);
			}
			else
			{
				parameters = GetParametersString(methodInfo);
			}

			_writer.WriteLine("/**");
			_writer.WriteLine(" * Method: {0}::{1}", targetType, targetMethod);
			_writer.WriteLine(" */");
			_writer.WriteLine("INV_EXPORT {0}",
							  ConfigOptions.ToCppTypename(methodInfo.ReturnParameter, methodInfo.ReturnType));
			_writer.WriteLine("INV_CALL {0}({1});", functionName.ToCStyle(), parameters);
			_writer.WriteLine();
		}

		/// <summary>
		/// Gets the number from sequence.
		/// </summary>
		/// <param name="methodInfo">The method info.</param>
		/// <returns></returns>
		internal static int GetNumberFromSequence(MethodInfo methodInfo)
		{
			Type declaringType = methodInfo.DeclaringType;
			IEnumerable<MethodInfo> methods = declaringType.
				GetMethods(MethodFlags).
				Where(m => m.Name == methodInfo.Name);

			int i = 0;

			foreach (MethodInfo method in methods)
			{
				i++;

				if (ReferenceEquals(method, methodInfo))
					return i;
			}

			return 0;
		}

		/// <summary>
		/// Determines whether the specified method info is overloaded.
		/// </summary>
		/// <param name="methodInfo">The method info.</param>
		/// <returns>
		/// 	<c>true</c> if the specified method info is overloaded; otherwise, <c>false</c>.
		/// </returns>
		internal static bool IsOverloaded(MethodInfo methodInfo)
		{
			Type declaringType = methodInfo.DeclaringType;

			return declaringType.GetMethods(MethodFlags).
					   Where(m => m.Name == methodInfo.Name).
					   Count() > 1;
		}

		/// <summary>
		/// Adds the by suffix.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <param name="functionName">Name of the function.</param>
		/// <returns></returns>
		internal static string AddBySuffix(ParameterInfo[] parameters, string functionName)
		{
			int paramStart = 0;

			if (parameters.Count() > 0 && parameters.First().Name == "self")
				paramStart = 1;

			for (int paramIndex = paramStart; paramIndex < parameters.Length; paramIndex++)
			{
				ParameterInfo parameterInfo = parameters[paramIndex];

				if (paramIndex == paramStart)
					functionName += "By_";
				else
					functionName += "_";

				functionName += parameterInfo.Name.ToLower().ToPascalCase();
			}

			return functionName;
		}

		/// <summary>
		/// Gets the parameters string.
		/// </summary>
		/// <param name="methodInfo">The method info.</param>
		/// <returns></returns>
		internal static string GetParametersString(MethodInfo methodInfo)
		{
			string parameters = string.Empty;

			for (int paramIndex = 0; paramIndex < methodInfo.GetParameters().Length; paramIndex++)
			{
				ParameterInfo parameterInfo = methodInfo.GetParameters()[paramIndex];

				if (paramIndex > 0)
					parameters += ", ";

				parameters += string.Format(
					"{0} {1}",
					ConfigOptions.ToCppTypename(parameterInfo, parameterInfo.ParameterType),
					parameterInfo.Name);
			}

			return parameters;
		}

		/// <summary>
		/// Writes the wrapper methods.
		/// </summary>
		/// <param name="wrapperTypes">The wrapper types.</param>
		private void WriteWrappersMethods(IEnumerable<Type> wrapperTypes)
		{
			wrapperTypes = wrapperTypes.Where(t => !t.IsGenericTypeDefinition);

			foreach (Type wrapperType in wrapperTypes)
			{
				WriteWrapperMethods(wrapperType);
			}
		}

		/// <summary>
		/// Gets the name of the descriptor of function.
		/// </summary>
		/// <param name="returnType">Type of the return.</param>
		/// <returns></returns>
		public static string GetDescriptorOfFunctionName(string returnType)
		{
			return ("new" + returnType).ToCStyle();
		}

		/// <summary>
		/// Writes the wrapper methods.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		private void WriteWrapperMethods(Type wrapperType)
		{
			if (!wrapperType.HasAttribute<CppTypeAttribute>())
				throw new NotSupportedException();

			var attribute = wrapperType.GetAttribute<CppTypeAttribute>(false);
			IEnumerable<MethodInfo> methods = ReflectionUtility.GetMethods(wrapperType);

			_writer.WriteLine("/*");
			_writer.WriteLine(" * Function group: {0}", wrapperType);
			_writer.WriteLine(" */");
			_writer.WriteLine();

			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.IsPropertyMember())
					continue;

				WriteMethod(wrapperType, methodInfo);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="methodInfo">The method info.</param>
		private void WriteMethod(Type type, MethodInfo methodInfo)
		{
			string functionName;
			string targetMethod;

			var targetType = ConfigOptions.GetCppTypename(type);
			bool isConstructor = false;
			string cppTargetType = targetType;

			if (methodInfo.HasAttribute<ConstructorAttribute>())
			{
				functionName = "new" + targetType.ToLower().ToPascalCase();
				targetMethod = targetType;

				//ParameterInfo[] ctrParameters = methodInfo.GetParameters();
				//functionName = AddBySuffix(ctrParameters, functionName);

				if (IsOverloaded(methodInfo))
					functionName += "_m" + GetNumberFromSequence(methodInfo);

				isConstructor = true;
			}
			else if (methodInfo.HasAttribute<DestructorAttribute>())
			{
				functionName = "delete" + targetType.ToLower().ToPascalCase();
				targetMethod = "~" + targetType;
			}
			else
			{
				var methodName = methodInfo.Name;

				functionName = targetType.ToLower().ToPascalCase() + methodName;
				targetMethod = methodInfo.Name.ToCamelCase();

				if (IsOverloaded(methodInfo))
					functionName += "_m" + GetNumberFromSequence(methodInfo);
			}

			string parameters;

			if (methodInfo.HasAttribute<DestructorAttribute>())
			{
				parameters = "InvHandle self";
			}
			else if (methodInfo.HasAttribute<MethodAttribute>())
			{
				var attr = methodInfo.GetAttribute<MethodAttribute>(true);

				parameters = GetParametersString(methodInfo);

				if (!attr.Static)
					parameters = "InvHandle self" +
								 (!string.IsNullOrEmpty(parameters) ? (", " + parameters) : parameters);
			}
			else
			{
				parameters = GetParametersString(methodInfo);
			}

			string returnedType = ConfigOptions.ToCppTypename(methodInfo.ReturnParameter, methodInfo.ReturnType);

			if (isConstructor)
				returnedType = "InvHandle";

			_writer.WriteLine("/**");
			_writer.WriteLine(" * Method: {0}::{1}", cppTargetType, targetMethod);
			_writer.WriteLine(" */");
			_writer.WriteLine("INV_EXPORT {0}", returnedType);
			_writer.WriteLine("INV_CALL {0}({1});", functionName.ToCStyle(), parameters);
			_writer.WriteLine();
		}

		#endregion
	}
}
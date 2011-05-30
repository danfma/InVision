using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native;

namespace ReverseGenerator.Cpp
{
	/// <summary>
	/// 
	/// </summary>
	public class CppHeaderGenerator : IGenerator
	{
		internal const BindingFlags MethodFlags =
			BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

		private string _defineFilename;
		private string _filename;
		private SourceWriter _writer;

		/// <summary>
		/// Gets the define filename.
		/// </summary>
		/// <value>The define filename.</value>
		protected string DefineFilename
		{
			get { return _defineFilename; }
		}

		/// <summary>
		/// Gets the filename.
		/// </summary>
		/// <value>The filename.</value>
		protected string Filename
		{
			get { return _filename; }
		}

		/// <summary>
		/// Gets the name of the project.
		/// </summary>
		/// <value>The name of the project.</value>
		protected string ProjectName
		{
			get { return Options.ProjectName; }
		}

		/// <summary>
		/// Gets or sets the writer.
		/// </summary>
		/// <value>The writer.</value>
		protected SourceWriter Writer
		{
			get { return _writer; }
			set { _writer = value; }
		}

		/// <summary>
		/// Gets or sets the options.
		/// </summary>
		/// <value>The options.</value>
		protected ConfigOptions Options { get; set; }

		#region IGenerator Members

		/// <summary>
		/// Generates the specified options.
		/// </summary>
		/// <param name="configOptions">The options.</param>
		/// <param name="types">The types.</param>
		public virtual void Generate(ConfigOptions configOptions, IEnumerable<Type> types)
		{
			Options = configOptions;

			_filename = (ProjectName + ".h").ToLower();
			_defineFilename = _filename.Replace('.', '_').ToUpper();

			using (_writer = new SourceWriter(Path.Combine(Path.GetFullPath(Options.CppOutputDir), _filename))) {
				IEnumerable<Type> functionTypes = types.Where(t => t.HasAttribute<CppFunctionAttribute>());

				IEnumerable<Type> wrapperTypes = types.Where(t => t.HasAttribute<CppClassAttribute>(true));

				IEnumerable<Type> enumerations = types.Where(t => t.IsEnum);

				IEnumerable<Type> valueObjects =
					types.Where(t => t.HasAttribute<CppValueObjectAttribute>() && t.IsValueType && !t.IsEnum);

				IEnumerable<Type> functionProviders =
					types.Where(
						t =>
						t.HasAttribute<CppTypeAttribute>() && !t.HasAttribute<CppClassAttribute>(true) &&
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

				WriteInlineConvertersAndConverters(converters.Union(wrapperTypes).Distinct(), wrapperTypes);
				WriteFooter();

				_writer.Close();
			}
		}

		/// <summary>
		/// Writes the converter registries.
		/// </summary>
		/// <param name="wrapperTypes">The wrapper types.</param>
		private void WriteConverterRegistries(IEnumerable<Type> wrapperTypes)
		{
			_writer.WriteLine("/*");
			_writer.WriteLine(" * Initializer");
			_writer.WriteLine(" */");

			_writer.WriteLine("struct {0}", Options.ProjectName);
			_writer.OpenBlock();
			{
				_writer.WriteLine("{0}()", Options.ProjectName);
				_writer.OpenBlock();

				foreach (var wrapperType in wrapperTypes) {
					WriteConverterRegistry(wrapperType);
				}

				_writer.CloseBlock();
			}
			_writer.CloseBlock(";");
			_writer.WriteLine();
			_writer.WriteLine("static {0} __init{0};", Options.ProjectName);
			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the converter registry.
		/// </summary>
		/// <param name="sourceType">Type of the wrapper.</param>
		private void WriteConverterRegistry(Type sourceType)
		{
			var attrType = sourceType.GetAttribute<CppTypeAttribute>(true);

			var baseTypes = GetBaseTypes(sourceType);
			var interfaces = sourceType.GetInterfaces().Where(x => x.QueryAttribute<CppClassAttribute>(y => y.Type == ClassType.Interface));
			var targetTypes = baseTypes.Union(interfaces).Distinct();

			foreach (var targetType in targetTypes) {
				var attrBaseType = targetType.GetAttribute<CppTypeAttribute>(true);
				var typeFrom = ConfigOptions.GetCppTypename(sourceType);
				var typeTo = ConfigOptions.GetCppTypename(targetType);

				_writer.WriteLine("register_converter< {0}, {1} >();",
								  attrType.GetCppFullName(typeFrom, GetGenericTypes(sourceType).ToArray()),
								  attrBaseType.GetCppFullName(typeTo, GetGenericTypes(targetType).ToArray()));
			}
		}

		/// <summary>
		/// Gets the generic types.
		/// </summary>
		/// <param name="genericType">Type of the generic.</param>
		/// <returns></returns>
		private IEnumerable<string> GetGenericTypes(Type genericType)
		{
			if (!genericType.IsGenericType)
				yield break;

			foreach (var genericArgument in genericType.GetGenericArguments()) {
				var attr = genericArgument.GetAttribute<CppTypeAttribute>(true);

				if (attr == null)
					continue;

				yield return attr.GetCppFullName(
					ConfigOptions.GetCppTypename(genericArgument),
					GetGenericTypes(genericArgument).ToArray());
			}
		}

		/// <summary>
		/// Gets the base types.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		private IEnumerable<Type> GetBaseTypes(Type wrapperType)
		{
			var baseType = Options.GetBaseType(wrapperType);

			if (baseType == null)
				yield break;

			yield return baseType;

			foreach (var baseBaseType in GetBaseTypes(baseType)) {
				yield return baseBaseType;
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

			foreach (Type functionType in functionTypes) {
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

			if (method.HasAttribute<ConstructorAttribute>()) {
				functionName = "new" + targetType.ToLower().ToPascalCase();

				//ParameterInfo[] ctrParameters = method.GetParameters();
				//functionName = AddBySuffix(ctrParameters, functionName);
			} else if (method.HasAttribute<DestructorAttribute>()) {
				functionName = "delete" + targetType.ToLower().ToPascalCase();
			} else {
				functionName = targetType.ToLower().ToPascalCase() + method.Name;
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
		/// <param name="wrapperTypes"></param>
		private void WriteInlineConvertersAndConverters(IEnumerable<Type> converters, IEnumerable<Type> wrapperTypes)
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

			foreach (var definition in definitions) {
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

			foreach (Type converter in converters) {
				WriteInlineConverter(converter);
			}

			WriteConverterRegistries(wrapperTypes);

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
			foreach (Type enumeration in enumerations) {
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

			foreach (var entry in enumEntries) {
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

			foreach (var projectReference in Options.ProjectReferences) {
				_writer.WriteLine("#include \"{0}\"", projectReference.ToLower() + ".h");
			}

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

			foreach (Type type in types) {
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

			foreach (Type type in wrapperTypes) {
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
			foreach (Type type in types) {
				var generator = new CppValueObjectGenerator(Options, type);
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
			foreach (Type type in types) {
				var generator = new CppWraperDescriptorGenerator(Options, type);
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
			foreach (Type functionProvider in functionProviders) {
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

			foreach (MethodInfo methodInfo in methods) {
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

			if (methodInfo.HasAttribute<ConstructorAttribute>()) {
				functionName = "new" + targetType.ToLower().ToPascalCase();
				targetMethod = targetType;

				ParameterInfo[] ctrParameters = methodInfo.GetParameters();
				functionName = AddBySuffix(ctrParameters, functionName);
			} else if (methodInfo.HasAttribute<DestructorAttribute>()) {
				functionName = "delete" + targetType.ToLower().ToPascalCase();
				targetMethod = "~" + targetType;
			} else {
				functionName = targetType.ToLower().ToPascalCase() + methodInfo.Name;
				targetMethod = methodInfo.Name.ToCamelCase();

				if (IsOverloaded(methodInfo))
					functionName += GetNumberFromSequence(methodInfo);
			}

			string parameters;

			if (methodInfo.HasAttribute<DestructorAttribute>()) {
				parameters = "InvHandle self";
			} else if (methodInfo.HasAttribute<MethodAttribute>()) {
				var attr = methodInfo.GetAttribute<MethodAttribute>(true);

				parameters = GetParametersString(methodInfo);

				if (!attr.Static)
					parameters = "InvHandle self" +
								 (!string.IsNullOrEmpty(parameters) ? (", " + parameters) : parameters);
			} else {
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

			foreach (MethodInfo method in methods) {
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

			for (int paramIndex = paramStart; paramIndex < parameters.Length; paramIndex++) {
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

			for (int paramIndex = 0; paramIndex < methodInfo.GetParameters().Length; paramIndex++) {
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
		protected void WriteWrappersMethods(IEnumerable<Type> wrapperTypes)
		{
			wrapperTypes = wrapperTypes.Where(t => !t.IsGenericTypeDefinition);

			foreach (Type wrapperType in wrapperTypes) {
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
		/// <param name="writeContent">if set to <c>true</c> [write content].</param>
		protected void WriteWrapperMethods(Type wrapperType, bool writeContent = false)
		{
			if (!wrapperType.HasAttribute<CppTypeAttribute>())
				throw new NotSupportedException();

			var attribute = wrapperType.GetAttribute<CppTypeAttribute>(false);
			IEnumerable<MethodInfo> methods = Options.GetAllMethods(wrapperType);

			_writer.WriteLine("/*");
			_writer.WriteLine(" * Function group: {0}", wrapperType);
			_writer.WriteLine(" */");
			_writer.WriteLine();

			foreach (MethodInfo methodInfo in methods) {
				if (methodInfo.IsPropertyMember())
					continue;

				WriteMethod(wrapperType, methodInfo, writeContent);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="methodInfo">The method info.</param>
		/// <param name="writeContent">if set to <c>true</c> [write content].</param>
		protected virtual void WriteMethod(Type type, MethodInfo methodInfo, bool writeContent = false)
		{
			string functionName;
			string targetMethod;

			var targetType = ConfigOptions.GetCppTypename(type);
			bool isConstructor = false;
			bool implemented = false;
			string cppTargetType = targetType;

			if (methodInfo.HasAttribute<ConstructorAttribute>()) {
				functionName = "new" + targetType.ToLower().ToPascalCase();
				targetMethod = targetType;

				//ParameterInfo[] ctrParameters = methodInfo.GetParameters();
				//functionName = AddBySuffix(ctrParameters, functionName);

				if (IsOverloaded(methodInfo))
					functionName += "_m" + GetNumberFromSequence(methodInfo);

				isConstructor = true;
				implemented = methodInfo.QueryAttribute<ConstructorAttribute>(x => x.Implemented);

			} else if (methodInfo.HasAttribute<DestructorAttribute>()) {
				functionName = "delete" + targetType.ToLower().ToPascalCase();
				targetMethod = "~" + targetType;
				implemented = methodInfo.QueryAttribute<DestructorAttribute>(x => x.Implemented);

			} else {
				var methodName = methodInfo.Name;

				functionName = targetType.ToLower().ToPascalCase() + methodName;
				targetMethod = methodInfo.Name.ToCamelCase();

				if (IsOverloaded(methodInfo))
					functionName += "_m" + GetNumberFromSequence(methodInfo);

				implemented = methodInfo.QueryAttribute<MethodAttribute>(x => x.Implemented);
			}

			string parameters;

			if (methodInfo.HasAttribute<DestructorAttribute>()) {
				parameters = "InvHandle self";

			} else if (methodInfo.HasAttribute<MethodAttribute>()) {
				var attr = methodInfo.GetAttribute<MethodAttribute>(true);

				parameters = GetParametersString(methodInfo);

				if (!attr.Static)
					parameters = "InvHandle self" +
								 (!string.IsNullOrEmpty(parameters) ? (", " + parameters) : parameters);

			} else {
				parameters = GetParametersString(methodInfo);
			}

			string returnedType = ConfigOptions.ToCppTypename(methodInfo.ReturnParameter, methodInfo.ReturnType);

			if (isConstructor)
				returnedType = "InvHandle";

			_writer.WriteLine("/**");
			_writer.WriteLine(" * Method: {0}::{1} {2}", cppTargetType, targetMethod, implemented ? "(OK)" : "(NOT IMPLEMENTED)");
			_writer.WriteLine(" */");
			_writer.WriteLine("INV_EXPORT {0}", returnedType);
			_writer.WriteLine("INV_CALL {0}({1}){2}", functionName.ToCStyle(), parameters, writeContent ? string.Empty : ";");

			if (writeContent) {
				_writer.OpenBlock();
				WriteMethodContent(type, methodInfo);
				_writer.CloseBlock();
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the content of the method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="methodInfo">The method info.</param>
		protected virtual void WriteMethodContent(Type type, MethodInfo methodInfo)
		{

		}

		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using InVision.Extensions;
using InVision.Native.Ext;

namespace CodeGenerator
{
	public class CppGenerator : IGenerator
	{
		public static readonly IDictionary<Type, string> TranslatedTypes;
		private string _defineFilename;
		private string _filename;
		private string _projectName;
		private SourceWriter _writer;

		/// <summary>
		/// Initializes the <see cref="CppGenerator"/> class.
		/// </summary>
		static CppGenerator()
		{
			TranslatedTypes = new Dictionary<Type, string>();
			TranslatedTypes.Add(typeof(bool), "_bool");
			TranslatedTypes.Add(typeof(char), "_wchar");
			TranslatedTypes.Add(typeof(sbyte), "_sbyte");
			TranslatedTypes.Add(typeof(byte), "_byte");
			TranslatedTypes.Add(typeof(short), "_short");
			TranslatedTypes.Add(typeof(ushort), "_ushort");
			TranslatedTypes.Add(typeof(int), "_int");
			TranslatedTypes.Add(typeof(uint), "_uint");
			TranslatedTypes.Add(typeof(long), "_long");
			TranslatedTypes.Add(typeof(ulong), "_ulong");
			TranslatedTypes.Add(typeof(float), "_float");
			TranslatedTypes.Add(typeof(double), "_double");
			TranslatedTypes.Add(typeof(IntPtr), "_any");
			TranslatedTypes.Add(typeof(UIntPtr), "_any");
			TranslatedTypes.Add(typeof(Handle), "InvHandle");
			TranslatedTypes.Add(typeof(void), "void");
		}

		#region IGenerator Members

		/// <summary>
		/// Generates the specified type.
		/// </summary>
		/// <param name="projectName">Name of the project.</param>
		/// <param name="types">The types.</param>
		public void Generate(string projectName, IEnumerable<Type> types)
		{
			_projectName = projectName;
			_filename = (projectName + ".h").ToLower();
			_defineFilename = _filename.Replace('.', '_').ToUpper();

			using (_writer = new SourceWriter(_filename))
			{
				IEnumerable<Type> valueObjects = types.Where(t => t.HasAttribute<ValueObjectAttribute>());
				IEnumerable<Type> functionProviders = types.Where(t => t.HasAttribute<FunctionProviderAttribute>());

				WriteHeader();

				_writer.WriteLine("extern \"C\"");
				_writer.WriteLine("{");
				_writer.Indent();

				WritePrototypes(valueObjects);
				WriteTypeDefinitions(valueObjects);
				WriteFunctionProviders(functionProviders);

				_writer.Deindent();
				_writer.WriteLine("}");
				_writer.WriteLine();

				WriteFooter();

				_writer.Close();
			}
		}

		#endregion

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

		/// <summary>
		/// Writes the prototypes.
		/// </summary>
		/// <param name="types">The types.</param>
		private void WritePrototypes(IEnumerable<Type> types)
		{
			foreach (Type type in types)
			{
				WritePrototype(type);
			}
		}

		/// <summary>
		/// Writes the prototype.
		/// </summary>
		/// <param name="type">The type.</param>
		private void WritePrototype(Type type)
		{
			string cppTypename = GetCppTypename(type);

			_writer.WriteLine("/**");
			_writer.WriteLine(" * Type {0}", cppTypename);
			_writer.WriteLine(" */");
			_writer.WriteLine("struct {0};", cppTypename);
			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the type definitions.
		/// </summary>
		/// <param name="types">The types.</param>
		private void WriteTypeDefinitions(IEnumerable<Type> types)
		{
			foreach (Type type in types)
			{
				WriteTypeDefinition(type);
			}

			_writer.WriteLine();
		}

		/// <summary>
		/// Generates the type file.
		/// </summary>
		/// <param name="type">The type.</param>
		private void WriteTypeDefinition(Type type)
		{
			_writer.WriteLine("struct {0}", GetCppTypename(type));
			_writer.WriteLine("{");
			_writer.Indent();

			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

			foreach (FieldInfo fieldInfo in fields)
			{
				WriteField(_writer, fieldInfo);
			}

			_writer.Deindent();
			_writer.WriteLine("};");
			_writer.WriteLine();
		}

		/// <summary>
		/// Writes the field.
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="fieldInfo">The field info.</param>
		private void WriteField(SourceWriter writer, FieldInfo fieldInfo)
		{
			Type fieldType = fieldInfo.FieldType;
			string fieldName = fieldInfo.Name;

			writer.WriteLine("{0} {1};",
							 TranslateType(fieldInfo, fieldType),
							 fieldName.StartsWith("_") ? fieldName.Substring(1) : fieldName);
		}

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
			if (!functionProvider.HasAttribute<TargetCppTypeAttribute>())
				throw new NotSupportedException();

			var attribute = functionProvider.GetAttribute<TargetCppTypeAttribute>(false);
			string targetType = attribute.Typename;
			MethodInfo[] methods = functionProvider.GetMethods(BindingFlags.Public | BindingFlags.Instance);

			foreach (MethodInfo methodInfo in methods)
			{
				WriteTypeMethodToFunction(targetType, methodInfo);
			}
		}

		/// <summary>
		/// Writes the type method to function.
		/// </summary>
		/// <param name="targetType">Type of the target.</param>
		/// <param name="methodInfo">The method info.</param>
		private void WriteTypeMethodToFunction(string targetType, MethodInfo methodInfo)
		{
			string functionName;
			string targetMethod;

			if (methodInfo.HasAttribute<ConstructorAttribute>())
			{
				functionName = "new" + targetType;
				targetMethod = targetType;

				for (int paramIndex = 0; paramIndex < methodInfo.GetParameters().Length; paramIndex++)
				{
					var parameterInfo = methodInfo.GetParameters()[paramIndex];

					if (paramIndex == 0)
						functionName += "By_";
					else
						functionName += "_";

					functionName += parameterInfo.Name.ToPascalCase();
				}
			}
			else if (methodInfo.HasAttribute<DestructorAttribute>())
			{
				functionName = "delete" + targetType;
				targetMethod = "~" + targetType;
			}
			else
			{
				functionName = targetType + methodInfo.Name;
				targetMethod = methodInfo.Name.ToCamelCase();
			}

			string parameters = GetParametersString(methodInfo);

			_writer.WriteLine("/**");
			_writer.WriteLine(" * Method: {0}::{1}", targetType, targetMethod);
			_writer.WriteLine(" */");
			_writer.WriteLine("INV_EXPORT {0}", TranslateType(methodInfo, methodInfo.ReturnType));
			_writer.WriteLine("INV_CALL {0}({1});", functionName.ToCStyle(), parameters);
			_writer.WriteLine();
		}

		/// <summary>
		/// Gets the parameters string.
		/// </summary>
		/// <param name="methodInfo">The method info.</param>
		/// <returns></returns>
		private string GetParametersString(MethodInfo methodInfo)
		{
			string parameters = string.Empty;

			for (int paramIndex = 0; paramIndex < methodInfo.GetParameters().Length; paramIndex++)
			{
				ParameterInfo parameterInfo = methodInfo.GetParameters()[paramIndex];

				if (paramIndex > 0)
					parameters += ", ";

				parameters += string.Format(
					"{0} {1}",
					TranslateType(parameterInfo, parameterInfo.ParameterType),
					parameterInfo.Name);
			}

			return parameters;
		}

		/// <summary>
		/// Gets the CPP typename.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static string GetCppTypename(Type type)
		{
			return type.Name;
		}

		/// <summary>
		/// Translates the type.
		/// </summary>
		/// <param name="fieldInfo">The field info.</param>
		/// <param name="fieldType">Type of the field.</param>
		/// <returns></returns>
		public static string TranslateType(ICustomAttributeProvider fieldInfo, Type fieldType)
		{
			string translatedType;

			if (fieldType == typeof(string))
			{
				return fieldInfo.HasAttribute<MarshalAsAttribute>() &&
					   fieldInfo.GetAttribute<MarshalAsAttribute>(false).Value == UnmanagedType.LPStr
						? "_string"
						: "_wstring";
			}

			if (TranslatedTypes.TryGetValue(fieldType, out translatedType))
				return translatedType;

			if (fieldType.IsPointer)
			{
				string pointedTypename = fieldType.FullName.Substring(0, fieldType.FullName.Length - 1);
				Type pointedType = fieldType.Assembly.GetType(pointedTypename);

				return TranslateType(fieldInfo, pointedType) + "*";
			}

			if (fieldType.IsEnum)
				return "_int";

			return GetCppTypename(fieldType);
		}
	}
}
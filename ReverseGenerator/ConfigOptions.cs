using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using InVision.Extensions;
using InVision.Native;
using ReverseGenerator.Cpp;

namespace ReverseGenerator
{
	public class ConfigOptions
	{
		public static readonly IDictionary<Type, string> TranslatedTypes;
		public static readonly IDictionary<Type, string> CSharpTypes;

		private string _cppOutputDir;
		private string _csOutputDir;
		private string _libraryName;

		/// <summary>
		/// Initializes the <see cref="CppHeaderGenerator"/> class.
		/// </summary>
		static ConfigOptions()
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

			CSharpTypes = new Dictionary<Type, string> {
				{ typeof (bool), "bool" },
				{ typeof (char), "char" },
				{ typeof (sbyte), "sbyte" },
				{ typeof (byte), "byte" },
				{ typeof (short), "short" },
				{ typeof (ushort), "ushort" },
				{ typeof (int), "int" },
				{ typeof (uint), "uint" },
				{ typeof (long), "long" },
				{ typeof (ulong), "ulong" },
				{ typeof (float), "float" },
				{ typeof (double), "double" },
				{ typeof (IntPtr), "IntPtr" },
				{ typeof (UIntPtr), "UIntPtr" },
				{ typeof (Handle), "Handle" },
				{ typeof (void), "void" }
			};
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigOptions"/> class.
		/// </summary>
		public ConfigOptions()
		{
			ProjectReferences = new List<string>();
			AssembliesToScan = new List<Assembly>();
			CsOutputDir = CppOutputDir = Environment.CurrentDirectory;
		}

		/// <summary>
		/// Gets or sets the name of the project.
		/// </summary>
		/// <value>The name of the project.</value>
		public string ProjectName { get; set; }

		/// <summary>
		/// Gets or sets the project references.
		/// </summary>
		/// <value>The project references.</value>
		public List<string> ProjectReferences { get; set; }

		/// <summary>
		/// Gets or sets the name of the library.
		/// </summary>
		/// <value>The name of the library.</value>
		public string LibraryName
		{
			get { return _libraryName ?? ProjectName; }
			set { _libraryName = value; }
		}

		/// <summary>
		/// Gets the include CPP header.
		/// </summary>
		/// <value>The include CPP header.</value>
		public string IncludeCppHeader
		{
			get { return ProjectName.ToLower() + ".h"; }
		}

		/// <summary>
		/// Gets or sets the cs output dir.
		/// </summary>
		/// <value>The cs output dir.</value>
		public string CsOutputDir
		{
			get { return _csOutputDir; }
			set { _csOutputDir = Path.GetFullPath(value); }
		}

		/// <summary>
		/// Gets or sets the CPP output dir.
		/// </summary>
		/// <value>The CPP output dir.</value>
		public string CppOutputDir
		{
			get { return _cppOutputDir; }
			set { _cppOutputDir = Path.GetFullPath(value); }
		}

		/// <summary>
		/// Gets or sets the assemblies to scan.
		/// </summary>
		/// <value>The assemblies to scan.</value>
		public List<Assembly> AssembliesToScan { get; set; }

		/// <summary>
		/// Translates the type.
		/// </summary>
		/// <param name="fieldInfo">The field info.</param>
		/// <param name="fieldType">Type of the field.</param>
		/// <returns></returns>
		public static string ToCppTypename(ICustomAttributeProvider fieldInfo, Type fieldType)
		{
			string translatedType;

			if (fieldType == typeof(string)) {
				return fieldInfo.HasAttribute<MarshalAsAttribute>() &&
					   fieldInfo.GetAttribute<MarshalAsAttribute>(false).Value == UnmanagedType.LPStr
						? "_string"
						: "_wstring";
			}

			if (TranslatedTypes.TryGetValue(fieldType, out translatedType))
				return translatedType;

			if (fieldType.IsByRef) {
				string pointedTypename = fieldType.FullName.Substring(0, fieldType.FullName.Length - 1);
				Type pointedType = fieldType.Assembly.GetType(pointedTypename);

				return ToCppTypename(fieldInfo, pointedType) + "*";
			}

			if (fieldType.IsArray) {
				return ToCppTypename(fieldInfo, fieldType.GetElementType()) + "*";
			}

			if (fieldType.IsPointer) {
				string pointedTypename = fieldType.FullName.Substring(0, fieldType.FullName.Length - 1);
				Type pointedType = fieldType.Assembly.GetType(pointedTypename);

				return ToCppTypename(fieldInfo, pointedType) + "*";
			}

			if (fieldType.IsEnum)
				return GetCppEnumName(fieldType);

			if (fieldType.HasICppInterface())
				return ToCppTypename(fieldInfo, typeof(Handle));

			return GetCppTypename(fieldType);
		}

		/// <summary>
		/// Gets the CPP typename.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static string GetCppTypename(Type type)
		{
			if (type.HasAttribute<CppClassAttribute>())
				return type.Name.Substring(1).ToPascalCase();

			return type.Name;
		}

		/// <summary>
		/// Gets the name of the CPP enum.
		/// </summary>
		/// <param name="enumeration">The enumeration.</param>
		/// <returns></returns>
		public static string GetCppEnumName(Type enumeration)
		{
			return enumeration.Name.ToCStyle().ToUpper();
		}

		/// <summary>
		/// Gets the name of the field.
		/// </summary>
		/// <param name="property">The property.</param>
		/// <returns></returns>
		public static string GetFieldName(PropertyInfo property)
		{
			return GetFieldName(property.Name);
		}

		/// <summary>
		/// Gets the name of the field.
		/// </summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns></returns>
		public static string GetFieldName(string fieldName)
		{
			return (fieldName.StartsWith("_") ? fieldName.Substring(1) : fieldName).ToCamelCase();
		}

		/// <summary>
		/// Gets the CPP wrapper typename.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static string GetCppWrapperDescriptorTypename(Type type)
		{
			return (type.Name.Substring(1) + "Descriptor").ToPascalCase();
		}

		/// <summary>
		/// Gets the C sharp wrapper descriptor typename.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static string GetCSharpWrapperDescriptorTypename(Type type)
		{
			return (type.Name.Substring(1) + "Descriptor").ToPascalCase();
		}

		/// <summary>
		/// Additionals the include.
		/// </summary>
		/// <param name="cppTypename">The CPP typename.</param>
		/// <returns></returns>
		public string AdditionalInclude(string cppTypename)
		{
			return (ProjectName.ToLower() + "_" + cppTypename).ToCStyle() + ".h";
		}

		/// <summary>
		/// Gets the C sharp type string.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static string GetCSharpTypeString(Type type)
		{
			string csharpType;

			if (CSharpTypes.TryGetValue(type, out csharpType))
				return csharpType;

			if (type.IsByRef) {
				string pointedTypename = type.FullName.Substring(0, type.FullName.Length - 1);
				Type pointedType = type.Assembly.GetType(pointedTypename);

				return GetCSharpTypeString(pointedType);
			}

			if (type.IsArray) {
				return GetCSharpTypeString(type.GetElementType()) + "[]";
			}

			if (type.IsPointer) {
				string pointedTypename = type.FullName.Substring(0, type.FullName.Length - 1);
				Type pointedType = type.Assembly.GetType(pointedTypename);

				return GetCSharpTypeString(pointedType) + "*";
			}

			return type.Name;
		}

		/// <summary>
		/// Gets the C sharp parameter modification.
		/// </summary>
		/// <param name="parameter">The parameter.</param>
		/// <returns></returns>
		public static string GetCSharpParameterModifier(ParameterInfo parameter)
		{
			if (parameter.IsIn)
				return "in";

			if (parameter.IsOut)
				return "out";

			if (parameter.ParameterType.IsByRef)
				return "ref";

			return string.Empty;
		}

		public static string GetCSharpCppInstanceTypename(Type wrapperType)
		{
			return wrapperType.Name.Substring(1).ToPascalCase() + "Impl";
		}

		public static Type GetCppInstanceBaseType(Type wrapperType)
		{
			return wrapperType.GetAttribute<CppClassAttribute>(false).BaseType;
		}

		public static string GetCSharpNativeTypename(Type wrapperType)
		{
			return "Native" + wrapperType.Name.Substring(1).ToPascalCase();
		}

		/// <summary>
		/// Translates to CPP parameters.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <returns></returns>
		public static string TranslateToCppParameters(ParameterInfo[] parameters)
		{
			IEnumerable<string> convertedParameters =
				from p in parameters
				select TranslateToCppParameter(p);

			return convertedParameters.Join(", ");
		}

		/// <summary>
		/// Translates to CPP parameter.
		/// </summary>
		/// <param name="parameter">The parameter.</param>
		/// <returns></returns>
		private static string TranslateToCppParameter(ParameterInfo parameter)
		{
			return string.Format("{0} {1}", ToCppTypename(parameter, parameter.ParameterType), parameter.Name);
		}

		/// <summary>
		/// Adds the assembly.
		/// </summary>
		/// <param name="assemblyFile">The assembly file.</param>
		public void AddAssembly(string assemblyFile)
		{
			AssembliesToScan.Add(Assembly.LoadFrom(assemblyFile));
		}

		/// <summary>
		/// Gets the methods.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		public IEnumerable<MethodInfo> GetMethods(Type wrapperType)
		{
			IEnumerable<MethodInfo> methods =
				from method in wrapperType.GetMethods()
				where method.QueryAttribute<MethodAttribute>(attr => string.IsNullOrEmpty(attr.Property))
				select method;

			var baseType = GetBaseType(wrapperType);
			var @interfaces =
				from t in wrapperType.GetInterfaces()
				where
					t.QueryAttribute<CppClassAttribute>(x => x.Type == ClassType.Interface) &&
					((baseType != null && !baseType.HasInterface(t)) || baseType == null)
				select t;

			methods = methods.Union(
				from @interface in @interfaces
				from method in @interface.GetMethods()
				where method.HasAttribute<MethodAttribute>(true)
				select method);

			return methods;
		}

		/// <summary>
		/// Gets the type of the base.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		public Type GetBaseType(Type wrapperType)
		{
			return CppClassAttribute.GetBaseType(wrapperType);
		}

		/// <summary>
		/// Determines whether [has base type] [the specified wrapper type].
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns>
		/// 	<c>true</c> if [has base type] [the specified wrapper type]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasBaseType(Type wrapperType)
		{
			return GetBaseType(wrapperType) != null;
		}

		/// <summary>
		/// Gets the wrapper types.
		/// </summary>
		/// <param name="types">The types.</param>
		/// <returns></returns>
		public IEnumerable<Type> GetWrapperTypes(IEnumerable<Type> types)
		{
			return types.Where(t => t.HasAttribute<CppClassAttribute>(true) && !t.IsGenericTypeDefinition);
		}

		/// <summary>
		/// Gets the constructors.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		public IEnumerable<MethodInfo> GetConstructors(Type wrapperType)
		{
			//ReflectionUtility.GetMethods(wrapperType).
			// Where(m => m.HasAttribute<ConstructorAttribute>());
			return wrapperType.GetMethods().Where(m => m.HasAttribute<ConstructorAttribute>());
		}

		/// <summary>
		/// Determines whether the specified wrapper type has destructor.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns>
		/// 	<c>true</c> if the specified wrapper type has destructor; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDestructor(Type wrapperType)
		{
			return FindDestructor(wrapperType).Any();
		}

		/// <summary>
		/// Gets the destructor.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		public MethodInfo GetDestructor(Type wrapperType)
		{
			return FindDestructor(wrapperType).SingleOrDefault();
		}

		/// <summary>
		/// Finds the destructor.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		private IEnumerable<MethodInfo> FindDestructor(Type wrapperType)
		{
			return ReflectionUtility.GetMethods(wrapperType).Where(m => m.HasAttribute<DestructorAttribute>(false));
		}

		/// <summary>
		/// Gets all methods.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		public IEnumerable<MethodInfo> GetAllMethods(Type wrapperType)
		{
			var methods = GetConstructors(wrapperType);
			methods = methods.Union(GetDestructors(wrapperType));
			methods = methods.Union(GetMethods(wrapperType));

			return methods;
		}

		/// <summary>
		/// Gets the destructors.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		public IEnumerable<MethodInfo> GetDestructors(Type wrapperType)
		{
			var destructor = GetDestructor(wrapperType);

			if (destructor != null)
				yield return destructor;
		}
	}
}
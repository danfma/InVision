using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using CodeGenerator.Cpp;
using InVision.Extensions;
using InVision.Native.Ext;

namespace CodeGenerator
{
    public class ConfigOptions
    {
        public static readonly IDictionary<Type, string> TranslatedTypes;
        public static readonly IDictionary<Type, string> CSharpTypes;

        private string _cppOutputDir;
        private string _csOutputDir;

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
            AssembliesToScan = new List<Assembly>();
            CsOutputDir = CppOutputDir = Environment.CurrentDirectory;
        }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
        public string ProjectName { get; set; }

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

            if (fieldType.IsArray)
            {
                return TranslateType(fieldInfo, fieldType.GetElementType()) + "*";
            }

            if (fieldType.IsPointer)
            {
                string pointedTypename = fieldType.FullName.Substring(0, fieldType.FullName.Length - 1);
                Type pointedType = fieldType.Assembly.GetType(pointedTypename);

                return TranslateType(fieldInfo, pointedType) + "*";
            }

            if (fieldType.IsEnum)
                return GetCppEnumName(fieldType);

            return GetCppTypename(fieldType);
        }

        /// <summary>
        /// Gets the CPP typename.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string GetCppTypename(Type type)
        {
            if (type.HasAttribute<CppInterfaceAttribute>())
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
        /// Gets the cs wrapper typename.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string GetCsWrapperTypename(Type type)
        {
            return type.Name.Substring(1).ToPascalCase();
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

            if (type.IsArray)
            {
                return GetCSharpTypeString(type.GetElementType()) + "[]";
            }

            if (type.IsByRef)
            {
                string pointedTypename = type.FullName.Substring(0, type.FullName.Length - 1);
                Type pointedType = type.Assembly.GetType(pointedTypename);

                return "ref " + GetCSharpTypeString(pointedType);
            }

            if (type.IsPointer)
            {
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
        public static string GetCSharpParameterModification(ParameterInfo parameter)
        {
            if (parameter.IsIn)
                return "in";

            if (parameter.IsOut)
                return "out";

            return string.Empty;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native.Ext;

namespace CodeGenerator.Cpp
{
    public abstract class CppValueObjectGeneratorBase
    {
        private readonly ConfigOptions _configOptions;
        private readonly Type _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="CppValueObjectGenerator"/> class.
        /// </summary>
        /// <param name="configOptions">The options.</param>
        /// <param name="type">The type.</param>
        protected CppValueObjectGeneratorBase(ConfigOptions configOptions, Type type)
        {
            _configOptions = configOptions;
            _type = type;
        }

        /// <summary>
        /// Gets the config options.
        /// </summary>
        /// <value>The config options.</value>
        public ConfigOptions ConfigOptions
        {
            get { return _configOptions; }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            string cppTypename = GetTypename();
            string filename = ConfigOptions.AdditionalInclude(cppTypename);
            string fullFilename = Path.Combine(ConfigOptions.CppOutputDir, filename);

            using (var writer = new SourceWriter(fullFilename))
            {
                string deffilename = string.Format("__{0}__", filename.Replace('.', '_').ToUpper());

                writer.WriteLine("#ifndef {0}", deffilename);
                writer.WriteLine("#define {0}", deffilename);
                writer.WriteLine();
                writer.WriteLine("#include <InvisionHandle.h>");
                writer.WriteLine("#include \"{0}\"", ConfigOptions.IncludeCppHeader);

                //foreach (string include in ScanIncludes())
                //{
                //    writer.WriteLine("#include \"{0}\"", include);
                //}

                writer.WriteLine();

                writer.WriteLine("extern \"C\"");
                writer.OpenBlock();
                {
                    GenerateType(writer, cppTypename);
                }
                writer.CloseBlock();
                writer.WriteLine();
                writer.WriteLine("#endif // {0}", deffilename);
                writer.WriteLine();
            }

            return filename;
        }

        /// <summary>
        /// Gets the typename.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetTypename()
        {
            return ConfigOptions.GetCppTypename(Type);
        }

        /// <summary>
        /// Scans the includes.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<string> ScanIncludes()
        {
            IEnumerable<PropertyInfo> properties = ReflectionUtility.GetProperties(Type);

            return
                from propertyInfo in properties
                where propertyInfo.PropertyType.HasAttribute<ValueObjectAttribute>(true)
                select ConfigOptions.GetCppTypename(propertyInfo.PropertyType) into cppTypename
                select ConfigOptions.AdditionalInclude(cppTypename);
        }

        /// <summary>
        /// Generates the type.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="cppTypename"></param>
        protected abstract void GenerateType(SourceWriter writer, string cppTypename);

        /// <summary>
        /// Writes the field.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="fieldInfo">The field info.</param>
        protected void WriteField(SourceWriter writer, FieldInfo fieldInfo)
        {
            Type fieldType = fieldInfo.FieldType;

            string fieldName = fieldInfo.Name;
            string translatedType = ConfigOptions.TranslateType(fieldInfo, fieldType);

            WriteField(writer, fieldName, translatedType);
        }

        /// <summary>
        /// Writes the field.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="translatedType">Type of the translated.</param>
        protected void WriteField(SourceWriter writer, string fieldName, string translatedType)
        {
            fieldName = ConfigOptions.GetFieldName(fieldName);

            writer.WriteLine("{0} {1};", translatedType, fieldName);
        }
    }
}
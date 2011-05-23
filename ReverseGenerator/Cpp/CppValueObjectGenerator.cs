using System;
using System.Reflection;
using InVision.Extensions;
using InVision.Native;

namespace ReverseGenerator.Cpp
{
    public class CppValueObjectGenerator : CppValueObjectGeneratorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CppValueObjectGenerator"/> class.
        /// </summary>
        /// <param name="configOptions">The options.</param>
        /// <param name="type">The type.</param>
        public CppValueObjectGenerator(ConfigOptions configOptions, Type type)
            : base(configOptions, type)
        {
        }

        /// <summary>
        /// Generates the type.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="cppTypename"></param>
        protected override void GenerateType(SourceWriter writer, string cppTypename)
        {
            writer.WriteLine("/**");
            writer.WriteLine(" * Type {0}", cppTypename);
            writer.WriteLine(" */");
            writer.WriteLine("struct {0}", cppTypename);
            writer.OpenBlock();
            {
                FieldInfo[] fields =
                    Type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                foreach (FieldInfo fieldInfo in fields)
                {
                    WriteField(writer, fieldInfo);
                }
            }
            writer.CloseBlock(";");
            writer.WriteLine();

            var attribute = Type.GetAttribute<CppValueObjectAttribute>(true);

            if (attribute.IsDescriptor)
            {
                writer.WriteLine("{0} descriptor_of_{1}(InvHandle handle);",
                                 cppTypename,
                                 (attribute.Typename ?? Type.Name.Replace("Descriptor", string.Empty)).ToLower());
                writer.WriteLine();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using CodeGenerator.Cpp;
using InVision.Extensions;
using InVision.Native.Ext;

namespace CodeGenerator.CSharp
{
    public class CSharpBindingsGenerator : CSharpGeneratorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpBindingsGenerator"/> class.
        /// </summary>
        /// <param name="configOptions">The config options.</param>
        public CSharpBindingsGenerator(ConfigOptions configOptions)
            : base(configOptions)
        {
        }

        /// <summary>
        /// Generates the content.
        /// </summary>
        /// <param name="types">The types.</param>
        protected override void GenerateContent(IEnumerable<Type> types)
        {
            IEnumerable<Type> wrapperTypes = types.Where(t => t.HasAttribute<CppWrapperAttribute>(true));

            var defaultNamespaces = new[] {
                                              typeof (DllImportAttribute).Namespace,
                                              typeof (Handle).Namespace
                                          };

            IEnumerable<string> namespacesUsed = types.ScanNamespacesInMethodsOf();
            namespacesUsed = namespacesUsed.Union(defaultNamespaces);
            namespacesUsed = namespacesUsed.OrderBy(ns => ns, new NamespaceComparer());

            foreach (string namespaceUsed in namespacesUsed)
            {
                Writer.WriteLine("using {0};", namespaceUsed);
            }

            Writer.WriteLine();

            IEnumerable<IGrouping<string, Type>> groupedTypes = wrapperTypes.GroupBy(t => t.Namespace);

            foreach (var typeGroup in groupedTypes)
            {
                Writer.WriteLine("namespace {0}", typeGroup.Key);
                Writer.OpenBlock();
                {
                    foreach (Type wrapperType in typeGroup)
                    {
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
            Writer.WriteLine("internal static class Cpp{0}", wrapperType.Name.Substring(1));
            Writer.OpenBlock();
            {
                Writer.WriteLine("public const string Library = \"{0}.dll\";", ConfigOptions.ProjectName);

                foreach (MethodInfo method in ReflectionUtility.GetMethods(wrapperType))
                {
                    Writer.WriteLine();
                    WriteMethod(method);
                }
            }
            Writer.CloseBlock();
        }

        /// <summary>
        /// Writes the method.
        /// </summary>
        /// <param name="method">The method.</param>
        private void WriteMethod(MethodInfo method)
        {
            WriteAttributes(method);
            WriteMethodSignature(method);
        }

        /// <summary>
        /// Writes the attributes.
        /// </summary>
        /// <param name="method">The method.</param>
        private void WriteAttributes(MethodInfo method)
        {
            Writer.WriteLine(
                "[DllImport(Library, EntryPoint = \"{0}\")]",
                CppHeaderGenerator.GetExternalMethodName(method));

            var marshalAsAttribute = method.ReturnParameter.GetAttribute<MarshalAsAttribute>(true);

            if (marshalAsAttribute != null)
                Writer.WriteLine(BuildMarshalAsAttribute(marshalAsAttribute, true));
        }

        /// <summary>
        /// Builds the marshal as attribute.
        /// </summary>
        /// <param name="marshalAsAttribute">The marshal as attribute.</param>
        /// <param name="isReturn">if set to <c>true</c> [is return].</param>
        /// <returns></returns>
        public static string BuildMarshalAsAttribute(MarshalAsAttribute marshalAsAttribute, bool isReturn)
        {
            var builder = new StringBuilder();

            builder.AppendFormat("[{0}MarshalAs(", isReturn ? "return: " : string.Empty);
            builder.AppendFormat("UnmanagedType.{0}", marshalAsAttribute.Value);

            if (marshalAsAttribute.SizeConst != 0)
                builder.AppendFormat(", SizeConst = {0}", marshalAsAttribute.SizeConst);

            if (marshalAsAttribute.Value == UnmanagedType.CustomMarshaler)
                builder.AppendFormat(", MarshalTypeRef = typeof({0})", marshalAsAttribute.MarshalTypeRef);

            if (marshalAsAttribute.ArraySubType != default(UnmanagedType))
                builder.AppendFormat(", ArraySubType = UnmanagedType.{0}", marshalAsAttribute.ArraySubType);

            builder.Append(")]");

            return builder.ToString();
        }

        /// <summary>
        /// Writes the method signature.
        /// </summary>
        /// <param name="method">The method.</param>
        private void WriteMethodSignature(MethodInfo method)
        {
            string returnType = ConfigOptions.GetCSharpTypeString(method.ReturnType);

            if (method.HasAttribute<ConstructorAttribute>())
                returnType = ConfigOptions.GetCSharpWrapperDescriptorTypename(method.DeclaringType);

            Writer.BeginLine();
            Writer.Write("public static extern {0} {1}(",
                         returnType,
                         method.Name);

            ParameterInfo[] parameters = method.GetParameters();
            bool firstParam = true;
            bool isNonStaticMethod = method.QueryAttribute<MethodAttribute>(attr => !attr.IsStatic);
            bool isDestructor = method.HasAttribute<DestructorAttribute>();
            bool longParameters = (parameters.Length + (isNonStaticMethod ? 1 : 0)) > 1;

            if (longParameters)
            {
                Writer.Write(Writer.NewLine);
                Writer.Indent();
                Writer.BeginLine();
            }

            if (isNonStaticMethod || isDestructor)
            {
                firstParam = false;
                Writer.Write("Handle self");
            }

            foreach (ParameterInfo parameter in parameters)
            {
                if (firstParam)
                    firstParam = false;
                else
                {
                    Writer.Write(", ");

                    if (longParameters)
                    {
                        Writer.Write(Writer.NewLine);
                        Writer.BeginLine();
                    }
                }

                var marshalAsAttribute = parameter.GetAttribute<MarshalAsAttribute>(true);

                if (marshalAsAttribute != null)
                {
                    Writer.Write(BuildMarshalAsAttribute(marshalAsAttribute, false));
                    Writer.Write(" ");
                }

                string paramModification = ConfigOptions.GetCSharpParameterModification(parameter);

                Writer.Write("{0}{1} {2}",
                             string.IsNullOrEmpty(paramModification)
                                 ? string.Empty
                                 : string.Format("{0} ", paramModification),
                             ConfigOptions.GetCSharpTypeString(parameter.ParameterType),
                             parameter.Name);
            }

            Writer.Write(");{0}", Writer.NewLine);

            if (longParameters)
                Writer.Deindent();
        }
    }
}
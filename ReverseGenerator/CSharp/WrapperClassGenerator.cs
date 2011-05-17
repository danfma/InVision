using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native.Ext;

namespace CodeGenerator.CSharp
{
    public class WrapperClassGenerator : CSharpGeneratorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrapperClassGenerator"/> class.
        /// </summary>
        /// <param name="configOptions">The config options.</param>
        public WrapperClassGenerator(ConfigOptions configOptions) : base(configOptions)
        {
        }

        /// <summary>
        /// Generates the content.
        /// </summary>
        /// <param name="types">The types.</param>
        protected override void GenerateContent(IEnumerable<Type> types)
        {
            IEnumerable<Type> wrapperTypes = types.Where(t => t.HasAttribute<CppInterfaceAttribute>(true));

            var defaultNamespaces = new[] {
                                              typeof (Handle).Namespace
                                          };

            IEnumerable<string> namespacesUsed = types.ScanNamespacesInMethodsOf();
            namespacesUsed = namespacesUsed.Union(types.ScanNamespacesInProperties());
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
            string typeName = wrapperType.Name.Substring(1);
            Type baseType = GetBaseType(wrapperType);
            IEnumerable<Type> interfaces = GetInterfaces(wrapperType);

            bool hasBaseType = baseType != null;
            bool hasInterfaces = interfaces.Count() > 0;

            Writer.WriteLine("public {0}partial class {1}",
                IsAbstract(wrapperType) ? "abstract " : string.Empty,
                typeName);

            WriteInheritance(baseType, interfaces, hasBaseType, hasInterfaces);

            Writer.OpenBlock();
            {
                WriteFields(wrapperType);
                WriteConstructors(wrapperType);
                WriteDestructor(wrapperType);
                WriteProperties(wrapperType);
                WriteMethods(wrapperType);
            }
            Writer.CloseBlock();
        }

        /// <summary>
        /// Determines whether the specified type is abstract.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if the specified type is abstract; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAbstract(Type type)
        {
            return type.QueryAttribute<CppInterfaceAttribute>(attr => attr.IsAbstract);
        }

        /// <summary>
        /// Writes the fields.
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        private void WriteFields(Type wrapperType)
        {
            IEnumerable<PropertyInfo> properties =
                ReflectionUtility.GetProperties(wrapperType).Where(p => p.HasAttribute<FieldAttribute>());

            foreach (PropertyInfo property in properties)
            {
                Writer.WriteLine("private unsafe {0}* {1};", property.PropertyType.Name,
                                  property.Name.ToUnderscoredCamelCase());
            }

            Writer.WriteLine();
        }

        /// <summary>
        /// Writes the constructors.
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        private void WriteConstructors(Type wrapperType)
        {
            string typename = wrapperType.Name.Substring(1).ToPascalCase();

            Writer.WriteLine("protected {0}(Handle handle, bool ownsHandle)", typename);
            Writer.WriteLine("\t: base(handle, ownsHandle)");
            Writer.WriteLine("{ }");
            Writer.WriteLine();

            Writer.WriteLine("public {0}({0}Descriptor descriptor, bool ownsHandle)", typename);
            Writer.WriteLine("\t: this(descriptor.Self, ownsHandle)");
            Writer.OpenBlock();

            IEnumerable<PropertyInfo> properties =
                ReflectionUtility.GetProperties(wrapperType).Where(p => p.HasAttribute<FieldAttribute>());

            foreach (PropertyInfo property in properties)
            {
                Writer.WriteLine("{0} = descriptor.{1};",
                                  property.Name.ToUnderscoredCamelCase(),
                                  property.Name);
            }

            Writer.CloseBlock();
            Writer.WriteLine();

            IEnumerable<MethodInfo> constructors = ReflectionUtility.GetMethods(wrapperType).
                Where(m => m.HasAttribute<ConstructorAttribute>());

            foreach (MethodInfo constructor in constructors)
            {
                ParameterInfo[] parameters = constructor.GetParameters();
                
                string parametersDef =
                    (from p in parameters
                     let paramModification = ConfigOptions.GetCSharpParameterModification(p)
                     select string.Format(
                         "{0}{1} {2}",
                         string.IsNullOrEmpty(paramModification) ? paramModification : paramModification + " ",
                         ConfigOptions.GetCSharpTypeString(p.ParameterType),
                         p.Name)).Join(", ");

                string parametersList = parameters.Select(p => p.Name).Join(", ");

                Writer.WriteLine("public {0}({1})", typename, parametersDef);
                Writer.WriteLine("\t: this(Cpp{0}.New({1}), true)", typename, parametersList);
                Writer.WriteLine("{ }");
                Writer.WriteLine();
            }
        }

        /// <summary>
        /// Writes the destructor.
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        private void WriteDestructor(Type wrapperType)
        {
            bool hasDestructor = HasDestructor(wrapperType);
            bool hasBaseType = HasBaseType(wrapperType);

            if (!hasDestructor && hasBaseType)
                return;

            Writer.WriteLine("protected override void DeleteHandle()");
            Writer.OpenBlock();
            {
                if (hasDestructor)
                    Writer.WriteLine("Cpp{0}.Delete(Self);", wrapperType.Name.Substring(1).ToPascalCase());
            }
            Writer.CloseBlock();
            Writer.WriteLine();
        }

        /// <summary>
        /// Determines whether [has base type] [the specified wrapper type].
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        /// <returns>
        /// 	<c>true</c> if [has base type] [the specified wrapper type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasBaseType(Type wrapperType)
        {
            return GetBaseType(wrapperType) != null;
        }

        /// <summary>
        /// Determines whether the specified wrapper type has destructor.
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        /// <returns>
        /// 	<c>true</c> if the specified wrapper type has destructor; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasDestructor(Type wrapperType)
        {
            return ReflectionUtility.GetMethods(wrapperType).
                Where(m => m.HasAttribute<DestructorAttribute>(false)).Any();
        }

        /// <summary>
        /// Writes the properties.
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        private void WriteProperties(Type wrapperType)
        {
            string typename = wrapperType.Name.Substring(1).ToPascalCase();
            IEnumerable<PropertyInfo> properties =
                ReflectionUtility.GetProperties(wrapperType).Where(p => p.HasAttribute<FieldAttribute>());

            foreach (PropertyInfo property in properties)
            {
                Writer.WriteLine("public {0} {1}", property.PropertyType.Name, property.Name);
                Writer.OpenBlock();
                {
                    if (property.CanRead)
                        Writer.WriteLine("get {{ unsafe {{ return *{0}; }} }}", property.Name.ToUnderscoredCamelCase());

                    if (property.CanWrite)
                        Writer.WriteLine("set {{ unsafe {{ *{0} = value; }} }}", property.Name.ToUnderscoredCamelCase());
                }
                Writer.CloseBlock();
                Writer.WriteLine();
            }

            IEnumerable<IGrouping<string, MethodInfo>> groupedMethods =
                from m in ReflectionUtility.GetMethods(wrapperType)
                let attr = m.GetAttribute<MethodAttribute>(true)
                where attr != null && !string.IsNullOrEmpty(attr.Property)
                group m by attr.Property
                    into g
                    select g;

            foreach (var group in groupedMethods)
            {
                if (group.Count() > 2)
                    throw new InvalidOperationException(
                        "Only two methods (a setter and one getter) can be selected to form a property");

                MethodInfo firstMethod = group.First();
                MethodInfo getter = group.Where(m => m.ReturnType != typeof(void)).SingleOrDefault();
                MethodInfo setter = group.Where(m => m.ReturnType == typeof(void)).SingleOrDefault();
                Type propertyType;

                if (getter != null)
                    propertyType = firstMethod.ReturnType;
                else
                    propertyType = firstMethod.GetParameters().Single().ParameterType;

                Writer.WriteLine("public {0} {1}", propertyType.Name, group.Key);
                Writer.OpenBlock();
                {
                    if (getter != null)
                        Writer.WriteLine("get {{ return Cpp{0}.{1}(); }}", typename, getter.Name);

                    if (setter != null)
                        Writer.WriteLine("set {{ Cpp{0}.{1}(value); }}", typename, setter.Name);
                }
                Writer.CloseBlock();
                Writer.WriteLine();
            }
        }

        /// <summary>
        /// Writes the methods.
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        private void WriteMethods(Type wrapperType)
        {
            string typename = wrapperType.Name.Substring(1).ToPascalCase();
            IEnumerable<MethodInfo> methods = ReflectionUtility.GetMethods(wrapperType).
                Where(m => m.QueryAttribute<MethodAttribute>(attr => string.IsNullOrEmpty(attr.Property)));

            foreach (MethodInfo method in methods)
            {
                var methodAttr = method.GetAttribute<MethodAttribute>(true);
                ParameterInfo[] parameters = method.GetParameters();
                
                string parametersDef =
                    (from p in parameters
                     let paramModification = ConfigOptions.GetCSharpParameterModification(p)
                     select string.Format(
                         "{0}{1} {2}",
                         string.IsNullOrEmpty(paramModification) ? paramModification : paramModification + " ",
                         ConfigOptions.GetCSharpTypeString(p.ParameterType),
                         p.Name)).Join(", ");

                string parametersList = parameters.Select(p => p.Name).Join(", ");

                bool returnVoid = method.ReturnType == typeof(void);

                Writer.WriteLine("public {0}{1} {2}({3})",
                                  methodAttr.IsStatic ? "static " : string.Empty,
                                  ConfigOptions.GetCSharpTypeString(method.ReturnType),
                                  method.Name,
                                  parametersDef);

                Writer.OpenBlock();
                {
                    if (!methodAttr.IsStatic)
                    {
                        parametersList = string.Format("Self{0}{1}",
                                                       parameters.Length > 0 ? ", " : string.Empty,
                                                       parametersList);
                    }

                    Writer.WriteLine("{0}Cpp{1}.{2}({3});",
                                      returnVoid ? string.Empty : "return ",
                                      typename,
                                      method.Name,
                                      parametersList);
                }
                Writer.CloseBlock();
                Writer.WriteLine();
            }
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

            if (hasBaseType)
            {
                Writer.BeginLine();
                Writer.Write(": {0}", baseType.Name.Substring(1));
            }
            else
            {
                Writer.BeginLine();
                Writer.Write(": HandleContainer");
            }

            if (hasInterfaces)
            {
                Writer.Write(", ");

                bool first = true;

                foreach (Type @interface in interfaces)
                {
                    if (first)
                        first = false;
                    else
                        Writer.Write(", ");

                    Writer.Write(@interface.Name);
                }
            }

            Writer.Write(Writer.NewLine);
            Writer.Deindent();
        }

        public static Type GetBaseType(Type wrapperType)
        {
            return wrapperType.GetInterfaces().
                Where(@interface => @interface.QueryAttribute<CppInterfaceAttribute>(
                    attr => attr.InheritanceBy == InherintanceMode.BaseType)).
                SingleOrDefault();
        }

        /// <summary>
        /// Gets the interfaces.
        /// </summary>
        /// <param name="wrapperType">Type of the wrapper.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfaces(Type wrapperType)
        {
            return wrapperType.GetInterfaces().
                Where(@interface => @interface.QueryAttribute<CppInterfaceAttribute>(
                    attr => attr.InheritanceBy == InherintanceMode.Interface));
        }
    }
}
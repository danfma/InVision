using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native.Ext;

namespace CodeGenerator.CSharp
{
    public class CSharpCppInstanceGenerator : CSharpGeneratorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpCppInstanceGenerator"/> class.
        /// </summary>
        /// <param name="configOptions">The config options.</param>
        public CSharpCppInstanceGenerator(ConfigOptions configOptions)
            : base(configOptions)
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
            string typeName = ConfigOptions.GetCSharpCppInstanceTypename(wrapperType);
            Type baseType = GetBaseType(wrapperType);
            IEnumerable<Type> interfaces = GetInterfaces(wrapperType, true);

            bool hasBaseType = baseType != null;
            bool hasInterfaces = interfaces.Count() > 0;

			Writer.WriteLine("[CppImplementation(typeof({0}))]", wrapperType.Name);
            Writer.WriteLine("internal class {0}", typeName);

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

                Writer.WriteLine("{0} {0}.{1}({2})", 
					wrapperType.Name, 
					constructor.Name, 
					parametersDef);

                Writer.OpenBlock();
            	{
            		Writer.WriteLine("Self = {0}.{1}({2});", 
						CodeGenerator.ConfigOptions.GetCSharpNativeTypename(wrapperType),
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
            bool hasDestructor = HasDestructor(wrapperType);
            bool hasBaseType = HasBaseType(wrapperType);

            if (!hasDestructor && hasBaseType)
                return;

        	var destructor = GetDestructor(wrapperType);

            Writer.WriteLine("{0} {1}.{2}()", 
				CodeGenerator.ConfigOptions.GetCSharpTypeString(destructor.ReturnType),
				wrapperType.Name,
				destructor.Name);

            Writer.OpenBlock();
            {
                if (hasDestructor)
                {
                	Writer.WriteLine("{0}.{1}(Self);", 
                		CodeGenerator.ConfigOptions.GetCSharpNativeTypename(wrapperType),
						destructor.Name);
                }
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
            return FindDestructor(wrapperType).Any();
        }

		public static MethodInfo GetDestructor(Type wrapperType)
		{
			return FindDestructor(wrapperType).SingleOrDefault();
		}

    	private static IEnumerable<MethodInfo> FindDestructor(Type wrapperType)
    	{
    		return ReflectionUtility.GetMethods(wrapperType).Where(m => m.HasAttribute<DestructorAttribute>(false));
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

                Writer.WriteLine("{0} {1}.{2}({3})",
                                 ConfigOptions.GetCSharpTypeString(method.ReturnType),
								 wrapperType.Name,
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

                    Writer.WriteLine("{0}{1}.{2}({3});",
                                     returnVoid ? string.Empty : "return ",
                                     CodeGenerator.ConfigOptions.GetCSharpNativeTypename(wrapperType),
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
                Writer.Write(": {0}", CodeGenerator.ConfigOptions.GetCSharpCppInstanceTypename(baseType));
            }
            else
            {
                Writer.BeginLine();
                Writer.Write(": CppInstance");
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
        	return ConfigOptions.GetCppInstanceBaseType(wrapperType);
        }

        public static IEnumerable<Type> GetInterfaces(Type wrapperType, bool includeWrapperType)
        {
        	var baseType = GetBaseType(wrapperType);

            var @interfaces = 
				wrapperType.GetInterfaces().
                Where(@interface => @interface.HasAttribute<CppInterfaceAttribute>() && @interface != baseType);

			if (includeWrapperType)
				yield return wrapperType;

        	foreach (var @interface in interfaces)
        	{
        		yield return @interface;
        	}
        }
    }
}
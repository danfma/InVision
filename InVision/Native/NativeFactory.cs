using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using InVision.Extensions;

namespace InVision.Native
{
    public static class NativeFactory
    {
        private static readonly ConcurrentDictionary<Type, Type> TypeInstances;
        private static readonly ConcurrentDictionary<Type, object> SharedInstances;

        /// <summary>
        /// Initializes the <see cref="NativeFactory"/> class.
        /// </summary>
        static NativeFactory()
        {
            TypeInstances = new ConcurrentDictionary<Type, Type>();
            SharedInstances = new ConcurrentDictionary<Type, object>();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>()
        {
            Type type = TypeInstances.GetOrAdd(typeof(T), SearchImplementationType);

            return type.CreateInstance<T>();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return (T)SharedInstances.GetOrAdd(typeof(T), CreateSharedInstance);
        }

        /// <summary>
        /// Creates the shared instance.
        /// </summary>
        /// <param name="interfaceType">The type.</param>
        /// <returns></returns>
        private static object CreateSharedInstance(Type interfaceType)
        {
            var implType = SearchImplementationType(interfaceType);

            return Activator.CreateInstance(implType);
        }

        /// <summary>
        /// Searches the type of the implementation.
        /// </summary>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns></returns>
        private static Type SearchImplementationType(Type interfaceType)
        {
            var targetAssembly = interfaceType.Assembly.GetName().Name + ".Native";

            var query =
                from t in Assembly.Load(targetAssembly).GetTypes()
                where t.QueryAttribute<CppImplementationAttribute>(a => a.TargetInterface == interfaceType)
                select t;

            return query.First();
        }
    }
}
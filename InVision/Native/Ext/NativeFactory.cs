using System;
using System.Collections.Concurrent;
using System.Linq;
using InVision.Extensions;

namespace InVision.Native.Ext
{
    public static class NativeFactory
    {
        private static readonly ConcurrentDictionary<Type, Type> TypeInstances;

        /// <summary>
        /// Initializes the <see cref="NativeFactory"/> class.
        /// </summary>
        static NativeFactory()
        {
            TypeInstances = new ConcurrentDictionary<Type, Type>();
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
        /// Searches the type of the implementation.
        /// </summary>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns></returns>
        private static Type SearchImplementationType(Type interfaceType)
        {
            var query =
                from t in interfaceType.Assembly.GetTypes()
                where t.QueryAttribute<CppImplementationAttribute>(a => a.TargetInterface == interfaceType)
                select t;

            return query.First();
        }
    }
}
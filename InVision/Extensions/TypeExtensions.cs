using System;
using System.Reflection;

namespace InVision.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		public static object CreateInstance(this Type type, params object[] args)
		{
			return Activator.CreateInstance(type, args);
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		public static T CreateInstance<T>(this Type type, params object[] args)
		{
			return (T)CreateInstance(type, args);
		}

		/// <summary>
		/// Determines whether the specified type has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <param name="inherit">if set to <c>true</c> [inherit].</param>
		/// <returns>
		/// 	<c>true</c> if the specified type has attribute; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasAttribute<T>(this ICustomAttributeProvider type, bool inherit) where T : Attribute
		{
			return type.IsDefined(typeof(T), inherit);
		}

		/// <summary>
		/// Determines whether the specified type has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <returns>
		/// 	<c>true</c> if the specified type has attribute; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasAttribute<T>(this ICustomAttributeProvider type) where T : Attribute
		{
			return HasAttribute<T>(type, false);
		}

		/// <summary>
		/// Determines whether the specified type has interface.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <returns>
		/// 	<c>true</c> if the specified type has interface; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasInterface<T>(this Type type)
		{
			return HasInterface(type, typeof(T));
		}

		/// <summary>
		/// Determines whether the specified type has interface.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="interfaceName">Name of the interface.</param>
		/// <returns>
		/// 	<c>true</c> if the specified type has interface; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasInterface(this Type type, string interfaceName)
		{
			return type.GetInterface(interfaceName) != null;
		}

		/// <summary>
		/// Determines whether the specified type has interface.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="interfaceType">Type of the interface.</param>
		/// <returns>
		/// 	<c>true</c> if the specified type has interface; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasInterface(this Type type, Type interfaceType)
		{
			return type.GetInterface(interfaceType.FullName) != null;
		}
	}
}
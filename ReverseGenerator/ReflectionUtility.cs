using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native;

namespace ReverseGenerator
{
	public static class ReflectionUtility
	{
		private const BindingFlags DefaultPropertyFlags =
			BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

		private const BindingFlags DefaultMethodFlags =
			BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

		/// <summary>
		/// Scans the namespaces in methods.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="flags">The flags.</param>
		/// <returns></returns>
		public static IEnumerable<string> ScanNamespacesInMethods(this Type type,
																  BindingFlags flags = DefaultMethodFlags)
		{
			var nsSet = new HashSet<string>();

			nsSet.Add(type.Namespace);

			foreach (MethodInfo method in type.GetMethods(flags))
			{
				nsSet.Add(method.ReturnType.Namespace);

				foreach (ParameterInfo parameterInfo in method.GetParameters())
				{
					nsSet.Add(parameterInfo.ParameterType.Namespace);
				}
			}

			return nsSet;
		}

		/// <summary>
		/// Scans the namespaces in methods of.
		/// </summary>
		/// <param name="types">The types.</param>
		/// <returns></returns>
		public static IEnumerable<string> ScanNamespacesInMethodsOf(this IEnumerable<Type> types)
		{
			var set = new HashSet<string>();

			foreach (Type type in types)
			{
				foreach (string namespaceInMethod in ScanNamespacesInMethods(type))
				{
					set.Add(namespaceInMethod);
				}
			}

			return set;
		}

		/// <summary>
		/// Scans the namespaces in properties.
		/// </summary>
		/// <param name="types">The types.</param>
		/// <returns></returns>
		public static IEnumerable<string> ScanNamespacesInProperties(this IEnumerable<Type> types)
		{
			var set = new HashSet<string>();

			foreach (Type type in types)
			{
				foreach (PropertyInfo property in GetProperties(type))
				{
					set.Add(property.PropertyType.Namespace);
				}
			}

			return set;
		}

		/// <summary>
		/// Gets the properties.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="bindingFlags">The binding flags.</param>
		/// <returns></returns>
		public static IEnumerable<PropertyInfo> GetProperties(this Type type,
															  BindingFlags bindingFlags = DefaultPropertyFlags)
		{
			return type.GetProperties(bindingFlags);
		}

		/// <summary>
		/// Gets the methods.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="bindingFlags">The binding flags.</param>
		/// <param name="includeInterfaces">if set to <c>true</c> [include interfaces].</param>
		/// <returns></returns>
		public static IEnumerable<MethodInfo> GetMethods(this Type type, BindingFlags bindingFlags = DefaultMethodFlags, bool includeInterfaces = false)
		{
			var methods = type.GetMethods(bindingFlags).Where(method => !method.IsPropertyMember());

			foreach (var method in methods)
			{
				yield return method;
			}

			var interfaces =
				from @interface in type.GetInterfaces()
				where @interface.QueryAttribute<CppInterfaceAttribute>(t => t.CppInterfaceType == CppInterfaceType.Interface)
				select @interface;

			foreach (var @interface in interfaces)
			{
				foreach (var method in GetMethods(@interface, includeInterfaces: includeInterfaces))
				{
					yield return method;
				}
			}
		}

		/// <summary>
		/// Gets the fields.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="bindingFlags">The binding flags.</param>
		/// <returns></returns>
		public static IEnumerable<FieldInfo> GetFields(Type type, BindingFlags bindingFlags = DefaultPropertyFlags)
		{
			return type.GetFields(bindingFlags);
		}
	}
}
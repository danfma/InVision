using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InVision.Extensions
{
	public static class CustomAttributeProviderExtensions
	{
		/// <summary>
		/// Gets the attribute.
		/// </summary>
		/// <typeparam name="TAttribute">The type of the attribute.</typeparam>
		/// <param name="this">The @this.</param>
		/// <param name="inherited">if set to <c>true</c> [inherited].</param>
		/// <returns></returns>
		public static TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider @this, bool inherited)
				where TAttribute : Attribute
		{			
			return @this.GetCustomAttributes(typeof(TAttribute), inherited).
					Cast<TAttribute>().FirstOrDefault();
		}

		/// <summary>
		/// Gets the attributes.
		/// </summary>
		/// <typeparam name="TAttribute">The type of the attribute.</typeparam>
		/// <param name="this">The @this.</param>
		/// <param name="inherited">if set to <c>true</c> [inherited].</param>
		/// <returns></returns>
		public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this ICustomAttributeProvider @this, bool inherited = false)
			where TAttribute : Attribute
		{
			return @this.GetCustomAttributes(typeof(TAttribute), inherited).Cast<TAttribute>();
		}

		/// <summary>
		/// Determines whether [is marked with] [the specified @this].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The @this.</param>
		/// <param name="inherit">if set to <c>true</c> [inherit].</param>
		/// <returns>
		/// 	<c>true</c> if [is marked with] [the specified @this]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsMarkedWith<T>(this ICustomAttributeProvider @this, bool inherit)
			where T : Attribute
		{
			return @this.IsDefined(typeof(T), inherit);
		}

		/// <summary>
		/// Determines whether [is marked with] [the specified @this].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The @this.</param>
		/// <returns>
		/// 	<c>true</c> if [is marked with] [the specified @this]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsMarkedWith<T>(this ICustomAttributeProvider @this)
			where T : Attribute
		{
			return IsMarkedWith<T>(@this, false);
		}
	}
}
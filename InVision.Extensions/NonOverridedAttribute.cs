using System;
using System.Linq.Expressions;

namespace InVision.Extensions
{
	/// <summary>
	/// Internal use (do not use this in proxies methods).
	/// 
	/// This attribute mark a method as a not overrided one, so the proxy does not update the
	/// vtable of the method on the unmanaged side.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class NonOverridedAttribute : Attribute
	{
		/// <summary>
		/// Determines whether [is found on] [the specified action].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="action">The action.</param>
		/// <param name="targetType">Type of the target.</param>
		/// <returns>
		/// 	<c>true</c> if [is found on] [the specified action]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsFoundOn<T>(Expression<Action<T>> action, Type targetType)
		{
			string member = action.GetMemberName();

			return targetType.GetMethod(member).HasAttribute<NonOverridedAttribute>(false);
		}

		/// <summary>
		/// Determines whether [is found on] [the specified action].
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="targetType">Type of the target.</param>
		/// <returns>
		/// 	<c>true</c> if [is found on] [the specified action]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsFoundOn(Expression<Action> action, Type targetType)
		{
			string member = action.GetMemberName();

			return targetType.GetMethod(member).HasAttribute<NonOverridedAttribute>(false);
		}
	}
}
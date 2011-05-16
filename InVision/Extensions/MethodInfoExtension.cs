using System.Reflection;

namespace InVision.Extensions
{
	public static class MethodInfoExtension
	{
		/// <summary>
		/// Determines whether [is property method] [the specified method].
		/// </summary>
		/// <param name="method">The method.</param>
		/// <returns>
		/// 	<c>true</c> if [is property method] [the specified method]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPropertyMember(this MethodInfo method)
		{
			return method.IsSpecialName &&
				(method.Name.StartsWith("get_") || method.Name.StartsWith("set_"));
		}
	}
}
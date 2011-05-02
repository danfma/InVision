using System.Reflection;

namespace InVision.Extensions
{
	public static class PropertyInfoExtensions
	{
		/// <summary>
		/// Determines whether [has get method public] [the specified property info].
		/// </summary>
		/// <param name="propertyInfo">The property info.</param>
		/// <returns>
		/// 	<c>true</c> if [has get method public] [the specified property info]; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasGetMethodPublic(this PropertyInfo propertyInfo)
		{
			return propertyInfo.GetGetMethod(false) != null;
		}

		/// <summary>
		/// Determines whether [has set method public] [the specified property info].
		/// </summary>
		/// <param name="propertyInfo">The property info.</param>
		/// <returns>
		/// 	<c>true</c> if [has set method public] [the specified property info]; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasSetMethodPublic(this PropertyInfo propertyInfo)
		{
			return propertyInfo.GetSetMethod(false) != null;
		}
	}
}
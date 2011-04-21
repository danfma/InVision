namespace InVision.Extensions
{
	public static class ObjectExtensions
	{
		/// <summary>
		/// Casts the specified obj.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="obj">The obj.</param>
		/// <returns></returns>
		public static U Cast<T, U>(this T obj)
			where T : U
		{
			return obj;
		}
	}
}
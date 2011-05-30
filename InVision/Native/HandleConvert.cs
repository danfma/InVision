namespace InVision.Native
{
	public static class HandleConvert
	{
		/// <summary>
		/// Toes the handle.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static Handle ToHandle<T>(T data) where T : ICppInstance
		{
			if (Equals(data, default(T)))
				return Handle.Invalid;

			return data.Self;
		}

		/// <summary>
		/// Froms the handle.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="handle">The handle.</param>
		/// <returns></returns>
		public static T FromHandle<T>(Handle handle) where T : ICppInstance
		{
			if (!handle.IsValid)
				return default(T);

			var impl = NativeFactory.Create<T>();
			impl.Self = handle;

			return impl;
		}
	}
}
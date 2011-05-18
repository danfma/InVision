namespace InVision.Native.Ext
{
	public abstract class CppWrapper : DisposableObject
	{
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
		}

		/// <summary>
		/// Creates the instance of the native object for wrap.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		protected static T CreateCppInstance<T>()
		{
			return NativeFactory.Create<T>();
		}
	}
}
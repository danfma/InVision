namespace InVision.Native.Ext
{
	public abstract class CppWrapper : DisposableObject
	{
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
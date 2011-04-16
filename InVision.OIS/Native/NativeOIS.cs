using InVision.Native;

namespace InVision.OIS.Native
{
	internal class NativeOIS : PlatformInvoke
	{
		public const string OISLibrary = "InVisionNative_OIS.dll";

		/// <summary>
		/// Initializes the <see cref="NativeOIS"/> class.
		/// </summary>
		static NativeOIS()
		{
			Init();
		}
	}
}
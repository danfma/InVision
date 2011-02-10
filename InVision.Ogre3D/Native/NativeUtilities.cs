using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal static class NativeUtilities
	{
		[DllImport(PlatformInvoke.Library, EntryPoint = "UDeleteString")]
		public static extern void DeleteString(IntPtr self);

		[DllImport(PlatformInvoke.Library, EntryPoint = "UDeleteNameValuePair")]
		public static extern void DeleteNameValuePair(IntPtr self);
	}
}
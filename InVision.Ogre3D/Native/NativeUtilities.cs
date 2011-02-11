using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal static class NativeUtilities
	{
		[DllImport(PlatformInvoke.Library, EntryPoint = "util_delete_string")]
		public static extern void DeleteString(IntPtr self);

		[DllImport(PlatformInvoke.Library, EntryPoint = "util_delete_namevaluepair")]
		public static extern void DeleteNameValuePair(IntPtr self);
	}
}
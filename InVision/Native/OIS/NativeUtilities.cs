using System;
using System.Runtime.InteropServices;

namespace InVision.Native.OIS
{
	internal sealed class NativeUtilities : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_delete_deviceinfo")]
		public static extern void DeleteDeviceInfo(IntPtr pDeviceInfo);
	}
}
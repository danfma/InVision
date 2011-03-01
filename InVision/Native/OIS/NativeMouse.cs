using System;
using System.Runtime.InteropServices;

namespace InVision.Native.OIS
{
	internal class NativeMouse : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_mouse_set_event_callback")]
		public static extern void SetEventCallback(IntPtr self, IntPtr mouseListener);
	}
}
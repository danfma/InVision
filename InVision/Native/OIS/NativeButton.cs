using System;
using System.Runtime.InteropServices;

namespace InVision.Native.OIS
{
	internal sealed class NativeButton : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_button_new")]
		public static extern IntPtr New();

		[DllImport(Library, EntryPoint = "ois_button_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_button_get_pushed")]
		public static extern bool GetPushed(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_button_set_pushed")]
		public static extern void SetPushed(IntPtr self, bool value);
	}
}
using System;
using System.Runtime.InteropServices;

namespace InVision.Native.OIS
{
	internal sealed class NativeAxis : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_axis_new")]
		public static extern IntPtr New();

		[DllImport(Library, EntryPoint = "ois_axis_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_axis_get_absolute")]
		public static extern int GetAbsolute(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_axis_set_absolute")]
		public static extern void SetAbsolute(IntPtr self, int value);

		[DllImport(Library, EntryPoint = "ois_axis_get_relative")]
		public static extern int GetRelative(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_axis_set_relative")]
		public static extern void SetRelative(IntPtr self, int value);

		[DllImport(Library, EntryPoint = "ois_axis_get_absolute_only")]
		public static extern bool GetAbsoluteOnly(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_axis_set_absolute_only")]
		public static extern void SetAbsoluteOnly(IntPtr self, bool value);
	}
}
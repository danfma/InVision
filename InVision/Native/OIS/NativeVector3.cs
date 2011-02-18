using System;
using System.Runtime.InteropServices;

namespace InVision.Native.OIS
{
	internal sealed class NativeVector3 : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_vector3_new")]
		public static extern IntPtr New();

		[DllImport(Library, EntryPoint = "ois_vecto3_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_vector3_get_x")]
		public static extern float GetX(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_vector3_set_x")]
		public static extern void SetX(IntPtr self, float value);

		[DllImport(Library, EntryPoint = "ois_vector3_get_y")]
		public static extern float GetY(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_vector3_set_y")]
		public static extern void SetY(IntPtr self, float value);

		[DllImport(Library, EntryPoint = "ois_vector3_get_z")]
		public static extern float GetZ(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_vector3_set_z")]
		public static extern void SetZ(IntPtr self, float value);
	}
}
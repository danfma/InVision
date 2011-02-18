using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal sealed class NativeMouseState : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_mousestate_get_width")]
		public static extern int GetWidth(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_mousestate_set_width")]
		public static extern void SetWidth(IntPtr self, int value);

		[DllImport(Library, EntryPoint = "ois_mousestate_get_height")]
		public static extern int GetHeight(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_mousestate_set_height")]
		public static extern void SetHeight(IntPtr self, int value);

		[DllImport(Library, EntryPoint = "ois_mousestate_get_buttons")]
		public static extern int GetButtons(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_mousestate_get_axis_x")]
		public static extern IntPtr _GetX(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_mousestate_get_axis_y")]
		public static extern IntPtr _GetY(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_mousestate_get_axis_z")]
		public static extern IntPtr _GetZ(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_mousestate_is_button_down")]
		public static extern bool IsButtonDown(
			IntPtr self,
			[MarshalAs(UnmanagedType.I4)] MouseButton button);

		#region Helpers

		public static AxisComponent GetX(IntPtr self)
		{
			return _GetX(self).AsHandle(ptr => new AxisComponent(ptr, false));
		}

		public static AxisComponent GetY(IntPtr self)
		{
			return _GetY(self).AsHandle(ptr => new AxisComponent(ptr, false));
		}

		public static AxisComponent GetZ(IntPtr self)
		{
			return _GetZ(self).AsHandle(ptr => new AxisComponent(ptr, false));
		}

		#endregion
	}
}
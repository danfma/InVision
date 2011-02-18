using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal class NativeMouse : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_mouse_set_event_callback")]
		public static extern void SetEventCallback(IntPtr self, IntPtr mouseListener);

		[DllImport(Library, EntryPoint = "ois_mouse_get_mouse_state")]
		public static extern IntPtr _GetMouseState(IntPtr self);

		#region Helpers

		public static MouseState GetMouseState(IntPtr self)
		{
			return _GetMouseState(self).AsHandle(ptr => new MouseState(ptr));
		}

		#endregion
	}
}
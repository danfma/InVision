using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal class NativeMouseEventArgs : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_mouseevent_get_mouse_state")]
		public static extern IntPtr _GetMouseState(IntPtr self);

		#region Helpers

		/// <summary>
		/// Gets the state of the mouse.
		/// </summary>
		/// <param name="self">The self.</param>
		/// <returns></returns>
		public static MouseState GetMouseState(IntPtr self)
		{
			return _GetMouseState(self).AsHandle(ptr => new MouseState(ptr));
		}

		#endregion
	}
}
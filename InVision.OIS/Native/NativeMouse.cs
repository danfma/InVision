using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeMouse : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeMouse"/> class.
		/// </summary>
		static NativeMouse()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_mouse_set_event_callback")]
		public static extern void SetEventCallback(IntPtr self, IntPtr mouseListener);
	}
}
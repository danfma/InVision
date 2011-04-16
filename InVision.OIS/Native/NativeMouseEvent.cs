using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeMouseEvent : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeMouseEvent"/> class.
		/// </summary>
		static NativeMouseEvent()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_mouseevent_new_from")]
		public static extern MouseEventExtended New(IntPtr self);
	}
}
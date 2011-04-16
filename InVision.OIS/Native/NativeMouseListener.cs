using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeMouseListener : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeMouseListener"/> class.
		/// </summary>
		static NativeMouseListener()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_custommouselistener_new")]
		public static extern IntPtr New(MouseMovedHandler move, MouseClickHandler press, MouseClickHandler release);

		[DllImport(OISLibrary, EntryPoint = "ois_custommouselistener_delete")]
		public static extern void Delete(IntPtr self);
	}
}
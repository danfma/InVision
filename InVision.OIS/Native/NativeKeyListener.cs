using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeKeyListener : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeKeyListener"/> class.
		/// </summary>
		static NativeKeyListener()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_new_customkeylistener")]
		public static extern IntPtr New(KeyEventHandler keyPressedHandler, KeyEventHandler keyReleasedHandler);

		[DllImport(OISLibrary, EntryPoint = "ois_delete_customkeylistener")]
		public static extern void Delete(IntPtr self);
	}
}
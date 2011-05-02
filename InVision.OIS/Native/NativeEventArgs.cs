using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeEventArgs : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeEventArgs"/> class.
		/// </summary>
		static NativeEventArgs()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_eventarg_new_from")]
		public static extern EventArgDescriptor New(IntPtr self);
	}
}
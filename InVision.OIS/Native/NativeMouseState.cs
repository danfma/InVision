using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeMouseState : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeMouseState"/> class.
		/// </summary>
		static NativeMouseState()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_mousestate_new_from")]
		public static extern MouseStateDescriptor New(IntPtr self);
	}
}
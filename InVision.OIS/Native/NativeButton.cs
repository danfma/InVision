using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeButton : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeButton"/> class.
		/// </summary>
		static NativeButton()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_button_new")]
		public static extern ButtonExtended New(bool pushed);

		[DllImport(OISLibrary, EntryPoint = "ois_button_delete")]
		public static extern void Delete(IntPtr self);
	}
}
using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

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

		[DllImport(OISLibrary, EntryPoint = "ois_new_button")]
		public static extern ButtonDescriptor New(bool pushed);

		[DllImport(OISLibrary, EntryPoint = "ois_delete_button")]
		public static extern void Delete(Handle self);
	}
}
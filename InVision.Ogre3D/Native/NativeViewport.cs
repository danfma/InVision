﻿using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeViewport : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "viewport_get_bgcolor")]
		public static extern ColourValue GetBackgroundColor(IntPtr handle);

		[DllImport(Library, EntryPoint = "viewport_set_bgcolor")]
		public static extern ColourValue SetBackgroundColor(IntPtr handle, ColourValue color);


		[DllImport(Library, EntryPoint = "viewport_get_actual_width")]
		public static extern int GetActualWidth(IntPtr handle);

		[DllImport(Library, EntryPoint = "viewport_get_actual_height")]
		public static extern int GetActualHeight(IntPtr handle);
	}
}
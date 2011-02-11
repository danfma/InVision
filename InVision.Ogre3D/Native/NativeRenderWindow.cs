using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeRenderWindow : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "renderwindow_get_width")]
		public static extern uint GetWidth(IntPtr pRenderWindow);

		[DllImport(Library, EntryPoint = "renderwindow_get_height")]
		public static extern uint GetHeight(IntPtr pRenderWindow);
	}
}
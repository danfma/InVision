using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeRenderWindow : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "RndrWinGetWidth")]
		public static extern uint GetWidth(IntPtr pRenderWindow);

		[DllImport(Library, EntryPoint = "RndrWinGetHeight")]
		public static extern uint GetHeight(IntPtr pRenderWindow);
	}
}
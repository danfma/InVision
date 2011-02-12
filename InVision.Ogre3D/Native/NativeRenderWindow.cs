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

		[DllImport(Library, EntryPoint = "renderwindow_add_viewport")]
		public static extern IntPtr _AddViewport(
			IntPtr pRenderWindow,
			IntPtr pCamera,
			int zOrder, float left, float top,
			float width, float height);

		public static Viewport AddViewport(
			IntPtr pRenderWindow,
			IntPtr pCamera,
			int zOrder, float left, float top,
			float width, float height)
		{
			return _AddViewport(
				pRenderWindow, pCamera, zOrder,
				left, top, width, height).AsHandle(ptr => new Viewport(ptr, false));
		}
	}
}
using System;
using System.Runtime.InteropServices;
using InVision.Rendering;

namespace InVision.Native.Ogre
{
	internal sealed class NativeOgreRenderWindow : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "renderwindow_get_width")]
		public static extern uint GetWidth(IntPtr self);

		[DllImport(Library, EntryPoint = "renderwindow_get_height")]
		public static extern uint GetHeight(IntPtr self);

		[DllImport(Library, EntryPoint = "renderwindow_add_viewport")]
		public static extern IntPtr _AddViewport(
			IntPtr self,
			IntPtr pCamera,
			int zOrder, float left, float top,
			float width, float height);

		[DllImport(Library, EntryPoint = "renderwindow_write_contents_to_timestamped_file")]
		public static extern IntPtr _WriteContentsToTimestampedFile(
			IntPtr self,
			[MarshalAs(UnmanagedType.LPStr)] string filenamePrefix,
			[MarshalAs(UnmanagedType.LPStr)] string filenameSuffix);

		#region Helpers

		public static Viewport AddViewport(
			IntPtr self,
			IntPtr pCamera,
			int zOrder, float left, float top,
			float width, float height)
		{
			return _AddViewport(
				self, pCamera, zOrder,
				left, top, width, height).AsHandle(ptr => new Viewport(ptr, false));
		}

		public static string WriteContentsToTimestampedFile(
			IntPtr self,
			string filenamePrefix,
			string filenameSuffix)
		{
			return _WriteContentsToTimestampedFile(self, filenamePrefix, filenameSuffix).AsString();
		}

		#endregion
	}
}
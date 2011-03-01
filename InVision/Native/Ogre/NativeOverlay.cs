using System;
using System.Runtime.InteropServices;

namespace InVision.Native.Ogre
{
	internal sealed class NativeOverlay : PlatformInvoke
	{
		/// <summary>
		/// 	Initializes the <see cref = "NativeOverlay" /> class.
		/// </summary>
		static NativeOverlay()
		{
			Init();
		}

		[DllImport(Library, EntryPoint = "ogre_overlay_show")]
		public static extern void Show(IntPtr pOverlay);

		[DllImport(Library, EntryPoint = "ogre_overlay_hide")]
		public static extern void Hide(IntPtr pOverlay);
	}
}
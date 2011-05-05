using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	internal sealed class NativeOverlayElement : PlatformInvoke
	{
		/// <summary>
		/// Initializes the <see cref="NativeOverlayElement"/> class.
		/// </summary>
		static NativeOverlayElement()
		{
			Init();
		}

		[DllImport(Library, EntryPoint = "ogre_overlayelement_get_caption")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern string GetCaption(IntPtr pOverlayElement);

		[DllImport(Library, EntryPoint = "ogre_overlayelement_set_caption")]
		public static extern void SetCaption(IntPtr pOverlayElement, [MarshalAs(UnmanagedType.LPWStr)] string value);
	}
}
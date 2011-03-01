using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal sealed class NativeMouseListener : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_custommouselistener_new")]
		public static extern IntPtr New(
			MouseMoveDispatcherEventHandler mouseMove,
			MouseClickDispatcherEventHandler mousePressed,
			MouseClickDispatcherEventHandler mouseReleased);

		[DllImport(Library, EntryPoint = "ois_custommouselistener_delete")]
		public static extern void Delete(IntPtr handle);
	}
}
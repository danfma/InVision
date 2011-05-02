using System;
using System.Runtime.InteropServices;
using InVision.Rendering.Listeners;

namespace InVision.Native.Ogre
{
	internal sealed class NativeOgreFrameListener : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "framelistener_new")]
		public static extern IntPtr New(
			FrameEventDispatcherHandler frameStartedHandler,
			FrameEventDispatcherHandler frameEndedHandler);

		[DllImport(Library, EntryPoint = "framelistener_delete")]
		public static extern void Delete(IntPtr self);
	}
}
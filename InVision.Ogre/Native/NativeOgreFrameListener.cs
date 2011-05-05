using System;
using System.Runtime.InteropServices;
using InVision.Ogre.Listeners;

namespace InVision.Ogre.Native
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
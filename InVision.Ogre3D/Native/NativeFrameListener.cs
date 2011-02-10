using System;
using System.Runtime.InteropServices;
using InVision.Ogre3D.Listeners;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeFrameListener : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "FrmListenerNew")]
		public static extern IntPtr New(
			FrameEventDispatcherHandler frameStartedHandler,
			FrameEventDispatcherHandler frameEndedHandler);

		[DllImport(Library, EntryPoint = "FrmListenerDelete")]
		public static extern void Delete(IntPtr self);
	}
}
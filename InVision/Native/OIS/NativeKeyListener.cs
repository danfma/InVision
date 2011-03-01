using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal sealed class NativeKeyListener : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_new_keylistener")]
		public static extern IntPtr New(KeyDispatcherEventHandler keyPressed, KeyDispatcherEventHandler keyReleased);

		[DllImport(Library, EntryPoint = "ois_delete_keylistener")]
		public static extern void Delete(IntPtr self);
	}
}
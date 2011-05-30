/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Native;

namespace InVision.Native
{
	internal sealed class NativeHandleManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeHandleManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "handlemanager_register_handle_destroyed")]
		public static extern void RegisterHandleDestroyed(HandleListenerHandleDestroyedHandler handleDestroyed);
	}
	
}

using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Listeners
{
	/// <summary>
	/// 
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool FrameEventDispatcherHandler(IntPtr e);
}
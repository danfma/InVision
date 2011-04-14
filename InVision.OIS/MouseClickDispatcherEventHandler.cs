using System;
using System.Runtime.InteropServices;

namespace InVision.Input
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal delegate bool MouseClickDispatcherEventHandler(UMouseEventArgs e, MouseButton button);
}
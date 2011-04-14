using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.OIS
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal delegate bool KeyDispatcherEventHandler(UKeyEventArgs e);
}
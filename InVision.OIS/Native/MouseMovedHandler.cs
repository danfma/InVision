using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool MouseMovedHandler(MouseEventExtended e);
}
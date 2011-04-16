using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool MouseClickHandler(MouseEventExtended e, MouseButton button);
}
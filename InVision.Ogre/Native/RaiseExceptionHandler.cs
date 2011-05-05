using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void RaiseExceptionHandler([MarshalAs(UnmanagedType.LPStr)] string message);
}
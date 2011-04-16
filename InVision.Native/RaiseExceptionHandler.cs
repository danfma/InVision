using System.Runtime.InteropServices;

namespace InVision.Native
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void RaiseExceptionHandler(
		[MarshalAs(UnmanagedType.LPStr)] string message,
		[MarshalAs(UnmanagedType.LPStr)] string filename,
		int line);
}
using System.Runtime.InteropServices;

namespace InVision.OIS
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void RaiseExceptionHandler(
		[MarshalAs(UnmanagedType.LPStr)] string message,
		ErrorType errorType,
		[MarshalAs(UnmanagedType.LPStr)] string filename,
		int line);
}
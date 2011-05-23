using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[CppFunction]
	public delegate void LogListenerMessageLoggedHandler(
		[MarshalAs(UnmanagedType.LPStr)] string message,
		LogMessageLevel level,
		[MarshalAs(UnmanagedType.I1)] bool maskDebug,
		[MarshalAs(UnmanagedType.LPStr)] string name);
}
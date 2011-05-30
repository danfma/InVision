using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Listeners
{
	[CppFunction]
	[return: MarshalAs(UnmanagedType.I1)]
	public delegate bool FrameEventHandler(FrameEvent e);
}
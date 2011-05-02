using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool KeyEventHandler(KeyEventDescriptor e);
}
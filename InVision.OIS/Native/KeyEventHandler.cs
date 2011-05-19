using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppFunction]
	[return: MarshalAs(UnmanagedType.I1)]
	public delegate bool KeyEventHandler(KeyEventDescriptor e);
}
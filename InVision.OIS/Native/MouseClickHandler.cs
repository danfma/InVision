using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
    [CppFunction]
    [return: MarshalAs(UnmanagedType.I1)]
    public delegate bool MouseClickHandler(MouseEventDescriptor e, MouseButton button);
}
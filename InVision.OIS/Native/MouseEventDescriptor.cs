using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppValueObject]
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseEventDescriptor
    {
        public EventArgDescriptor Base;
        public MouseStateDescriptor MouseState;
    }
}
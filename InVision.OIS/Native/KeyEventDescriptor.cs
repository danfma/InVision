using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppDescriptor]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct KeyEventDescriptor
    {
        public EventArgDescriptor Base;
        public KeyCode* Key;
        public uint* Text;
    }
}
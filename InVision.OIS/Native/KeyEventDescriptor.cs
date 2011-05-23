using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Devices;

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
using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
    [CppDescriptor]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ComponentDescriptor
    {
        public Handle Self;
        public ComponentType* Ctype;
    }
}
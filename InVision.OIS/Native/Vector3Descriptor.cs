using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.OIS.Native
{
    [CppDescriptor]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Vector3Descriptor
    {
        public ComponentDescriptor Base;
        public float* Z;
        public float* Y;
        public float* X;
    }
}
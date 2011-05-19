using System;
using System.Runtime.InteropServices;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISDescriptor("Axis")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AxisDescriptor
    {
        public ComponentDescriptor Base;
        public int* Abs;
        public int* Rel;

        [MarshalAs(UnmanagedType.I1)] public bool* AbsOnly;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] private readonly byte[] _padding;
    }
}
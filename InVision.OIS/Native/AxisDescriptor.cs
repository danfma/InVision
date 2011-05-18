using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppValueObject]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AxisDescriptor
    {
        public ComponentDescriptor Base;
        public int* Abs;
        public int* Rel;
        
        [MarshalAs(UnmanagedType.I1)]
        public bool* AbsOnly;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        private byte[] _padding;
    }
}
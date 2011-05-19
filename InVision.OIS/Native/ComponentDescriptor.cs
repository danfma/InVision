using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS.Components;

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
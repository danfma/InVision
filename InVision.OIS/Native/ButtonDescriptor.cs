using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppDescriptor]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ButtonDescriptor
    {
        public ComponentDescriptor Base;
        public bool* Pushed;
    }
}
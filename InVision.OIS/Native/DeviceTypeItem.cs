using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppValueObject]
    [StructLayout(LayoutKind.Sequential)]
    internal struct DeviceTypeItem
    {
        public DeviceType DeviceType;

        [MarshalAs(UnmanagedType.LPStr)]
        public string Name;
    }
}
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [ValueObject]
    [StructLayout(LayoutKind.Sequential)]
    internal struct DeviceTypeItem
    {
        public DeviceType DeviceType;

        [MarshalAs(UnmanagedType.LPStr)]
        public string Name;
    }
}
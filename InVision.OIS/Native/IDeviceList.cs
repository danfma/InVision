using System;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppType("DeviceList")]
    public interface IDeviceList
    {
        [Method(Static = true)]
        void Delete(IntPtr deviceList);
    }
}
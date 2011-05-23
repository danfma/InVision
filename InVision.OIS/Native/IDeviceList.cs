using System;
using InVision.Native;

namespace InVision.OIS.Native
{
    [CppType("DeviceList")]
    public interface IDeviceList
    {
        [Method(Static = true)]
        void Delete(IntPtr deviceList);
    }
}
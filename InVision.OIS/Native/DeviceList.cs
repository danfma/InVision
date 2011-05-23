using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.OIS.Native
{
    [CppValueObject]
    [StructLayout(LayoutKind.Sequential)]
    internal struct DeviceList
    {
        private IntPtr items;
        private int count;

        /// <summary>
        /// Reads the data.
        /// </summary>
        /// <param name="pData">The pointer to the data.</param>
        /// <returns></returns>
        public static IEnumerable<DeviceListItem> ReadData(IntPtr pData)
        {
            try
            {
                var deviceList = (DeviceList)Marshal.PtrToStructure(pData, typeof(DeviceList));
                IntPtr pItem = deviceList.items;

                for (int i = 0; i < deviceList.count; i++, pItem += Marshal.SizeOf(typeof(DeviceListItem)))
                {
                    yield return (DeviceListItem)Marshal.PtrToStructure(pItem, typeof(DeviceListItem));
                }
            }
            finally
            {
                NativeFactory.Get<IDeviceList>().Delete(pData);
            }
        }
    }
}
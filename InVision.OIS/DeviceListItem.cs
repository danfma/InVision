using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS
{
    [CppValueObject]
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceListItem
    {
        [MarshalAs(UnmanagedType.I4)]
        private readonly DeviceType type;

        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string name;

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public DeviceType Type
        {
            get { return type; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return name; }
        }
    }
}
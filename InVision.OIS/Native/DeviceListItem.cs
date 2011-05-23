using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
	[CppValueObject]
	[StructLayout(LayoutKind.Sequential)]
	internal struct DeviceListItem
	{
		public DeviceType Key;

		[MarshalAs(UnmanagedType.LPStr)]
		public string Value;
	}
}
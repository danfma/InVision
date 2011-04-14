using System;
using System.Runtime.InteropServices;
using InVision.Native.OIS;
using InVision.OIS;

namespace InVision.Input
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct UKeyEventArgs
	{
		public InputType DeviceType;
		public IntPtr DeviceHandle;
		public KeyCode Key;
		public uint TextCode;

		/// <summary>
		/// Gets the device.
		/// </summary>
		/// <value>The device.</value>
		public Device Device
		{
			get { return NativeObject.Create(DeviceType, DeviceHandle, false); }
		}
	}
}
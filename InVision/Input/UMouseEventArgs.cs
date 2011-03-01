using System;
using System.Runtime.InteropServices;
using InVision.Native.OIS;

namespace InVision.Input
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct UMouseEventArgs
	{
		public InputType DeviceType;
		public IntPtr DeviceHandle;
		public MouseState MouseState;

		/// <summary>
		/// Gets the device.
		/// </summary>
		/// <value>The device.</value>
		public InputObject Device
		{
			get { return NativeObject.Create(DeviceType, DeviceHandle, false); }
		}
	}
}
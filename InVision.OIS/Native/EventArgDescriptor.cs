using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct EventArgDescriptor
	{
		private readonly IntPtr _self;
		private readonly IntPtr* _device;

		/// <summary>
		/// Gets the self.
		/// </summary>
		/// <value>The self.</value>
		public IntPtr Self
		{
			get { return _self; }
		}

		/// <summary>
		/// Gets the device.
		/// </summary>
		/// <value>The device.</value>
		public IntPtr Device
		{
			get { return *_device; }
		}
	}
}
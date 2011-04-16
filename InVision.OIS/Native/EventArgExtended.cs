using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct EventArgExtended
	{
		private readonly IntPtr self;
		private readonly IntPtr device;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventArgExtended"/> struct.
		/// </summary>
		/// <param name="self">The self.</param>
		/// <param name="device">The device.</param>
		public EventArgExtended(IntPtr self, IntPtr device)
		{
			this.self = self;
			this.device = device;
		}

		/// <summary>
		/// Gets the self.
		/// </summary>
		/// <value>The self.</value>
		public IntPtr Self
		{
			get { return self; }
		}

		/// <summary>
		/// Gets the device.
		/// </summary>
		/// <value>The device.</value>
		public IntPtr Device
		{
			get { return device; }
		}
	}
}
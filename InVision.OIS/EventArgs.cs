using System;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class EventArgs : System.EventArgs
	{
		private readonly EventArgDescriptor _descriptor;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventArgs"/> class.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		internal EventArgs(EventArgDescriptor descriptor)
		{
			_descriptor = descriptor;
		}

		/// <summary>
		/// Gets or sets the device.
		/// </summary>
		/// <value>The device.</value>
		public IntPtr Device
		{
			get { return _descriptor.Device; }
		}
	}
}
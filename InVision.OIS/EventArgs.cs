using System;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class EventArgs : System.EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EventArgs"/> class.
		/// </summary>
		/// <param name="eventArgExtended">The event arg extended.</param>
		internal EventArgs(EventArgExtended eventArgExtended)
		{
			Device = eventArgExtended.Device;
		}

		/// <summary>
		/// Gets or sets the device.
		/// </summary>
		/// <value>The device.</value>
		public IntPtr Device { get; private set; }
	}
}
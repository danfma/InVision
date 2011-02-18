using System;

namespace InVision.Input
{
	public abstract class EventArgs
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "EventArgs" /> class.
		/// </summary>
		/// <param name = "device">The device.</param>
		protected EventArgs(InputObject device)
		{
			Device = device;
		}

		/// <summary>
		/// 	Gets the device.
		/// </summary>
		/// <value>The device.</value>
		public InputObject Device { get; private set; }
	}
}
namespace InVision.OIS
{
	public abstract class EventArgs
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "InVision.OIS.EventArgs" /> class.
		/// </summary>
		/// <param name = "device">The device.</param>
		protected EventArgs(Device device)
		{
			Device = device;
		}

		/// <summary>
		/// 	Gets the device.
		/// </summary>
		/// <value>The device.</value>
		public Device Device { get; private set; }
	}
}
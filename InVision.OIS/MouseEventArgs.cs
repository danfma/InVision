using InVision.OIS;

namespace InVision.Input
{
	public sealed class MouseEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
		/// </summary>
		/// <param name="data">The <see cref="InVision.Input.UMouseEventArgs"/> instance containing the event data.</param>
		internal MouseEventArgs(ref UMouseEventArgs data)
			: base(data.Device)
		{
			State = data.MouseState;
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "MouseEventArgs" /> class.
		/// </summary>
		/// <param name = "device">The device.</param>
		/// <param name = "state">The state.</param>
		public MouseEventArgs(Device device, MouseState state)
			: base(device)
		{
			State = state;
		}

		/// <summary>
		/// 	Gets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseState State { get; private set; }
	}
}
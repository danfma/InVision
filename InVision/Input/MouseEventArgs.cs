using System;

namespace InVision.Input
{
	public sealed class MouseEventArgs : EventArgs
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "MouseEventArgs" /> class.
		/// </summary>
		/// <param name = "device">The device.</param>
		/// <param name = "state">The state.</param>
		public MouseEventArgs(InputObject device, MouseState state)
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
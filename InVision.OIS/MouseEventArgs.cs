using InVision.OIS.Native;

namespace InVision.OIS
{
	public class MouseEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
		/// </summary>
		/// <param name="descriptor">The mouse event descriptor.</param>
		internal MouseEventArgs(MouseEventDescriptor descriptor)
			: base(descriptor.Base)
		{
			State = new MouseState(descriptor.MouseState);
		}

		/// <summary>
		/// Gets or sets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseState State { get; private set; }
	}
}
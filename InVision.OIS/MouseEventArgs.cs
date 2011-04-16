using InVision.OIS.Native;

namespace InVision.OIS
{
	public class MouseEventArgs : EventArgs
	{
		internal MouseEventArgs(MouseEventExtended mouseEventExtended)
			: base(mouseEventExtended.Base)
		{
			State = new MouseState(mouseEventExtended.State);
		}

		/// <summary>
		/// Gets or sets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseState State { get; private set; }
	}
}
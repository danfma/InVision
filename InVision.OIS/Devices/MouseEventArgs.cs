using System;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public class MouseEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
		/// </summary>
		/// <param name="descriptor">The mouse event descriptor.</param>
		protected internal MouseEventArgs(MouseEventDescriptor descriptor)
			: base(descriptor.Base, CreateCppInstance<IMouseEvent>())
		{
			Initialize(descriptor);
		}

		/// <summary>
		/// Initializes the specified descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		protected void Initialize(MouseEventDescriptor descriptor)
		{
			Initialize(descriptor.Base);
			State = new MouseState(descriptor.MouseState);
		}

		/// <summary>
		/// Gets or sets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseState State { get; private set; }
	}
}
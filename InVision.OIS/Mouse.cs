using System;
using System.Collections.Generic;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class Mouse : DeviceObject
	{
		private MouseListenerDispatcher _dispatcher;

		/// <summary>
		/// Initializes a new instance of the <see cref="Mouse"/> class.
		/// </summary>
		/// <param name="descriptor">The _descriptor.</param>
		internal Mouse(MouseDescriptor descriptor)
			: base(descriptor.Self, false)
		{
			Initialize(descriptor);
		}

		/// <summary>
		/// Gets or sets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseState MouseState { get; private set; }

		/// <summary>
		/// Gets the listeners.
		/// </summary>
		/// <value>The listeners.</value>
		public IList<IMouseListener> Listeners
		{
			get { return _dispatcher.Listeners; }
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		private void Initialize(MouseDescriptor descriptor)
		{
			_dispatcher = new MouseListenerDispatcher();
			NativeMouse.SetEventCallback(handle, _dispatcher.DangerousGetHandle());

			MouseState = new MouseState(descriptor.MouseState);
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeMouse.SetEventCallback(handle, IntPtr.Zero);
			_dispatcher.Dispose();

			base.ReleaseValidHandle();
		}

		public event MouseMovedHandler MouseMoved
		{
			add { _dispatcher.MouseMoved += value; }
			remove { _dispatcher.MouseMoved -= value; }
		}

		public event MouseClickHandler MousePressed
		{
			add { _dispatcher.MousePressed += value; }
			remove { _dispatcher.MousePressed -= value; }
		}

		public event MouseClickHandler MouseReleased
		{
			add { _dispatcher.MouseReleased += value; }
			remove { _dispatcher.MouseReleased -= value; }
		}
	}
}
using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public class Mouse : DeviceObject
	{
		private readonly MouseListenerDispatcher _dispatcher;

		/// <summary>
		/// Initializes a new instance of the <see cref="Mouse"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected Mouse(ICppInterface nativeInstance)
			: base(nativeInstance)
		{
			_dispatcher = new MouseListenerDispatcher();
		}

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new IMouse Native
		{
			get { return (IMouse)base.Native; }
		}

		/// <summary>
		/// Gets or sets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseState MouseState
		{
			get
			{
				IMouseState nativeMouseState = Native.GetMouseState();

				return GetOrCreateOwner(nativeMouseState, native => new MouseState(native));
			}
		}

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
		protected override void Initialize()
		{
			base.Initialize();
			Native.SetEventCallback(_dispatcher.Native);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.SetEventCallback(null);

			if (_dispatcher != null && !_dispatcher.IsDisposed)
				_dispatcher.Dispose();

			base.Dispose(disposing);
		}

		/// <summary>
		/// Occurs when [mouse moved].
		/// </summary>
		public event MouseMovedHandler MouseMoved
		{
			add { _dispatcher.MouseMoved += value; }
			remove { _dispatcher.MouseMoved -= value; }
		}

		/// <summary>
		/// Occurs when [mouse pressed].
		/// </summary>
		public event MouseClickHandler MousePressed
		{
			add { _dispatcher.MousePressed += value; }
			remove { _dispatcher.MousePressed -= value; }
		}

		/// <summary>
		/// Occurs when [mouse released].
		/// </summary>
		public event MouseClickHandler MouseReleased
		{
			add { _dispatcher.MouseReleased += value; }
			remove { _dispatcher.MouseReleased -= value; }
		}
	}
}
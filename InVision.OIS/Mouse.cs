using System;
using System.Collections.Generic;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class Mouse : DeviceObject
	{
		private MouseListenerDispatcher dispatcher;

		/// <summary>
		/// Initializes a new instance of the <see cref="Mouse"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		public Mouse(IntPtr pSelf)
			: base(pSelf, true)
		{
			Initialize();
		}

		/// <summary>
		/// Gets the listeners.
		/// </summary>
		/// <value>The listeners.</value>
		public IList<IMouseListener> Listeners
		{
			get { return dispatcher.Listeners; }
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Initialize()
		{
			dispatcher = new MouseListenerDispatcher();
			NativeMouse.SetEventCallback(handle, dispatcher.DangerousGetHandle());
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeMouse.SetEventCallback(handle, IntPtr.Zero);
			dispatcher.Dispose();

			base.ReleaseValidHandle();
		}

		public event MouseMovedHandler MouseMoved
		{
			add { dispatcher.MouseMoved += value; }
			remove { dispatcher.MouseMoved -= value; }
		}

		public event MouseClickHandler MousePressed
		{
			add { dispatcher.MousePressed += value; }
			remove { dispatcher.MousePressed -= value; }
		}

		public event MouseClickHandler MouseReleased
		{
			add { dispatcher.MouseReleased += value; }
			remove { dispatcher.MouseReleased -= value; }
		}
	}
}
using System;
using InVision.Native.OIS;

namespace InVision.Input
{
	public class Mouse : InputObject
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Mouse" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal Mouse(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
			Events = new MouseEventDispatcher();
		}

		/// <summary>
		/// 	Gets or sets the events.
		/// </summary>
		/// <value>The events.</value>
		private MouseEventDispatcher Events { get; set; }

		/// <summary>
		/// 	Gets or sets a value indicating whether this instance has events enabled.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has events enabled; otherwise, <c>false</c>.
		/// </value>
		public bool HasEventsEnabled { get; private set; }

		/// <summary>
		/// 	Gets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseState MouseState
		{
			get { return NativeMouse.GetMouseState(handle); }
		}

		public event MouseMoveEventHandler MouseMoved
		{
			add
			{
				Events.MouseMoved += value;
				EnableEvents();
			}
			remove
			{
				Events.MouseMoved -= value;
				DisableEvents();
			}
		}

		public event MouseClickEventHandler MousePressed
		{
			add
			{
				Events.MousePressed += value;
				EnableEvents();
			}
			remove
			{
				Events.MousePressed -= value;
				DisableEvents();
			}
		}

		public event MouseClickEventHandler MouseReleased
		{
			add
			{
				Events.MouseReleased += value;
				EnableEvents();
			}
			remove
			{
				Events.MouseReleased -= value;
				DisableEvents();
			}
		}

		/// <summary>
		/// 	Adds the listener.
		/// </summary>
		/// <param name = "listener">The listener.</param>
		public void AddListener(IMouseListener listener)
		{
			Events.AddListener(listener);
			EnableEvents();
		}

		/// <summary>
		/// 	Removes the listener.
		/// </summary>
		/// <param name = "listener">The listener.</param>
		public void RemoveListener(IMouseListener listener)
		{
			Events.RemoveListener(listener);
			DisableEvents();
		}

		/// <summary>
		/// 	Releases the unmanaged resources used by the <see cref = "T:System.Runtime.InteropServices.SafeHandle" /> class specifying whether to perform a normal dispose operation.
		/// </summary>
		/// <param name = "disposing">true for a normal dispose operation; false to finalize the handle.</param>
		protected override void Dispose(bool disposing)
		{
			if (Events != null)
				DisableEvents(true);

			base.Dispose(disposing);

			if (disposing)
				Events = null;
		}

		/// <summary>
		/// 	Enables the events.
		/// </summary>
		private void EnableEvents()
		{
			if (HasEventsEnabled)
				return;

			NativeMouse.SetEventCallback(handle, Events.DangerousGetHandle());
			HasEventsEnabled = true;
		}

		/// <summary>
		/// 	Disables the events.
		/// </summary>
		/// <param name = "force">if set to <c>true</c> [force].</param>
		private void DisableEvents(bool force = false)
		{
			if (!HasEventsEnabled)
				return;

			if (Events.HasListeners && !force)
				return;

			NativeMouse.SetEventCallback(handle, IntPtr.Zero);
			HasEventsEnabled = false;
		}

		#region Nested type: MouseEventDispatcher

		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Native.OIS;

namespace InVision.Input
{
	internal sealed class MouseEventDispatcher : Handle
	{
		private readonly List<IMouseListener> listeners;
		private readonly MouseMoveDispatcherEventHandler mouseMoved;
		private readonly MouseClickDispatcherEventHandler mousePressed;
		private readonly MouseClickDispatcherEventHandler mouseReleased;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "MouseEventDispatcher" /> class.
		/// </summary>
		public MouseEventDispatcher()
		{
			listeners = new List<IMouseListener>();
			mouseMoved = OnMouseMoved;
			mousePressed = OnMousePressed;
			mouseReleased = OnMouseReleased;

			SetHandle(NativeMouseListener.New(mouseMoved, mousePressed, mouseReleased));
		}

		/// <summary>
		/// 	Gets a value indicating whether this instance has listeners.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has listeners; otherwise, <c>false</c>.
		/// </value>
		public bool HasListeners
		{
			get { return MouseMoved != null || MousePressed != null || MouseReleased != null || listeners.Count > 0; }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			NativeMouseListener.Delete(handle);
		}

		/// <summary>
		/// 	Occurs when [mouse moved].
		/// </summary>
		public event MouseMoveEventHandler MouseMoved;

		/// <summary>
		/// 	Occurs when [mouse pressed].
		/// </summary>
		public event MouseClickEventHandler MousePressed;

		/// <summary>
		/// 	Occurs when [mouse released].
		/// </summary>
		public event MouseClickEventHandler MouseReleased;

		/// <summary>
		/// 	Adds the listener.
		/// </summary>
		/// <param name = "listener">The listener.</param>
		public void AddListener(IMouseListener listener)
		{
			listeners.Add(listener);
		}

		/// <summary>
		/// 	Removes the listener.
		/// </summary>
		/// <param name = "listener">The listener.</param>
		public void RemoveListener(IMouseListener listener)
		{
			listeners.Remove(listener);
		}

		/// <summary>
		/// 	Raises the <see cref = "E:MouseMoved" /> event.
		/// </summary>
		/// <param name = "e">The <see cref = "InVision.Input.UMouseEventArgs" /> instance containing the event data.</param>
		/// <returns></returns>
		private bool OnMouseMoved(UMouseEventArgs e)
		{
			bool result = true;
			var mouseEventArgs = new MouseEventArgs(ref e);

			if (MouseMoved != null)
				result = MouseMoved(mouseEventArgs);

			return listeners.Aggregate(result, (current, mouseListener) => current && mouseListener.OnMouseMoved(mouseEventArgs));
		}

		/// <summary>
		/// 	Raises the <see cref = "E:MousePressed" /> event.
		/// </summary>
		/// <param name = "e">The <see cref = "InVision.Input.UMouseEventArgs" /> instance containing the event data.</param>
		/// <param name = "button">The button.</param>
		/// <returns></returns>
		private bool OnMousePressed(UMouseEventArgs e, MouseButton button)
		{
			bool result = true;
			var mouseEventArgs = new MouseEventArgs(ref e);

			if (MousePressed != null)
				result = MousePressed(mouseEventArgs, button);

			return listeners.Aggregate(result,
									   (current, mouseListener) =>
									   current && mouseListener.OnMousePressed(mouseEventArgs, button));
		}

		/// <summary>
		/// 	Raises the <see cref = "E:MouseReleased" /> event.
		/// </summary>
		/// <param name = "e">The <see cref = "InVision.Input.UMouseEventArgs" /> instance containing the event data.</param>
		/// <param name = "button">The button.</param>
		/// <returns></returns>
		private bool OnMouseReleased(UMouseEventArgs e, MouseButton button)
		{
			bool result = true;
			var mouseEventArgs = new MouseEventArgs(ref e);

			if (MouseReleased != null)
				result = MouseReleased(mouseEventArgs, button);

			return listeners.Aggregate(result,
									   (current, mouseListener) =>
									   current && mouseListener.OnMouseReleased(mouseEventArgs, button));
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Native;
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

			SetHandle(NativeCustomMouseListener.New(mouseMoved, mousePressed, mouseReleased));
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
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			NativeCustomMouseListener.Delete(pSelf);
			return true;
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
		/// 	Called when [mouse moved].
		/// </summary>
		/// <param name = "mouseEventHandler">The mouse event handler.</param>
		/// <returns></returns>
		private bool OnMouseMoved(IntPtr mouseEventHandler)
		{
			bool result = true;
			MouseEventArgs mouseEventArgs = mouseEventHandler.AsHandle(ptr => new MouseEventArgs(ptr));

			if (MouseMoved != null)
				result = MouseMoved(mouseEventArgs);

			return listeners.Aggregate(result, (current, mouseListener) => current && mouseListener.OnMouseMoved(mouseEventArgs));
		}

		/// <summary>
		/// 	Called when [mouse pressed].
		/// </summary>
		/// <param name = "mouseEventHandler">The mouse event handler.</param>
		/// <param name = "button">The button.</param>
		/// <returns></returns>
		private bool OnMousePressed(IntPtr mouseEventHandler, MouseButton button)
		{
			bool result = true;
			MouseEventArgs mouseEventArgs = mouseEventHandler.AsHandle(ptr => new MouseEventArgs(ptr));

			if (MousePressed != null)
				result = MousePressed(mouseEventArgs, button);

			return listeners.Aggregate(result,
			                           (current, mouseListener) =>
			                           current && mouseListener.OnMousePressed(mouseEventArgs, button));
		}

		/// <summary>
		/// 	Called when [mouse released].
		/// </summary>
		/// <param name = "mouseEventHandler">The mouse event handler.</param>
		/// <param name = "button">The button.</param>
		/// <returns></returns>
		private bool OnMouseReleased(IntPtr mouseEventHandler, MouseButton button)
		{
			bool result = true;
			MouseEventArgs mouseEventArgs = mouseEventHandler.AsHandle(ptr => new MouseEventArgs(ptr));

			if (MouseReleased != null)
				result = MouseReleased(mouseEventArgs, button);

			return listeners.Aggregate(result,
			                           (current, mouseListener) =>
			                           current && mouseListener.OnMouseReleased(mouseEventArgs, button));
		}
	}
}
using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class MouseListenerDispatcher : SafeHandle
	{
		private readonly List<IMouseListener> _listeners;
		private readonly Native.MouseMovedHandler _mouseMoved;
		private readonly Native.MouseClickHandler _mousePressed;
		private readonly Native.MouseClickHandler _mouseReleased;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseListenerDispatcher"/> class.
		/// </summary>
		public MouseListenerDispatcher()
		{
			_listeners = new List<IMouseListener>();
			_mouseMoved = OnMouseMoved;
			_mousePressed = OnMousePressed;
			_mouseReleased = OnMouseReleased;

			SetHandle(NativeMouseListener.New(_mouseMoved, _mousePressed, _mouseReleased));
		}

		/// <summary>
		/// Gets the listeners.
		/// </summary>
		/// <value>The listeners.</value>
		public IList<IMouseListener> Listeners
		{
			get { return _listeners; }
		}

		public event MouseMovedHandler MouseMoved;
		public event MouseClickHandler MousePressed;
		public event MouseClickHandler MouseReleased;

		/// <summary>
		/// Called when [mouse released].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="button">The button.</param>
		/// <returns></returns>
		private bool OnMouseReleased(MouseEventDescriptor e, MouseButton button)
		{
			var @event = new MouseEventArgs(e);
			bool result = true;

			if (MouseReleased != null)
			{
				foreach (MouseClickHandler @delegate in MouseReleased.GetInvocationList())
				{
					result = result && @delegate(@event, button);
				}
			}

			foreach (IMouseListener mouseListener in _listeners)
			{
				result = result && mouseListener.OnMouseReleased(@event, button);
			}

			return result;
		}

		/// <summary>
		/// Called when [mouse pressed].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="button">The button.</param>
		/// <returns></returns>
		private bool OnMousePressed(MouseEventDescriptor e, MouseButton button)
		{
			var @event = new MouseEventArgs(e);
			bool result = true;

			if (MousePressed != null)
			{
				foreach (MouseClickHandler @delegate in MousePressed.GetInvocationList())
				{
					result = result && @delegate(@event, button);
				}
			}

			foreach (IMouseListener mouseListener in _listeners)
			{
				result = result && mouseListener.OnMousePressed(@event, button);
			}

			return result;
		}

		/// <summary>
		/// Called when [mouse moved].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns></returns>
		private bool OnMouseMoved(MouseEventDescriptor e)
		{
			var @event = new MouseEventArgs(e);
			bool result = true;

			if (MouseMoved != null)
			{
				foreach (MouseMovedHandler @delegate in MouseMoved.GetInvocationList())
				{
					result = result && @delegate(@event);
				}
			}

			foreach (IMouseListener mouseListener in _listeners)
			{
				result = result && mouseListener.OnMouseMoved(@event);
			}

			return result;
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeMouseListener.Delete(handle);

			MousePressed = null;
			MouseReleased = null;
			MouseMoved = null;

			_listeners.Clear();
		}
	}
}
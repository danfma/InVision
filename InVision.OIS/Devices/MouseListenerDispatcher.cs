using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public class MouseListenerDispatcher : CppWrapper
	{
		private List<IMouseListener> _listeners;
		private readonly Native.MouseMovedHandler _mouseMoved;
		private readonly Native.MouseClickHandler _mousePressed;
		private readonly Native.MouseClickHandler _mouseReleased;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseListenerDispatcher"/> class.
		/// </summary>
		public MouseListenerDispatcher()
			: base(CreateCppInstance<ICustomMouseListener>())
		{
			_listeners = new List<IMouseListener>();
			_mouseMoved = OnMouseMoved;
			_mousePressed = OnMousePressed;
			_mouseReleased = OnMouseReleased;

			Native.Construct(_mouseMoved, _mousePressed, _mouseReleased).SetOwner(this);
		}

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new ICustomMouseListener Native
		{
			get { return (ICustomMouseListener)base.Native; }
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
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.Destruct();

			if (disposing)
			{
				MousePressed = null;
				MouseReleased = null;
				MouseMoved = null;

				_listeners.Clear();
				_listeners = null;
			}

			base.Dispose(disposing);
		}
	}
}
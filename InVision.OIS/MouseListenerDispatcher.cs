using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class MouseListenerDispatcher : Handle
	{
		private readonly List<IMouseListener> listeners;
		private readonly Native.MouseMovedHandler mouseMoved;
		private readonly Native.MouseClickHandler mousePressed;
		private readonly Native.MouseClickHandler mouseReleased;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseListenerDispatcher"/> class.
		/// </summary>
		public MouseListenerDispatcher()
		{
			mouseMoved = OnMouseMoved;
			mousePressed = OnMousePressed;
			mouseReleased = OnMouseReleased;
			listeners = new List<IMouseListener>();

			SetHandle(NativeMouseListener.New(mouseMoved, mousePressed, mouseReleased));
		}

		/// <summary>
		/// Gets the listeners.
		/// </summary>
		/// <value>The listeners.</value>
		public IList<IMouseListener> Listeners
		{
			get { return listeners; }
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
		private bool OnMouseReleased(MouseEventExtended e, MouseButton button)
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

			foreach (IMouseListener mouseListener in listeners)
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
		private bool OnMousePressed(MouseEventExtended e, MouseButton button)
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

			foreach (IMouseListener mouseListener in listeners)
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
		private bool OnMouseMoved(MouseEventExtended e)
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

			foreach (IMouseListener mouseListener in listeners)
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

			listeners.Clear();
		}
	}
}
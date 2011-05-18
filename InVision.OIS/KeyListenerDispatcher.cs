using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class KeyListenerDispatcher : SafeHandle
	{
		private readonly Native.KeyEventHandler _keyPressedHandler;
		private readonly Native.KeyEventHandler _keyReleasedHandler;
		private readonly List<IKeyListener> _listeners;

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyListenerDispatcher"/> class.
		/// </summary>
		public KeyListenerDispatcher()
		{
			_keyPressedHandler = OnKeyPressed;
			_keyReleasedHandler = OnKeyReleased;
			_listeners = new List<IKeyListener>();

			SetHandle(NativeKeyListener.New(_keyPressedHandler, _keyReleasedHandler));
		}

		/// <summary>
		/// Gets the listeners.
		/// </summary>
		/// <value>The listeners.</value>
		public IList<IKeyListener> Listeners
		{
			get { return _listeners; }
		}

		public event KeyEventHandler KeyPressed;
		public event KeyEventHandler KeyReleased;

		/// <summary>
		/// Called when [key pressed].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns></returns>
		private bool OnKeyPressed(KeyEventDescriptor e)
		{
			bool result = true;
			var keyEvent = new KeyEventArgs(e);

			if (KeyPressed != null)
			{
				foreach (KeyEventHandler @delegate in KeyPressed.GetInvocationList())
				{
					result = result && @delegate(keyEvent);
				}
			}

			foreach (IKeyListener keyListener in Listeners)
			{
				result = result && keyListener.OnKeyPressed(keyEvent);
			}

			return result;
		}

		/// <summary>
		/// Called when [key released].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns></returns>
		private bool OnKeyReleased(KeyEventDescriptor e)
		{
			bool result = true;
			var keyEvent = new KeyEventArgs(e);

			if (KeyReleased != null)
			{
				foreach (KeyEventHandler @delegate in KeyReleased.GetInvocationList())
				{
					result = result && @delegate(keyEvent);
				}
			}

			foreach (IKeyListener keyListener in Listeners)
			{
				result = result && keyListener.OnKeyReleased(keyEvent);
			}

			return result;
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeKeyListener.Delete(handle);
		}
	}
}
using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public class KeyListenerDispatcher : CppWrapper
	{
		private readonly Native.KeyEventHandler _keyPressedHandler;
		private readonly Native.KeyEventHandler _keyReleasedHandler;
		private readonly List<IKeyListener> _listeners;

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyListenerDispatcher"/> class.
		/// </summary>
		public KeyListenerDispatcher()
			: base(CreateCppInstance<ICustomKeyListener>())
		{
			_keyPressedHandler = OnKeyPressed;
			_keyReleasedHandler = OnKeyReleased;
			_listeners = new List<IKeyListener>();

			Native.Construct(_keyPressedHandler, _keyReleasedHandler).SetOwner(this);
		}

		/// <summary>
		/// Gets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new ICustomKeyListener Native
		{
			get { return (ICustomKeyListener)base.Native; }
		}

		/// <summary>
		/// Gets the listeners.
		/// </summary>
		/// <value>The listeners.</value>
		public IList<IKeyListener> Listeners
		{
			get { return _listeners; }
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
				_listeners.Clear();

			base.Dispose(disposing);
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
	}
}
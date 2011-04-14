using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Native.OIS;
using InVision.OIS;

namespace InVision.Input
{
	internal sealed class KeyEventDispatcher : Handle
	{
		private readonly IList<IKeyEventListener> listeners;
		private readonly KeyDispatcherEventHandler keyPressedHandler;
		private readonly KeyDispatcherEventHandler keyReleasedHandler;

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyEventDispatcher"/> class.
		/// </summary>
		public KeyEventDispatcher()
		{
			listeners = new List<IKeyEventListener>();
			keyPressedHandler = OnKeyPressed;
			keyReleasedHandler = OnKeyReleased;

			SetHandle(NativeKeyListener.New(keyPressedHandler, keyReleasedHandler));
		}

		/// <summary>
		/// Gets a value indicating whether this instance has listeners.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has listeners; otherwise, <c>false</c>.
		/// </value>
		public bool HasListeners
		{
			get { return KeyPressed != null || KeyReleased != null || listeners.Count > 0; }
		}

		/// <summary>
		/// Occurs when [key pressed].
		/// </summary>
		public event KeyEventHandler KeyPressed;

		/// <summary>
		/// Occurs when [key released].
		/// </summary>
		public event KeyEventHandler KeyReleased;

		/// <summary>
		/// Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			NativeKeyListener.Delete(handle);
		}

		/// <summary>
		/// Adds the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		public void Add(IKeyEventListener item)
		{
			listeners.Add(item);
		}

		/// <summary>
		/// Removes the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		public void Remove(IKeyEventListener item)
		{
			listeners.Remove(item);
		}

		/// <summary>
		/// Raises the <see cref="E:KeyPressed"/> event.
		/// </summary>
		/// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
		/// <returns></returns>
		private bool OnKeyPressed(UKeyEventArgs e)
		{
			bool result = true;
			var keyEvent = new KeyEventArgs(ref e);

			if (KeyPressed != null)
				result = KeyPressed(keyEvent);

			return listeners.Aggregate(result, (current, keyListener) => current && keyListener.OnKeyPressed(keyEvent));
		}

		/// <summary>
		/// Raises the <see cref="E:KeyReleased"/> event.
		/// </summary>
		/// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
		/// <returns></returns>
		private bool OnKeyReleased(UKeyEventArgs e)
		{
			bool result = true;
			var keyEvent = new KeyEventArgs(ref e);

			if (KeyReleased != null)
				result = KeyReleased(keyEvent);

			return listeners.Aggregate(result, (current, keyListener) => current && keyListener.OnKeyReleased(keyEvent));
		}
	}
}
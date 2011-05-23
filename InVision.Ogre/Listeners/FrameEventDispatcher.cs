using System;
using System.Collections.Generic;
using System.Linq;

namespace InVision.Ogre.Listeners
{
	public sealed class FrameEventDispatcher : IFrameListener, IEventDispatcher
	{
		private readonly FrameEventDispatcherHandler _frameEndedHandler;
		private readonly FrameEventDispatcherHandler _frameStartedHandler;
		private readonly List<IFrameListener> _listeners;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "FrameEventDispatcher" /> class.
		/// </summary>
		public FrameEventDispatcher()
		{
			_frameStartedHandler = new FrameEventDispatcherHandler(OnFrameStarted);
			_frameEndedHandler = new FrameEventDispatcherHandler(OnFrameEnded);

			//SetHandle(NativeOgreFrameListener.New(frameStartedHandler, frameEndedHandler));

			_listeners = new List<IFrameListener>();
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is listeners enabled.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is listeners enabled; otherwise, <c>false</c>.
		/// </value>
		public bool IsListenersEnabled { get; private set; }

		#region IFrameListener Members

		/// <summary>
		/// 	Called when [frame started].
		/// </summary>
		/// <param name = "e">The e.</param>
		/// <returns></returns>
		public bool OnFrameStarted(FrameEvent e)
		{
			bool result = true;

			if (FrameStarted != null)
				result = FrameStarted(e);

			return _listeners.Aggregate(result, (current, frameListener) => current && frameListener.OnFrameStarted(e));
		}

		/// <summary>
		/// 	Called when [frame ended].
		/// </summary>
		/// <param name = "e">The e.</param>
		/// <returns></returns>
		public bool OnFrameEnded(FrameEvent e)
		{
			bool result = true;

			if (FrameEnded != null)
				result = FrameEnded(e);

			return _listeners.Aggregate(result, (current, frameListener) => current && frameListener.OnFrameEnded(e));
		}

		#endregion

		/// <summary>
		/// 	Called when [frame started].
		/// </summary>
		/// <param name = "pEvent">The p event.</param>
		/// <returns></returns>
		private bool OnFrameStarted(IntPtr pEvent)
		{
			var e = new FrameEvent();

			return OnFrameStarted(e);
		}

		/// <summary>
		/// 	Called when [frame ended].
		/// </summary>
		/// <param name = "pEvent">The p event.</param>
		/// <returns></returns>
		private bool OnFrameEnded(IntPtr pEvent)
		{
			var e = new FrameEvent();

			return OnFrameEnded(e);
		}

		/// <summary>
		/// 	Occurs when [frame started].
		/// </summary>
		public event FrameEventHandler FrameStarted;

		/// <summary>
		/// 	Occurs when [frame ended].
		/// </summary>
		public event FrameEventHandler FrameEnded;

		/// <summary>
		/// 	Adds an object to the end of the <see cref = "T:System.Collections.Generic.List`1" />.
		/// </summary>
		/// <param name = "item">The object to be added to the end of the <see cref = "T:System.Collections.Generic.List`1" />. The value can be null for reference types.</param>
		public void Add(IFrameListener item)
		{
			_listeners.Add(item);
		}

		/// <summary>
		/// 	Determines whether an element is in the <see cref = "T:System.Collections.Generic.List`1" />.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "item" /> is found in the <see cref = "T:System.Collections.Generic.List`1" />; otherwise, false.
		/// </returns>
		/// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.List`1" />. The value can be null for reference types.</param>
		public bool Contains(IFrameListener item)
		{
			return _listeners.Contains(item);
		}

		/// <summary>
		/// 	Removes the first occurrence of a specific object from the <see cref = "T:System.Collections.Generic.List`1" />.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "item" /> is successfully removed; otherwise, false.  This method also returns false if <paramref name = "item" /> was not found in the <see cref = "T:System.Collections.Generic.List`1" />.
		/// </returns>
		/// <param name = "item">The object to remove from the <see cref = "T:System.Collections.Generic.List`1" />. The value can be null for reference types.</param>
		public bool Remove(IFrameListener item)
		{
			return _listeners.Remove(item);
		}

		/// <summary>
		/// Enables the listeners.
		/// </summary>
		public void EnableListeners()
		{
			if (IsListenersEnabled)
				return;

			//Root.Instance.EnableFrameDispatcher(this);
			IsListenersEnabled = true;
		}

		/// <summary>
		/// Disables the listeners.
		/// </summary>
		public void DisableListeners()
		{
			if (!IsListenersEnabled)
				return;

			//Root.Instance.DisableFrameDispatcher(this);
			IsListenersEnabled = false;
		}
	}
}
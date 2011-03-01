using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Native;
using InVision.Native.Ogre;

namespace InVision.Rendering.Listeners
{
	public sealed class FrameEventDispatcher : Handle, IFrameListener, IEventDispatcher
	{
		private readonly FrameEventDispatcherHandler frameEndedHandler;
		private readonly FrameEventDispatcherHandler frameStartedHandler;
		private readonly List<IFrameListener> listeners;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "FrameEventDispatcher" /> class.
		/// </summary>
		public FrameEventDispatcher()
		{
			frameStartedHandler = new FrameEventDispatcherHandler(OnFrameStarted);
			frameEndedHandler = new FrameEventDispatcherHandler(OnFrameEnded);

			SetHandle(NativeOgreFrameListener.New(frameStartedHandler, frameEndedHandler));

			listeners = new List<IFrameListener>();
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Runtime.InteropServices.SafeHandle"/> class specifying whether to perform a normal dispose operation.
		/// </summary>
		/// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
		protected override void Dispose(bool disposing)
		{
			if (!IsInvalid && IsListenersEnabled)
				DisableListeners();

			base.Dispose(disposing);
		}

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

			return listeners.Aggregate(result, (current, frameListener) => current && frameListener.OnFrameStarted(e));
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

			return listeners.Aggregate(result, (current, frameListener) => current && frameListener.OnFrameEnded(e));
		}

		#endregion

		/// <summary>
		/// 	Called when [frame started].
		/// </summary>
		/// <param name = "pEvent">The p event.</param>
		/// <returns></returns>
		private bool OnFrameStarted(IntPtr pEvent)
		{
			var e = pEvent.AsStructure<FrameEvent>();

			return OnFrameStarted(e);
		}

		/// <summary>
		/// 	Called when [frame ended].
		/// </summary>
		/// <param name = "pEvent">The p event.</param>
		/// <returns></returns>
		private bool OnFrameEnded(IntPtr pEvent)
		{
			var e = pEvent.AsStructure<FrameEvent>();

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
		/// 	Releases the specified handle.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			NativeOgreFrameListener.Delete(handle);
		}

		/// <summary>
		/// 	Adds an object to the end of the <see cref = "T:System.Collections.Generic.List`1" />.
		/// </summary>
		/// <param name = "item">The object to be added to the end of the <see cref = "T:System.Collections.Generic.List`1" />. The value can be null for reference types.</param>
		public void Add(IFrameListener item)
		{
			listeners.Add(item);
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
			return listeners.Contains(item);
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
			return listeners.Remove(item);
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is listeners enabled.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is listeners enabled; otherwise, <c>false</c>.
		/// </value>
		public bool IsListenersEnabled
		{
			get;
			private set;
		}

		/// <summary>
		/// Enables the listeners.
		/// </summary>
		public void EnableListeners()
		{
			if (IsListenersEnabled)
				return;

			Root.Instance.EnableFrameDispatcher(this);
			IsListenersEnabled = true;
		}

		/// <summary>
		/// Disables the listeners.
		/// </summary>
		public void DisableListeners()
		{
			if (!IsListenersEnabled)
				return;

			Root.Instance.DisableFrameDispatcher(this);
			IsListenersEnabled = false;
		}
	}
}
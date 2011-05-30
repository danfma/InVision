using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre.Listeners
{
	public sealed class FrameEventDispatcher : CppWrapper<ICustomFrameListener>, IFrameListener, IEventDispatcher
	{
		private readonly FrameEventHandler _frameEndedHandler;
		private readonly FrameEventHandler _frameRenderingQueued;
		private readonly FrameEventHandler _frameStartedHandler;
		private readonly List<IFrameListener> _listeners;

		/// <summary>
		/// Initializes a new instance of the <see cref="FrameEventDispatcher"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public FrameEventDispatcher(ICustomFrameListener nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "FrameEventDispatcher" /> class.
		/// </summary>
		public FrameEventDispatcher()
			: this(CreateCppInstance<ICustomFrameListener>())
		{
			_frameStartedHandler = new FrameEventHandler(OnFrameStarted);
			_frameEndedHandler = new FrameEventHandler(OnFrameEnded);
			_frameRenderingQueued = new FrameEventHandler(OnFrameRenderingQueued);
			_listeners = new List<IFrameListener>();

			Native.Construct(
				_frameStartedHandler,
				_frameEndedHandler,
				_frameRenderingQueued);
		}

		#region IFrameListener Members

		/// <summary>
		/// Called when [frame rendering queued].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns></returns>
		public bool OnFrameRenderingQueued(FrameEvent e)
		{
			bool result = true;

			if (FrameRenderingQueued != null)
				result = FrameRenderingQueued(e);

			return _listeners.Aggregate(result, (current, frameListener) => current && frameListener.OnFrameRenderingQueued(e));
		}

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
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.Destruct();

			base.Dispose(disposing);
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
		/// Occurs when [frame rendering queued].
		/// </summary>
		public event FrameEventHandler FrameRenderingQueued;

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
	}
}
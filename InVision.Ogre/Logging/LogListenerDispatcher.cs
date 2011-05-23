using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre.Logging
{
	public class LogListenerDispatcher : CppWrapper, ICppWrapper<ICustomLogListener>
	{
		#region Delegates

		/// <summary>
		/// Handler for the MessageLogged event
		/// </summary>
		public delegate void MessageLoggedHandler(
			string message, LogMessageLevel level, bool maskDebug, string name);

		#endregion

		private List<ILogListener> _listeners;
		private LogListenerMessageLoggedHandler _onMessageLogged;

		#region Construction and destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="LogListenerDispatcher"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public LogListenerDispatcher(ICppInterface nativeInstance)
			: base(nativeInstance)
		{
			_listeners = new List<ILogListener>();
			_onMessageLogged = OnMessageLogged;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogListenerDispatcher"/> class.
		/// </summary>
		public LogListenerDispatcher()
			: this(CreateCppInstance<ICustomLogListener>())
		{
			Native.Construct(_onMessageLogged).SetOwner(this);
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
				_onMessageLogged = null;

				_listeners.Clear();
				_listeners = null;
			}

			base.Dispose(disposing);
		}

		#endregion

		#region ICppWrapper<ICustomLogListener> Members

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new ICustomLogListener Native
		{
			get { return (ICustomLogListener)base.Native; }
		}

		#endregion

		/// <summary>
		/// Occurs when [message logged].
		/// </summary>
		public event MessageLoggedHandler MessageLogged;

		/// <summary>
		/// Adds an object to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="item">The object to be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public void Add(ILogListener item)
		{
			_listeners.Add(item);
		}

		/// <summary>
		/// Adds the elements of the specified collection to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="collection">The collection whose elements should be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The collection itself cannot be null, but it can contain elements that are null, if type <paramref name="T"/> is a reference type.</param><exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
		public void AddRange(IEnumerable<ILogListener> collection)
		{
			_listeners.AddRange(collection);
		}

		/// <summary>
		/// Removes all elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		public void Clear()
		{
			_listeners.Clear();
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is successfully removed; otherwise, false.  This method also returns false if <paramref name="item"/> was not found in the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public bool Remove(ILogListener item)
		{
			return _listeners.Remove(item);
		}

		/// <summary>
		/// Removes the all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <returns>
		/// The number of elements removed from the <see cref="T:System.Collections.Generic.List`1"/> .
		/// </returns>
		/// <param name="match">The <see cref="T:System.Predicate`1"/> delegate that defines the conditions of the elements to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="match"/> is null.</exception>
		public int RemoveAll(Predicate<ILogListener> match)
		{
			return _listeners.RemoveAll(match);
		}

		/// <summary>
		/// Removes the element at the specified index of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based index of the element to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.Generic.List`1.Count"/>.</exception>
		public void RemoveAt(int index)
		{
			_listeners.RemoveAt(index);
		}

		/// <summary>
		/// Removes a range of elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range of elements to remove.</param><param name="count">The number of elements to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="count"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="index"/> and <paramref name="count"/> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1"/>.</exception>
		public void RemoveRange(int index, int count)
		{
			_listeners.RemoveRange(index, count);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.List`1.Enumerator"/> for the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		public List<ILogListener>.Enumerator GetEnumerator()
		{
			return _listeners.GetEnumerator();
		}

		/// <summary>
		/// Creates a shallow copy of a range of elements in the source <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// A shallow copy of a range of elements in the source <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		/// <param name="index">The zero-based <see cref="T:System.Collections.Generic.List`1"/> index at which the range starts.</param><param name="count">The number of elements in the range.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="count"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="index"/> and <paramref name="count"/> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1"/>.</exception>
		public List<ILogListener> GetRange(int index, int count)
		{
			return _listeners.GetRange(index, count);
		}

		/// <summary>
		/// Called when [message logged].
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="level">The level.</param>
		/// <param name="maskdebug">if set to <c>true</c> [maskdebug].</param>
		/// <param name="name">The name.</param>
		private void OnMessageLogged(string message, LogMessageLevel level, bool maskdebug, string name)
		{
			lock (_listeners)
			{
				foreach (ILogListener listener in _listeners)
				{
					listener.MessageLogged(message, level, maskdebug, name);
				}
			}

			if (MessageLogged != null)
				MessageLogged(message, level, maskdebug, name);
		}
	}
}
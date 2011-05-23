using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre.Logging
{
	public class Log : CppWrapper, ICppWrapper<ILog>
	{
		private LogListenerDispatcher _listener;

		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="Log"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public Log(ICppInterface nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (_listener != null)
				DeactivateListener();

			if (disposing)
				_listener = null;

			base.Dispose(disposing);
		}

		#endregion

		#region ICppWrapper<ILog> Members

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new ILog Native
		{
			get { return (ILog) base.Native; }
		}

		#endregion

		/// <summary>
		/// Activates the listener.
		/// </summary>
		public void ActivateListener()
		{
			if (_listener != null)
				return;

			_listener = new LogListenerDispatcher();
			Native.AddListener(_listener.Native);
		}

		/// <summary>
		/// Deactivates the listener.
		/// </summary>
		public void DeactivateListener()
		{
			if (_listener == null)
				return;

			Native.RemoveListener(_listener.Native);
			_listener.Dispose();
			_listener = null;
		}

		/// <summary>
		/// Occurs when [message logged].
		/// </summary>
		public event LogListenerDispatcher.MessageLoggedHandler MessageLogged
		{
			add
			{
				if (_listener == null)
					ActivateListener();

				_listener.MessageLogged += value;
			}
			remove
			{
				if (_listener == null)
					ActivateListener();

				_listener.MessageLogged -= value;
			}
		}

		/// <summary>
		/// Adds an object to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="item">The object to be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public void Add(ILogListener item)
		{
			_listener.Add(item);
		}

		/// <summary>
		/// Adds the elements of the specified collection to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="collection">The collection whose elements should be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The collection itself cannot be null, but it can contain elements that are null, if type <paramref name="T"/> is a reference type.</param><exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
		public void AddRange(IEnumerable<ILogListener> collection)
		{
			_listener.AddRange(collection);
		}

		/// <summary>
		/// Removes all elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		public void Clear()
		{
			_listener.Clear();
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
			return _listener.Remove(item);
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
			return _listener.RemoveAll(match);
		}

		/// <summary>
		/// Removes the element at the specified index of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based index of the element to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.Generic.List`1.Count"/>.</exception>
		public void RemoveAt(int index)
		{
			_listener.RemoveAt(index);
		}

		/// <summary>
		/// Removes a range of elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range of elements to remove.</param><param name="count">The number of elements to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="count"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="index"/> and <paramref name="count"/> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1"/>.</exception>
		public void RemoveRange(int index, int count)
		{
			_listener.RemoveRange(index, count);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.List`1.Enumerator"/> for the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		public List<ILogListener>.Enumerator GetEnumerator()
		{
			return _listener.GetEnumerator();
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
			return _listener.GetRange(index, count);
		}
	}
}
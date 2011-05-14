using System;
using System.Collections.Generic;

namespace InVision.Framework
{
	public class GameStateManager
	{
		private const int NoneSelected = -1;

		private readonly List<GameState> _states;
		private int _currentStateIndex;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameStateManager"/> class.
		/// </summary>
		public GameStateManager()
		{
			_states = new List<GameState>();
			_currentStateIndex = -1;
		}

		/// <summary>
		/// Gets the states.
		/// </summary>
		/// <value>The states.</value>
		public IEnumerable<GameState> States
		{
			get { return _states; }
		}

		/// <summary>
		/// Sets the start.
		/// </summary>
		/// <value>The start.</value>
		public GameState Start
		{
			get { return _currentStateIndex == NoneSelected ? null : _states[_currentStateIndex]; }
			set { _currentStateIndex = _states.IndexOf(value); }
		}

		/// <summary>
		/// Gets the number of elements actually contained in the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// The number of elements actually contained in the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		public int Count
		{
			get { return _states.Count; }
		}

		/// <summary>
		/// Adds an object to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="item">The object to be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public void Add(GameState item)
		{
			_states.Add(item);
		}

		/// <summary>
		/// Adds the elements of the specified collection to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="collection">The collection whose elements should be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The collection itself cannot be null, but it can contain elements that are null, if type <paramref name="T"/> is a reference type.</param><exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
		public void AddRange(IEnumerable<GameState> collection)
		{
			_states.AddRange(collection);
		}

		/// <summary>
		/// Removes all elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		public void Clear()
		{
			_states.Clear();
		}

		/// <summary>
		/// Determines whether an element is in the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.List`1"/>; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public bool Contains(GameState item)
		{
			return _states.Contains(item);
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.List`1"/> contains elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.List`1"/> contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.
		/// </returns>
		/// <param name="match">The <see cref="T:System.Predicate`1"/> delegate that defines the conditions of the elements to search for.</param><exception cref="T:System.ArgumentNullException"><paramref name="match"/> is null.</exception>
		public bool Exists(Predicate<GameState> match)
		{
			return _states.Exists(match);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is successfully removed; otherwise, false.  This method also returns false if <paramref name="item"/> was not found in the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public bool Remove(GameState item)
		{
			return _states.Remove(item);
		}

		/// <summary>
		/// Removes the all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <returns>
		/// The number of elements removed from the <see cref="T:System.Collections.Generic.List`1"/> .
		/// </returns>
		/// <param name="match">The <see cref="T:System.Predicate`1"/> delegate that defines the conditions of the elements to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="match"/> is null.</exception>
		public int RemoveAll(Predicate<GameState> match)
		{
			return _states.RemoveAll(match);
		}

		/// <summary>
		/// Removes the element at the specified index of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based index of the element to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.Generic.List`1.Count"/>.</exception>
		public void RemoveAt(int index)
		{
			_states.RemoveAt(index);
		}

		/// <summary>
		/// Removes a range of elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range of elements to remove.</param><param name="count">The number of elements to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="count"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="index"/> and <paramref name="count"/> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1"/>.</exception>
		public void RemoveRange(int index, int count)
		{
			_states.RemoveRange(index, count);
		}
	}
}
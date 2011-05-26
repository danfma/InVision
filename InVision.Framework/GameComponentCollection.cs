using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace InVision.Framework
{
	public class GameComponentCollection : DisposableObject, IEnumerable<IGameComponent>
	{
		private ConcurrentDictionary<string, IGameComponent> _componentsRegister;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameComponentCollection"/> class.
		/// </summary>
		public GameComponentCollection()
		{
			_componentsRegister = new ConcurrentDictionary<string, IGameComponent>();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (_componentsRegister != null)
			{
				foreach (var componentRegistry in _componentsRegister)
				{
					componentRegistry.Value.Dispose();
				}

				_componentsRegister.Clear();
			}

			if (disposing)
				_componentsRegister = null;
		}

		/// <summary>
		/// Adds the specified key and value to the dictionary.
		/// </summary>
		/// <param name="key">The key of the element to add.</param><param name="value">The value of the element to add. The value can be null for reference types.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.</exception>
		public void Add(string key, IGameComponent value)
		{
			_componentsRegister.TryAdd(key, value);
		}

		/// <summary>
		/// Removes all keys and values from the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		public void Clear()
		{
			_componentsRegister.Clear();
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains the specified key.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool ContainsKey(string key)
		{
			return _componentsRegister.ContainsKey(key);
		}

		/// <summary>
		/// Removes the value with the specified key from the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// true if the element is successfully found and removed; otherwise, false.  This method returns false if <paramref name="key"/> is not found in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		/// <param name="key">The key of the element to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool Remove(string key)
		{
			IGameComponent component;

			return _componentsRegister.TryRemove(key, out component);
		}

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key of the value to get.</param><param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool TryGetValue(string key, out IGameComponent value)
		{
			return _componentsRegister.TryGetValue(key, out value);
		}

		/// <summary>
		/// Gets a collection containing the keys in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.Dictionary`2.KeyCollection"/> containing the keys in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		public IEnumerable<string> Keys
		{
			get { return _componentsRegister.Keys; }
		}

		/// <summary>
		/// Gets a collection containing the values in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.Dictionary`2.ValueCollection"/> containing the values in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		public IEnumerable<IGameComponent> Values
		{
			get { return _componentsRegister.Values; }
		}

		/// <summary>
		/// Gets the number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// The number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		public int Count
		{
			get { return _componentsRegister.Count; }
		}

		/// <summary>
		/// Gets or sets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// The value associated with the specified key. If the specified key is not found, a get operation throws a <see cref="T:System.Collections.Generic.KeyNotFoundException"/>, and a set operation creates a new element with the specified key.
		/// </returns>
		/// <param name="key">The key of the value to get or set.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key"/> does not exist in the collection.</exception>
		public IGameComponent this[string key]
		{
			get { return _componentsRegister[key]; }
			set { _componentsRegister[key] = value; }
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<IGameComponent> GetEnumerator()
		{
			return _componentsRegister.Values.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist.
		/// </summary>
		/// <returns>
		/// The value for the key. This will be either the existing value for the key if the key is already in the dictionary, or the new value for the key as returned by valueFactory if the key was not in the dictionary.
		/// </returns>
		/// <param name="key">The key of the element to add.</param><param name="valueFactory">The function used to generate a value for the key</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="valueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public IGameComponent GetOrAdd(string key, Func<string, IGameComponent> valueFactory)
		{
			return _componentsRegister.GetOrAdd(key, valueFactory);
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist.
		/// </summary>
		/// <returns>
		/// The value for the key. This will be either the existing value for the key if the key is already in the dictionary, or the new value if the key was not in the dictionary.
		/// </returns>
		/// <param name="key">The key of the element to add.</param><param name="value">the value to be added, if the key does not already exist</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public IGameComponent GetOrAdd(string key, IGameComponent value)
		{
			return _componentsRegister.GetOrAdd(key, value);
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist, or updates a key/value pair in the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key already exists.
		/// </summary>
		/// <returns>
		/// The new value for the key. This will be either be the result of addValueFactory (if the key was absent) or the result of updateValueFactory (if the key was present).
		/// </returns>
		/// <param name="key">The key to be added or whose value should be updated</param><param name="addValueFactory">The function used to generate a value for an absent key</param><param name="updateValueFactory">The function used to generate a new value for an existing key based on the key's existing value</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="addValueFactory"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="updateValueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public IGameComponent AddOrUpdate(string key, Func<string, IGameComponent> addValueFactory, Func<string, IGameComponent, IGameComponent> updateValueFactory)
		{
			return _componentsRegister.AddOrUpdate(key, addValueFactory, updateValueFactory);
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist, or updates a key/value pair in the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key already exists.
		/// </summary>
		/// <returns>
		/// The new value for the key. This will be either be addValue (if the key was absent) or the result of updateValueFactory (if the key was present).
		/// </returns>
		/// <param name="key">The key to be added or whose value should be updated</param><param name="addValue">The value to be added for an absent key</param><param name="updateValueFactory">The function used to generate a new value for an existing key based on the key's existing value</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="updateValueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public IGameComponent AddOrUpdate(string key, IGameComponent addValue, Func<string, IGameComponent, IGameComponent> updateValueFactory)
		{
			return _componentsRegister.AddOrUpdate(key, addValue, updateValueFactory);
		}
	}
}
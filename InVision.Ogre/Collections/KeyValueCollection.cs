using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InVision.Ogre.Collections
{
	public abstract class KeyValueCollection<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
	{
		private static readonly KeyValuePair<TKey, TValue> DefaultPairValue = default(KeyValuePair<TKey, TValue>);
		private readonly List<KeyValuePair<TKey, TValue>> pairs;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "KeyValueCollection{TKey,TValue}" /> class.
		/// </summary>
		protected KeyValueCollection()
		{
			pairs = new List<KeyValuePair<TKey, TValue>>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyValueCollection{TKey,TValue}"/> class.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		protected KeyValueCollection(int capacity)
		{
			pairs = new List<KeyValuePair<TKey, TValue>>(capacity);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyValueCollection{TKey,TValue}"/> class.
		/// </summary>
		/// <param name="enumerablePairs">The enumerable pairs.</param>
		protected KeyValueCollection(IEnumerable<KeyValuePair<TKey, TValue>> enumerablePairs)
		{
			pairs = new List<KeyValuePair<TKey, TValue>>(enumerablePairs);
		}

		/// <summary>
		/// 	Gets the number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <returns>
		/// 	The number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </returns>
		public int Count
		{
			get { return pairs.Count; }
		}

		/// <summary>
		/// 	Gets a value indicating whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.
		/// </summary>
		/// <returns>
		/// 	true if the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.
		/// </returns>
		public bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// 	Gets or sets the first element with the specified key.
		/// </summary>
		/// <returns>
		/// 	The element with the specified key.
		/// </returns>
		/// <param name = "key">The key of the element to get or set.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.</exception>
		/// <exception cref = "T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name = "key" /> is not found.</exception>
		/// <exception cref = "T:System.NotSupportedException">The property is set and the <see cref = "T:System.Collections.Generic.IDictionary`2" /> is read-only.</exception>
		public TValue this[TKey key]
		{
			get
			{
				var pair = pairs.Find(p => Equals(p.Key, key));

				return Equals(pair, DefaultPairValue) ? default(TValue) : pair.Value;
			}
			set
			{
				var pairIndex = pairs.FindIndex(p => Equals(p.Key, key));

				if (pairIndex == -1)
					Add(key, value);
				else
					pairs[pairIndex] = new KeyValuePair<TKey, TValue>(key, value);
			}
		}

		/// <summary>
		/// 	Gets an <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the keys of the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
		/// </summary>
		/// <returns>
		/// 	An <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the keys of the object that implements <see cref = "T:System.Collections.Generic.IDictionary`2" />.
		/// </returns>
		public IEnumerable<TKey> Keys
		{
			get { return pairs.Select(p => p.Key); }
		}

		/// <summary>
		/// 	Gets an <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the values in the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
		/// </summary>
		/// <returns>
		/// 	An <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the values in the object that implements <see cref = "T:System.Collections.Generic.IDictionary`2" />.
		/// </returns>
		public IEnumerable<TValue> Values
		{
			get { return pairs.Select(p => p.Value); }
		}

		#region IEnumerable<KeyValuePair<TKey,TValue>> Members

		/// <summary>
		/// 	Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// 	A <see cref = "T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return pairs.GetEnumerator();
		}

		/// <summary>
		/// 	Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// 	An <see cref = "T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		/// <summary>
		/// 	Adds an item to the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <param name = "item">The object to add to the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			pairs.Add(item);
		}

		/// <summary>
		/// 	Removes all items from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only. </exception>
		public void Clear()
		{
			pairs.Clear();
		}

		/// <summary>
		/// 	Determines whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> contains a specific value.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "item" /> is found in the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false.
		/// </returns>
		/// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return pairs.Contains(item);
		}

		/// <summary>
		/// 	Copies the elements of the <see cref = "T:System.Collections.Generic.ICollection`1" /> to an <see cref = "T:System.Array" />, starting at a particular <see cref = "T:System.Array" /> index.
		/// </summary>
		/// <param name = "array">The one-dimensional <see cref = "T:System.Array" /> that is the destination of the elements copied from <see cref = "T:System.Collections.Generic.ICollection`1" />. The <see cref = "T:System.Array" /> must have zero-based indexing.</param>
		/// <param name = "arrayIndex">The zero-based index in <paramref name = "array" /> at which copying begins.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "array" /> is null.</exception>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "arrayIndex" /> is less than 0.</exception>
		/// <exception cref = "T:System.ArgumentException"><paramref name = "array" /> is multidimensional.-or-The number of elements in the source <see cref = "T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref name = "arrayIndex" /> to the end of the destination <paramref name = "array" />.-or-Type <paramref name = "T" /> cannot be cast automatically to the type of the destination <paramref name = "array" />.</exception>
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			pairs.CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// 	Removes the first occurrence of a specific object from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "item" /> was successfully removed from the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name = "item" /> is not found in the original <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </returns>
		/// <param name = "item">The object to remove from the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return pairs.Remove(item);
		}

		/// <summary>
		/// 	Determines whether the <see cref = "T:System.Collections.Generic.IDictionary`2" /> contains an element with the specified key.
		/// </summary>
		/// <returns>
		/// 	true if the <see cref = "T:System.Collections.Generic.IDictionary`2" /> contains an element with the key; otherwise, false.
		/// </returns>
		/// <param name = "key">The key to locate in the <see cref = "T:System.Collections.Generic.IDictionary`2" />.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.</exception>
		public bool ContainsKey(TKey key)
		{
			return pairs.Any(p => Equals(p.Key, key));
		}

		/// <summary>
		/// 	Adds an element with the provided key and value to the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
		/// </summary>
		/// <param name = "key">The object to use as the key of the element to add.</param>
		/// <param name = "value">The object to use as the value of the element to add.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.</exception>
		/// <exception cref = "T:System.ArgumentException">An element with the same key already exists in the <see cref = "T:System.Collections.Generic.IDictionary`2" />.</exception>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IDictionary`2" /> is read-only.</exception>
		public void Add(TKey key, TValue value)
		{
			Add(new KeyValuePair<TKey, TValue>(key, value));
		}

		/// <summary>
		/// 	Removes the element with the specified key from the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
		/// </summary>
		/// <returns>
		/// 	true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name = "key" /> was not found in the original <see cref = "T:System.Collections.Generic.IDictionary`2" />.
		/// </returns>
		/// <param name = "key">The key of the element to remove.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.</exception>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IDictionary`2" /> is read-only.</exception>
		public bool Remove(TKey key)
		{
			var pair = pairs.Find(p => Equals(p.Key, key));

			return !Equals(pair, DefaultPairValue) && Remove(pair);
		}

		/// <summary>
		/// 	Gets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// 	true if the object that implements <see cref = "T:System.Collections.Generic.IDictionary`2" /> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name = "key">The key whose value to get.</param>
		/// <param name = "value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name = "value" /> parameter. This parameter is passed uninitialized.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.</exception>
		public bool TryGetValue(TKey key, out TValue value)
		{
			var pair = pairs.Find(p => Equals(p.Key, key));

			if (!Equals(pair, DefaultPairValue))
			{
				value = pair.Value;
				return true;
			}

			value = default(TValue);

			return false;
		}
	}
}
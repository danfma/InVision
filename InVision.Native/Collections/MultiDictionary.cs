using System.Collections.Generic;
using System.Linq;

namespace InVision.Native.Collections
{
	public class MultiDictionary<TKey, TValue> : List<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MultiDictionary&lt;TKey, TValue&gt;"/> class.
		/// </summary>
		public MultiDictionary()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiDictionary&lt;TKey, TValue&gt;"/> class.
		/// </summary>
		/// <param name="collection">The collection.</param>
		public MultiDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
			: base(collection)
		{
		}

		#region IDictionary<TKey,TValue> Members

		/// <summary>
		/// Determines whether the specified key contains key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// 	<c>true</c> if the specified key contains key; otherwise, <c>false</c>.
		/// </returns>
		public bool ContainsKey(TKey key)
		{
			return this.Any(p => Equals(p.Key, key));
		}

		/// <summary>
		/// Adds the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void Add(TKey key, TValue value)
		{
			Add(new KeyValuePair<TKey, TValue>(key, value));
		}

		/// <summary>
		/// Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </summary>
		/// <returns>
		/// true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name="key"/> was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </returns>
		/// <param name="key">The key of the element to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
		public bool Remove(TKey key)
		{
			int itemIndex = FindIndex(pair => Equals(pair.Key, key));

			if (itemIndex != -1)
			{
				RemoveAt(itemIndex);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key whose value to get.</param><param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool TryGetValue(TKey key, out TValue value)
		{
			KeyValuePair<TKey, TValue> item = Find(pair => Equals(pair.Key, key));

			if (Equals(item, default(KeyValuePair<TKey, string>)))
			{
				value = default(TValue);

				return false;
			}

			value = item.Value;

			return true;
		}

		/// <summary>
		/// Gets or sets the element with the specified key.
		/// </summary>
		/// <returns>
		/// The element with the specified key.
		/// </returns>
		/// <param name="key">The key of the element to get or set.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key"/> is not found.</exception><exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
		public TValue this[TKey key]
		{
			get
			{
				int index = FindIndex(p => Equals(p.Key, key));

				if (index == -1)
					throw new KeyNotFoundException("Key was not found: " + key);

				return this[index].Value;
			}
			set
			{
				int index = FindIndex(p => Equals(p.Key, key));

				if (index == -1)
					Add(key, value);
				else
					base[index] = new KeyValuePair<TKey, TValue>(key, value);
			}
		}

		/// <summary>
		/// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </returns>
		public ICollection<TKey> Keys
		{
			get { return this.Select(p => p.Key).ToList(); }
		}

		/// <summary>
		/// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </returns>
		public ICollection<TValue> Values
		{
			get { return this.Select(p => p.Value).ToList(); }
		}

		#endregion
	}
}
using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre.Collections
{
	public class NameValueCollection : KeyValueCollection<string, string>
	{
		private InternalCollection internalCollection;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "NameValueCollection" /> class.
		/// </summary>
		public NameValueCollection()
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "NameValueCollection" /> class.
		/// </summary>
		/// <param name = "capacity">The capacity.</param>
		public NameValueCollection(int capacity)
			: base(capacity)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "NameValueCollection" /> class.
		/// </summary>
		/// <param name = "enumerablePairs">The enumerable pairs.</param>
		public NameValueCollection(IEnumerable<KeyValuePair<string, string>> enumerablePairs)
			: base(enumerablePairs)
		{
		}

		/// <summary>
		/// Gets the collection.
		/// </summary>
		/// <value>The collection.</value>
		private InternalCollection Collection
		{
			get { return internalCollection ?? (internalCollection = new InternalCollection()); }
		}

		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		internal IntPtr CollectionHandle
		{
			get { return Collection.DangerousGetHandle(); }
		}

		/// <summary>
		/// 	Flushes this instance.
		/// </summary>
		public void Flush()
		{
			InternalCollection collection = Collection;

			collection.Clear();

			foreach (var pair in this)
			{
				collection.Add(pair.Key, pair.Value);
			}
		}

		/// <summary>
		/// 	Loads this instance.
		/// </summary>
		public void Load()
		{
			Clear();

			foreach (var pair in Collection.Pairs)
			{
				Add(pair);
			}
		}

		#region Nested type: NativeCollectionHandle

		/// <summary>
		/// </summary>
		internal sealed class InternalCollection : Handle
		{
			/// <summary>
			/// 	Initializes a new instance of the <see cref = "InternalCollection" /> class.
			/// </summary>
			public InternalCollection()
			{
				SetHandle(NativeNameValueCollection.New());
			}

			/// <summary>
			/// 	Initializes a new instance of the <see cref = "InternalCollection" /> class.
			/// </summary>
			/// <param name = "pSelf">The p self.</param>
			private InternalCollection(IntPtr pSelf)
			{
				SetHandle(pSelf);
			}

			/// <summary>
			/// 	Gets the count.
			/// </summary>
			/// <value>The count.</value>
			public int Count
			{
				get { return NativeNameValueCollection.Count(handle); }
			}

			/// <summary>
			/// 	Gets the pairs.
			/// </summary>
			/// <value>The pairs.</value>
			public IEnumerable<KeyValuePair<string, string>> Pairs
			{
				get
				{
					return NativeNameValueCollection.GetEnumerator(handle).
						AsAutoEnumeration<NameValuePair>(NativeOgreUtilities.DeleteNameValuePair).
						Select(p => new KeyValuePair<string, string>(p.Key, p.Value));
				}
			}

			/// <summary>
			/// 	Releases the specified handle.
			/// </summary>
			/// <returns></returns>
			protected override void ReleaseValidHandle()
			{
				NativeNameValueCollection.Delete(handle);
			}

			/// <summary>
			/// 	Adds the specified key.
			/// </summary>
			/// <param name = "key">The key.</param>
			/// <param name = "value">The value.</param>
			public void Add(string key, string value)
			{
				NativeNameValueCollection.Add(handle, key, value);
			}

			/// <summary>
			/// 	Removes the specified key.
			/// </summary>
			/// <param name = "key">The key.</param>
			public void Remove(string key)
			{
				NativeNameValueCollection.Remove(handle, key);
			}

			/// <summary>
			/// 	Clears this instance.
			/// </summary>
			public void Clear()
			{
				NativeNameValueCollection.Clear(handle);
			}
		}

		#endregion
	}
}
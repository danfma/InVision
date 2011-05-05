using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre.Collections
{
	public class NameValueDictionary : Dictionary<string, string>
	{
		private InternalDictionary internalDictionary;

		public NameValueDictionary()
		{
		}

		public NameValueDictionary(int capacity)
			: base(capacity)
		{
		}

		public NameValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}

		public NameValueDictionary(int capacity, IEqualityComparer<string> comparer)
			: base(capacity, comparer)
		{
		}

		public NameValueDictionary(IDictionary<string, string> dictionary)
			: base(dictionary)
		{
		}

		public NameValueDictionary(IDictionary<string, string> dictionary, IEqualityComparer<string> comparer)
			: base(dictionary, comparer)
		{
		}


		/// <summary>
		/// 	Gets the native handler.
		/// </summary>
		/// <value>The native handler.</value>
		private InternalDictionary Dictionary
		{
			get { return internalDictionary ?? (internalDictionary = new InternalDictionary()); }
		}

		/// <summary>
		/// Gets the dictionary handle.
		/// </summary>
		/// <value>The dictionary handle.</value>
		internal IntPtr DictionaryHandle
		{
			get { return Dictionary.DangerousGetHandle(); }
		}

		/// <summary>
		/// 	Flushes this instance.
		/// </summary>
		public void Flush()
		{
			InternalDictionary dic = Dictionary;

			dic.Clear();

			foreach (var pair in this)
			{
				dic.Add(pair.Key, pair.Value);
			}
		}

		/// <summary>
		/// 	Loads this instance.
		/// </summary>
		public void Load()
		{
			Clear();

			foreach (NameValuePair pair in Dictionary.Pairs)
			{
				this[pair.Key] = pair.Value;
			}
		}

		#region Nested type: NameValuePairList

		/// <summary>
		/// </summary>
		internal sealed class InternalDictionary : Handle
		{
			/// <summary>
			/// 	Initializes a new instance of the <see cref = "InternalDictionary" /> class.
			/// </summary>
			public InternalDictionary()
			{
				SetHandle(NativeNameValuePairList.New());
			}

			/// <summary>
			/// 	Initializes a new instance of the <see cref = "InternalDictionary" /> class.
			/// </summary>
			/// <param name = "pSelf">The p self.</param>
			private InternalDictionary(IntPtr pSelf)
			{
				SetHandle(pSelf);
			}

			/// <summary>
			/// 	Gets the count.
			/// </summary>
			/// <value>The count.</value>
			public int Count
			{
				get { return NativeNameValuePairList.Count(handle); }
			}

			/// <summary>
			/// 	Gets the pairs.
			/// </summary>
			/// <value>The pairs.</value>
			public IEnumerable<NameValuePair> Pairs
			{
				get
				{
					return NativeNameValuePairList.GetPairs(handle).
						AsAutoEnumeration<NameValuePair>(NativeOgreUtilities.DeleteNameValuePair);
				}
			}

			/// <summary>
			/// 	Releases the specified handle.
			/// </summary>
			/// <returns></returns>
			protected override void ReleaseValidHandle()
			{
				NativeNameValuePairList.Delete(handle);
			}

			/// <summary>
			/// 	Copies this instance.
			/// </summary>
			/// <returns></returns>
			public InternalDictionary Copy()
			{
				IntPtr handleCopy = NativeNameValuePairList.Copy(handle);

				return new InternalDictionary(handleCopy);
			}

			/// <summary>
			/// 	Adds the specified key.
			/// </summary>
			/// <param name = "key">The key.</param>
			/// <param name = "value">The value.</param>
			public void Add(string key, string value)
			{
				NativeNameValuePairList.Add(handle, key, value);
			}

			/// <summary>
			/// 	Removes the specified key.
			/// </summary>
			/// <param name = "key">The key.</param>
			public void Remove(string key)
			{
				NativeNameValuePairList.Remove(handle, key);
			}

			/// <summary>
			/// 	Clears this instance.
			/// </summary>
			public void Clear()
			{
				NativeNameValuePairList.Clear(handle);
			}

			/// <summary>
			/// 	Converts from.
			/// </summary>
			/// <param name = "pairs">The pairs.</param>
			/// <returns></returns>
			public static InternalDictionary ConvertFrom(NameValuePair[] pairs)
			{
				IntPtr handle = NativeNameValuePairList.Convert(pairs, pairs.Length);

				return new InternalDictionary(handle);
			}
		}

		#endregion
	}
}
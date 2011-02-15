using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D.Util
{
	public class NameValueDictionary : Dictionary<string, string>
	{
		private NameValuePairList nameValuePairList;

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

		protected NameValueDictionary(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}


		/// <summary>
		/// 	Gets the native handler.
		/// </summary>
		/// <value>The native handler.</value>
		internal NameValuePairList NativeHandler
		{
			get { return nameValuePairList ?? (nameValuePairList = new NameValuePairList()); }
		}

		/// <summary>
		/// 	Flushes this instance.
		/// </summary>
		public void Flush()
		{
			NameValuePairList dic = NativeHandler;

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

			foreach (NameValuePair pair in NativeHandler.Pairs)
			{
				this[pair.Key] = pair.Value;
			}
		}

		#region Nested type: NameValuePairList

		/// <summary>
		/// </summary>
		internal sealed class NameValuePairList : Handle
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="NameValuePairList"/> class.
			/// </summary>
			public NameValuePairList()
			{
				SetHandle(NativeNameValuePairList.New());
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="NameValuePairList"/> class.
			/// </summary>
			/// <param name="pSelf">The p self.</param>
			private NameValuePairList(IntPtr pSelf)
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
						AsAutoEnumeration<NameValuePair>(new Action<IntPtr>(NativeUtilities.DeleteNameValuePair));
				}
			}

			/// <summary>
			/// 	Releases the specified handle.
			/// </summary>
			/// <param name = "pSelf">The handle.</param>
			/// <returns></returns>
			protected override bool Release(IntPtr pSelf)
			{
				NativeNameValuePairList.Delete(pSelf);
				return true;
			}

			/// <summary>
			/// 	Copies this instance.
			/// </summary>
			/// <returns></returns>
			public NameValuePairList Copy()
			{
				IntPtr handleCopy = NativeNameValuePairList.Copy(handle);

				return new NameValuePairList(handleCopy);
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
			public static NameValuePairList ConvertFrom(NameValuePair[] pairs)
			{
				IntPtr handle = NativeNameValuePairList.Convert(pairs, pairs.Length);

				return new NameValuePairList(handle);
			}
		}

		#endregion
	}
}
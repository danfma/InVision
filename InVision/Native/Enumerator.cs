using System;
using System.Collections;
using System.Collections.Generic;

namespace InVision.Native
{
	internal class Enumerator<T> : Handle, IEnumerator<KeyValuePair<IntPtr, T>>
	{
		private Func<IntPtr, T> converter;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Enumerator{T}" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		public Enumerator(IntPtr pSelf, bool ownsHandle = true)
			: base(pSelf, ownsHandle)
		{
			
		}

		#region IEnumerator<KeyValuePair<IntPtr,T>> Members

		/// <summary>
		/// 	Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <returns>
		/// 	true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
		/// </returns>
		/// <exception cref = "T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
		/// <filterpriority>2</filterpriority>
		public bool MoveNext()
		{
			return NativeEnumerator.MoveNext(handle);
		}

		/// <summary>
		/// 	Sets the enumerator to its initial position, which is before the first element in the collection.
		/// </summary>
		/// <exception cref = "T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
		/// <filterpriority>2</filterpriority>
		public void Reset()
		{
			NativeEnumerator.Reset(handle);
		}

		/// <summary>
		/// 	Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		/// <returns>
		/// 	The element in the collection at the current position of the enumerator.
		/// </returns>
		public KeyValuePair<IntPtr, T> Current
		{
			get
			{
				IntPtr pData = NativeEnumerator.GetCurrent(handle);

				return new KeyValuePair<IntPtr, T>(pData, converter(pData));
			}
		}

		/// <summary>
		/// 	Gets the current element in the collection.
		/// </summary>
		/// <returns>
		/// 	The current element in the collection.
		/// </returns>
		/// <exception cref = "T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception>
		/// <filterpriority>2</filterpriority>
		object IEnumerator.Current
		{
			get { return Current; }
		}

		#endregion

		/// <summary>
		/// 	Releases the specified handle.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			NativeEnumerator.Delete(handle);
		}

		/// <summary>
		/// 	Sets the converter.
		/// </summary>
		/// <param name = "converter">The converter.</param>
		public void SetConverter(Func<IntPtr, T> converter)
		{
			this.converter = converter;
		}
	}
}
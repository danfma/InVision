using System;
using System.Collections.Generic;
using InVision.Native;

namespace InVision.Collections
{
	public class ValueTypeVectorList<T> : VectorList<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ValueTypeVectorList&lt;T&gt;"/> class.
		/// </summary>
		public ValueTypeVectorList()
			: base(NativeVectorList.NewValueTypeVectorList(GetVectorListItemType()), true)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ValueTypeVectorList&lt;T&gt;" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		protected internal ValueTypeVectorList(IntPtr pSelf)
			: base(pSelf, false)
		{
		}

		/// <summary>
		/// Gets the type of the vector list item.
		/// </summary>
		/// <returns></returns>
		private static VectorListItem GetVectorListItemType()
		{
			switch (Type.GetTypeCode(typeof(T)))
			{
				case TypeCode.Int16:
					return VectorListItem.Int16;

				case TypeCode.Int32:
					return VectorListItem.Int32;

				default:
					throw new InvalidOperationException("The specified type is not supported: " + typeof(T).FullName);
			}
		}

		/// <summary>
		/// 	Gets or sets the element at the specified index.
		/// </summary>
		/// <returns>
		/// 	The element at the specified index.
		/// </returns>
		/// <param name = "index">The zero-based index of the element to get or set.</param>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see cref = "T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref = "T:System.NotSupportedException">The property is set and the <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
		public override T this[int index]
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		/// <summary>
		/// 	Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// 	A <see cref = "T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public override IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Adds an item to the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <param name = "item">The object to add to the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public override void Add(T item)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Determines whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> contains a specific value.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "item" /> is found in the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false.
		/// </returns>
		/// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		public override bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Copies the elements of the <see cref = "T:System.Collections.Generic.ICollection`1" /> to an <see cref = "T:System.Array" />, starting at a particular <see cref = "T:System.Array" /> index.
		/// </summary>
		/// <param name = "array">The one-dimensional <see cref = "T:System.Array" /> that is the destination of the elements copied from <see cref = "T:System.Collections.Generic.ICollection`1" />. The <see cref = "T:System.Array" /> must have zero-based indexing.</param>
		/// <param name = "arrayIndex">The zero-based index in <paramref name = "array" /> at which copying begins.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "array" /> is null.</exception>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "arrayIndex" /> is less than 0.</exception>
		/// <exception cref = "T:System.ArgumentException"><paramref name = "array" /> is multidimensional.-or-The number of elements in the source <see cref = "T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref name = "arrayIndex" /> to the end of the destination <paramref name = "array" />.-or-Type <paramref name = "T" /> cannot be cast automatically to the type of the destination <paramref name = "array" />.</exception>
		public override void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Removes the first occurrence of a specific object from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "item" /> was successfully removed from the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name = "item" /> is not found in the original <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </returns>
		/// <param name = "item">The object to remove from the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public override bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Determines the index of a specific item in the <see cref = "T:System.Collections.Generic.IList`1" />.
		/// </summary>
		/// <returns>
		/// 	The index of <paramref name = "item" /> if found in the list; otherwise, -1.
		/// </returns>
		/// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.IList`1" />.</param>
		public override int IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Inserts an item to the <see cref = "T:System.Collections.Generic.IList`1" /> at the specified index.
		/// </summary>
		/// <param name = "index">The zero-based index at which <paramref name = "item" /> should be inserted.</param>
		/// <param name = "item">The object to insert into the <see cref = "T:System.Collections.Generic.IList`1" />.</param>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see cref = "T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
		public override void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Removes the <see cref = "T:System.Collections.Generic.IList`1" /> item at the specified index.
		/// </summary>
		/// <param name = "index">The zero-based index of the item to remove.</param>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see cref = "T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
		public override void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
	}
}
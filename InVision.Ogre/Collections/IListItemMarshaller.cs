using System;

namespace InVision.Ogre.Collections
{
	internal interface IListItemMarshaller<T>
	{
		/// <summary>
		/// 	Converts the managed to unmanaged.
		/// </summary>
		/// <param name = "item">The item.</param>
		/// <returns></returns>
		IntPtr ConvertManagedToUnmanaged(T item);

		/// <summary>
		/// 	Cleans the managed to unmanaged.
		/// </summary>
		/// <param name = "item">The item.</param>
		/// <param name = "pItem">The p item.</param>
		void CleanManagedToUnmanaged(T item, IntPtr pItem);

		/// <summary>
		/// 	Unmanageds to managed.
		/// </summary>
		/// <param name = "pItem">The p item.</param>
		/// <returns></returns>
		T UnmanagedToManaged(IntPtr pItem);

		/// <summary>
		/// 	Cleans the unmanaged to managed.
		/// </summary>
		/// <param name = "pItem">The p item.</param>
		/// <param name = "item">The item.</param>
		void CleanUnmanagedToManaged(IntPtr pItem, T item);
	}
}
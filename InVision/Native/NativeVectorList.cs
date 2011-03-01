using System;
using System.Runtime.InteropServices;
using InVision.Collections;

namespace InVision.Native
{
	internal sealed class NativeVectorList : PlatformInvoke
	{
		/// <summary>
		/// Initializes the <see cref="NativeVectorList"/> class.
		/// </summary>
		static NativeVectorList()
		{
			Init();
		}

		[DllImport(Library, EntryPoint = "valuetypevectorlist_new")]
		public static extern IntPtr NewValueTypeVectorList(VectorListItem item);

		[DllImport(Library, EntryPoint = "vectorlist_delete")]
		public static extern bool Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "vectorlist_clear")]
		public static extern void Clear(IntPtr self);

		[DllImport(Library, EntryPoint = "vectorlist_count")]
		public static extern int GetCount(IntPtr self);
	}
}
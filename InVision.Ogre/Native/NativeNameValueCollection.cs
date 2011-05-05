using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	internal sealed class NativeNameValueCollection : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "namevaluecollection_new")]
		public static extern IntPtr New();

		[DllImport(Library, EntryPoint = "namevaluecollection_delete")]
		public static extern void Delete(IntPtr pCollection);

		[DllImport(Library, EntryPoint = "namevaluecollection_add")]
		public static extern void Add(
			IntPtr pCollection,
			[MarshalAs(UnmanagedType.LPStr)] string key,
			[MarshalAs(UnmanagedType.LPStr)] string value);

		[DllImport(Library, EntryPoint = "namevaluecollection_remove")]
		public static extern void Remove(
			IntPtr pCollection,
			[MarshalAs(UnmanagedType.LPStr)] string key);

		[DllImport(Library, EntryPoint = "namevaluecollection_clear")]
		public static extern void Clear(IntPtr pCollection);

		[DllImport(Library, EntryPoint = "namevaluecollection_count")]
		public static extern int Count(IntPtr pCollection);

		[DllImport(Library, EntryPoint = "namevaluecollection_get_pairs")]
		public static extern IntPtr GetEnumerator(IntPtr pCollection);
	}
}
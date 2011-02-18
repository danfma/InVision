using System;
using System.Runtime.InteropServices;

namespace InVision.Native
{
	internal sealed class NativeNameValuePairList : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "namevaluepairlist_convert")]
		public static extern IntPtr Convert(NameValuePair[] pairs, int count);

		[DllImport(Library, EntryPoint = "namevaluepairlist_new")]
		public static extern IntPtr New();

		[DllImport(Library, EntryPoint = "namevaluepairlist_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "namevaluepairlist_add")]
		public static extern void Add(
			IntPtr self,
			[MarshalAs(UnmanagedType.LPStr)] string key,
			[MarshalAs(UnmanagedType.LPStr)] string value);

		[DllImport(Library, EntryPoint = "namevaluepairlist_remove")]
		public static extern void Remove(
			IntPtr self,
			[MarshalAs(UnmanagedType.LPStr)] string key);

		[DllImport(Library, EntryPoint = "namevaluepairlist_clear")]
		public static extern void Clear(IntPtr self);

		[DllImport(Library, EntryPoint = "namevaluepairlist_count")]
		public static extern int Count(IntPtr self);

		[DllImport(Library, EntryPoint = "namevaluepairlist_copy")]
		public static extern IntPtr Copy(IntPtr self);

		[DllImport(Library, EntryPoint = "namevaluepairlist_get_pairs")]
		public static extern IntPtr GetPairs(IntPtr self);
	}
}
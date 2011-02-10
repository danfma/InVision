using System;
using System.Runtime.InteropServices;
using InVision.Ogre3D.Util;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeNameValuePairList : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "NvplConvert")]
		public static extern IntPtr Convert(NameValuePair[] pairs, int count);

		[DllImport(Library, EntryPoint = "NvplNew")]
		public static extern IntPtr New();

		[DllImport(Library, EntryPoint = "NvplDelete")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "NvplAdd")]
		public static extern void Add(
			IntPtr self,
			[MarshalAs(UnmanagedType.LPStr)] string key,
			[MarshalAs(UnmanagedType.LPStr)] string value);

		[DllImport(Library, EntryPoint = "NvplRemove")]
		public static extern void Remove(
			IntPtr self,
			[MarshalAs(UnmanagedType.LPStr)] string key);

		[DllImport(Library, EntryPoint = "NvplClear")]
		public static extern void Clear(IntPtr self);

		[DllImport(Library, EntryPoint = "NvplCount")]
		public static extern int Count(IntPtr self);

		[DllImport(Library, EntryPoint = "NvplCopy")]
		public static extern IntPtr Copy(IntPtr self);

		[DllImport(Library, EntryPoint = "NvplGetPairs")]
		public static extern IntPtr GetPairs(IntPtr self);
	}
}
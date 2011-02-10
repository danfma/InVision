using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeEnumerator : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "EnumrGetCurrent")]
		public static extern IntPtr GetCurrent(IntPtr self);

		[DllImport(Library, EntryPoint = "EnumrMoveNext")]
		public static extern bool MoveNext(IntPtr self);

		[DllImport(Library, EntryPoint = "EnumrReset")]
		public static extern void Reset(IntPtr self);

		[DllImport(Library, EntryPoint = "EnumrDelete")]
		public static extern void Delete(IntPtr self);
	}
}
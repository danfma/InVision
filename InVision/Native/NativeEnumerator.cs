using System;
using System.Runtime.InteropServices;

namespace InVision.Native
{
	public sealed class NativeEnumerator : PlatformInvoke
	{
		[DllImport(CommonLibrary, EntryPoint = "enumerator_get_current")]
		public static extern IntPtr GetCurrent(IntPtr self);

		[DllImport(CommonLibrary, EntryPoint = "enumerator_move_next")]
		public static extern bool MoveNext(IntPtr self);

		[DllImport(CommonLibrary, EntryPoint = "enumerator_reset")]
		public static extern void Reset(IntPtr self);

		[DllImport(CommonLibrary, EntryPoint = "enumerator_delete")]
		public static extern void Delete(IntPtr self);
	}
}
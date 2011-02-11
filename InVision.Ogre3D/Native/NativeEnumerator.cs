using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeEnumerator : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "enumerator_get_current")]
		public static extern IntPtr GetCurrent(IntPtr self);

		[DllImport(Library, EntryPoint = "enumerator_move_next")]
		public static extern bool MoveNext(IntPtr self);

		[DllImport(Library, EntryPoint = "enumerator_reset")]
		public static extern void Reset(IntPtr self);

		[DllImport(Library, EntryPoint = "enumerator_delete")]
		public static extern void Delete(IntPtr self);
	}
}
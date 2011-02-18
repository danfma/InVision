using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal class NativeComponent : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_component_get_ctype")]
		[return: MarshalAs(UnmanagedType.I4)]
		public static extern ComponentType GetCType(IntPtr self);
	}
}
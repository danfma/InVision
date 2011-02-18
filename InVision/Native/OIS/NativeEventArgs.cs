using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal sealed class NativeEventArgs : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_get_device")]
		public static extern IntPtr _GetDevice(IntPtr self);

		#region Helpers

		public static InputObject GetDevice(IntPtr self)
		{
			return _GetDevice(self).AsHandle(ptr => new UnknownInputObject(ptr, false));
		}

		public static T GetDevice<T>(IntPtr self) where T : InputObject
		{
			return _GetDevice(self).AsHandle(ptr => (T)Activator.CreateInstance(typeof(T), ptr));
		}

		#endregion
	}
}
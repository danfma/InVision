using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeInputManager : NativeOIS
	{
		private const string Prefix = "ois_inputmanager_";

		/// <summary>
		/// Initializes the <see cref="NativeInputManager"/> class.
		/// </summary>
		static NativeInputManager()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = Prefix + "get_version_number")]
		public static extern uint GetVersionNumber();

		[DllImport(OISLibrary, EntryPoint = Prefix + "create_input_system")]
		public static extern IntPtr CreateInputSystem(IntPtr winHandle);

		[DllImport(OISLibrary, EntryPoint = Prefix + "create_by_param_input_system")]
		public static extern IntPtr CreateInputSystem(NameValueItem[] values, int valuesCount);

		[DllImport(OISLibrary, EntryPoint = Prefix + "destroy")]
		public static extern void Destroy(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = Prefix + "get_version_name")]
		public static extern string GetVersionName(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = Prefix + "input_system_name")]
		public static extern string InputSystemName(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = Prefix + "get_number_of_devices")]
		public static extern int GetNumberOfDevices(IntPtr self, InterfaceType interfaceType);

		[DllImport(OISLibrary, EntryPoint = Prefix + "create_input_object")]
		public static extern IntPtr CreateInputObject(IntPtr self, DeviceType interfaceType, bool bufferMode, string vendor);

		[DllImport(OISLibrary, EntryPoint = Prefix + "destroy_input_object")]
		public static extern void DestroyInputObject(IntPtr self, IntPtr obj);
	}
}
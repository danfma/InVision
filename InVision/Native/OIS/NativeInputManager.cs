using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using InVision.Collections;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal sealed class NativeInputManager : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_inputmanager_new_with_winhandle")]
		public static extern IntPtr New(IntPtr winHandle);

		[DllImport(Library, EntryPoint = "ois_inputmanager_new_with_paramlist")]
		public static extern IntPtr NewWithParamList(IntPtr paramList);

		[DllImport(Library, EntryPoint = "ois_inputmanager_get_inputsystemname")]
		public static extern IntPtr _GetName(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_inputmanager_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_inputmanager_get_number_of_devices")]
		public static extern int GetNumberOfDevices(IntPtr self, InputType type);

		[DllImport(Library, EntryPoint = "ois_inputmanager_list_free_devices")]
		public static extern IntPtr _ListFreeDevices(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_inputmanager_create_inputobject")]
		public static extern IntPtr _CreateInputObject(
			IntPtr self,
			[MarshalAs(UnmanagedType.I4)] InputType type,
			[MarshalAs(UnmanagedType.Bool)] bool bufferMode,
			[MarshalAs(UnmanagedType.LPStr)] string vendor);

		[DllImport(Library, EntryPoint = "ois_inputmanager_destroy_inputobject")]
		public static extern void _DestroyInputObject(
			IntPtr self,
			IntPtr pInputObject);

		#region Helpers

		public static readonly Dictionary<InputType, Type> InputObjectTypeMapping =
			new Dictionary<InputType, Type>
				{
					{InputType.Mouse, typeof (Mouse)},
					{InputType.Keyboard, typeof(Keyboard)}
				};

		public static IntPtr NewWithParamList(NameValueCollection paramList)
		{
			paramList.Flush();

			return NewWithParamList(paramList.CollectionHandle);
		}

		public static string GetName(IntPtr self)
		{
			return _GetName(self).AsConstString();
		}

		public static IEnumerable<DeviceInfo> ListFreeDevices(IntPtr self)
		{
			return _ListFreeDevices(self).AsAutoEnumeration<DeviceInfo>(NativeUtilities.DeleteDeviceInfo);
		}

		public static InputObject CreateInputObject(IntPtr self, InputType inputType, bool bufferMode, string vendor)
		{
			IntPtr pObject = _CreateInputObject(self, inputType, bufferMode, vendor);
			Type type;

			if (!InputObjectTypeMapping.TryGetValue(inputType, out type))
				type = typeof(UnknownInputObject);

			return pObject.AsHandle(ptr => (InputObject)Activator.CreateInstance(type, pObject, true));
		}

		public static void DestroyInputObject(IntPtr self, InputObject inputObject)
		{
			try
			{
				_DestroyInputObject(self, inputObject.DangerousGetHandle());
			}
			finally
			{
				inputObject.GiveUpHandleOwnership();
				inputObject.Dispose();
			}
		}

		#endregion
	}
}
/*
 * GENERATED CODE
 * DON'T EDIT THIS; USE PARTIAL CLASSES IF NEEDED.
 */

using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS;
using InVision.OIS.Components;
using InVision.OIS.Native;

namespace InVision.OIS.Native
{
	internal sealed class CppComponent : HandleContainer, IComponent
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_component")]
		public  extern void New();
		
		[DllImport(Library, EntryPoint = "new_component_by_ctype")]
		public  extern void New(ComponentType ctype);
		
		[DllImport(Library, EntryPoint = "delete_component")]
		public  extern void Delete();
	}
	
	internal static partial class CppButton
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_button")]
		public static extern void New();
		
		[DllImport(Library, EntryPoint = "new_button_by_pushed")]
		public static extern void New([MarshalAs(UnmanagedType.I1)] Boolean pushed);
	}
	
	internal static partial class CppAxis
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_axis")]
		public static extern void New();
	}
	
	internal static partial class CppVector3
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_vector3")]
		public static extern void New();
		
		[DllImport(Library, EntryPoint = "new_vector3_by_x_y_z")]
		public static extern void New(
			Single x, 
			Single y, 
			Single z);
	}
	
	internal static partial class CppEventArg
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_eventarg_by_devicehandle")]
		public static extern void New(Handle deviceHandle);
		
		[DllImport(Library, EntryPoint = "delete_eventarg")]
		public static extern void Delete();
		
		[DllImport(Library, EntryPoint = "eventarg_get_device")]
		public static extern Handle GetDevice(Handle self);
	}
	
	internal static partial class CppDevice
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "delete_device")]
		public static extern void Delete();
		
		[DllImport(Library, EntryPoint = "device_get_device_type")]
		public static extern DeviceType GetDeviceType(Handle self);
		
		[DllImport(Library, EntryPoint = "device_get_vendor")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String GetVendor(Handle self);
		
		[DllImport(Library, EntryPoint = "device_is_buffered")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern Boolean IsBuffered(Handle self);
		
		[DllImport(Library, EntryPoint = "device_set_buffered")]
		public static extern void SetBuffered(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] Boolean value);
		
		[DllImport(Library, EntryPoint = "device_get_creator")]
		public static extern Handle GetCreator(Handle self);
		
		[DllImport(Library, EntryPoint = "device_capture")]
		public static extern void Capture(Handle self);
		
		[DllImport(Library, EntryPoint = "device_get_id")]
		public static extern Int32 GetID(Handle self);
		
		[DllImport(Library, EntryPoint = "device_query_interface")]
		public static extern Handle QueryInterface(
			Handle self, 
			InterfaceType interfaceType);
	}
	
	internal static partial class CppDeviceInterface
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "delete_deviceinterface")]
		public static extern void Delete();
	}
	
	internal static partial class CppFactoryCreator
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "delete_factorycreator")]
		public static extern void Delete();
		
		[DllImport(Library, EntryPoint = "factorycreator_free_device_list")]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InVision.OIS.Native.Marshallers.DeviceTypeItemMarshaller))]
		public static extern DeviceTypeItem[] FreeDeviceList(Handle self);
		
		[DllImport(Library, EntryPoint = "factorycreator_total_devices")]
		public static extern Int32 TotalDevices(
			Handle self, 
			DeviceType deviceType);
		
		[DllImport(Library, EntryPoint = "factorycreator_free_devices")]
		public static extern Int32 FreeDevices(
			Handle self, 
			DeviceType deviceType);
		
		[DllImport(Library, EntryPoint = "factorycreator_vendor_exist1")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern Boolean VendorExist(
			Handle self, 
			DeviceType deviceType);
		
		[DllImport(Library, EntryPoint = "factorycreator_vendor_exist2")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern Boolean VendorExist(
			Handle self, 
			DeviceType deviceType, 
			[MarshalAs(UnmanagedType.LPStr)] String vendor);
		
		[DllImport(Library, EntryPoint = "factorycreator_create_object1")]
		public static extern Handle CreateObject(
			Handle self, 
			Handle inputManagerHandle, 
			DeviceType deviceType, 
			[MarshalAs(UnmanagedType.I1)] Boolean bufferMode);
		
		[DllImport(Library, EntryPoint = "factorycreator_create_object2")]
		public static extern Handle CreateObject(
			Handle self, 
			Handle inputManagerHandle, 
			DeviceType deviceType, 
			[MarshalAs(UnmanagedType.I1)] Boolean bufferMode, 
			[MarshalAs(UnmanagedType.LPStr)] String vendor);
		
		[DllImport(Library, EntryPoint = "factorycreator_destroy_object")]
		public static extern void DestroyObject(
			Handle self, 
			Handle deviceHandle);
	}
	
	internal static partial class CppInputManager
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "inputmanager_get_version_number")]
		public static extern UInt32 GetVersionNumber();
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_system1")]
		public static extern Handle CreateInputSystem(Int32 winHandle);
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_system2")]
		public static extern Handle CreateInputSystem(
			NameValueItem[] parameters, 
			Int32 paramCount);
		
		[DllImport(Library, EntryPoint = "inputmanager_destroy_input_system")]
		public static extern void DestroyInputSystem(Handle handle);
		
		[DllImport(Library, EntryPoint = "inputmanager_get_version_name")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String GetVersionName(Handle self);
		
		[DllImport(Library, EntryPoint = "inputmanager_input_system_name")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String InputSystemName(Handle self);
		
		[DllImport(Library, EntryPoint = "inputmanager_get_number_of_devices")]
		public static extern Int32 GetNumberOfDevices(
			Handle self, 
			DeviceType deviceType);
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_object1")]
		public static extern Handle CreateInputObject(
			Handle self, 
			DeviceType deviceType, 
			Boolean bufferMode);
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_object2")]
		public static extern Handle CreateInputObject(
			Handle self, 
			DeviceType deviceType, 
			Boolean bufferMode, 
			[MarshalAs(UnmanagedType.LPStr)] String vendor);
		
		[DllImport(Library, EntryPoint = "inputmanager_destroy_input_object")]
		public static extern void DestroyInputObject(
			Handle self, 
			Handle deviceHandle);
		
		[DllImport(Library, EntryPoint = "inputmanager_add_factory_creator")]
		public static extern void AddFactoryCreator(
			Handle self, 
			Handle factoryHandle);
		
		[DllImport(Library, EntryPoint = "inputmanager_remove_factory_creator")]
		public static extern void RemoveFactoryCreator(
			Handle self, 
			Handle factoryHandle);
		
		[DllImport(Library, EntryPoint = "inputmanager_enable_add_on_factory")]
		public static extern void EnableAddOnFactory(
			Handle self, 
			AddOnFactory factory);
	}
	
}

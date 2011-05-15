using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
	[GeneratorType, FunctionProvider, TargetCppType("Component", Namespace = "OIS")]
	internal interface INativeComponent
	{
		[Constructor]
		ComponentDescriptor New();

		[Constructor]
		ComponentDescriptor New(ComponentType ctype);

		[Destructor]
		void Delete(Handle self);
	}

	[GeneratorType, FunctionProvider, TargetCppType("Button", Namespace = "OIS")]
	internal interface INativeButton : INativeComponent
	{
		[Constructor]
		new ButtonDescriptor New();

		[Constructor]
		ButtonDescriptor New(bool pushed);
	}

	[GeneratorType, FunctionProvider, TargetCppType("Axis", Namespace = "OIS")]
	internal interface INativeAxis : INativeComponent
	{
		[Constructor]
		new AxisDescriptor New();
	}

	[GeneratorType, FunctionProvider, TargetCppType("Vector3", Namespace = "OIS")]
	internal interface INativeVector3 : INativeComponent
	{
		[Constructor]
		new Vector3Descriptor New();

		[Constructor]
		Vector3Descriptor New(float x, float y, float z);
	}

	[GeneratorType, FunctionProvider, TargetCppType("EventArg", Namespace = "OIS")]
	internal interface INativeEventArg
	{
		[Constructor]
		EventArgDescriptor New(Handle deviceHandle);

		[Destructor]
		void Delete(Handle self);

		Handle GetDevice(Handle self);
	}

	[GeneratorType, FunctionProvider, TargetCppType("Object", Namespace = "OIS")]
	internal interface INativeDevice
	{
		[Destructor]
		void Delete(Handle self);

		DeviceType GetType(Handle self);

		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetVendor(Handle self);

		[return: MarshalAs(UnmanagedType.I1)]
		bool IsBuffered(Handle self);

		void SetBuffered(
			Handle self,
			[MarshalAs(UnmanagedType.I1)] bool value);

		Handle GetCreator(Handle self);

		void Capture(Handle self);

		int GetID(Handle self);

		Handle QueryInterface(Handle self, InterfaceType interfaceType);
	}

	[GeneratorType, FunctionProvider, TargetCppType("Interface", Namespace = "OIS")]
	internal interface INativeDeviceInterface
	{
		[Destructor]
		void Delete(Handle self);
	}

	[GeneratorType, FunctionProvider, TargetCppType("FactoryCreator", Namespace = "OIS")]
	interface INativeFactoryCreator
	{
		[Destructor]
		void Delete(Handle self);

		IntPtr FreeDeviceList(Handle self);

		int TotalDevices(Handle self, DeviceType deviceType);

		int FreeDevices(Handle self, DeviceType deviceType);

		[return: MarshalAs(UnmanagedType.I1)]
		bool VendorExist(Handle self, DeviceType deviceType);

		[return: MarshalAs(UnmanagedType.I1)]
		bool VendorExist(Handle self, DeviceType deviceType, string vendor);

		Handle CreateObject(
			Handle self,
			DeviceType deviceType,
			bool bufferMode);

		Handle CreateObject(
			Handle self,
			DeviceType deviceType,
			bool bufferMode,
			[MarshalAs(UnmanagedType.LPStr)] string vendor);

		void DestroyObject(
			Handle self,
			Handle deviceHandle);
	}

	[GeneratorType, FunctionProvider, TargetCppType("FactoryCreator", Namespace = "OIS")]
	internal interface INativeInputManager
	{
		uint GetVersionNumber();

		Handle CreateInputSystem(int winHandle);
		Handle CreateInputSystem(NameValueItem parameters, int paramCount);

		void DestroyInputSystem(Handle handle);

		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetVersionName(Handle self);

		[return: MarshalAs(UnmanagedType.LPStr)]
		string InputSystemName(Handle self);

		int GetNumberOfDevices(Handle self, DeviceType deviceType);

		Handle CreateInputObject(Handle self, DeviceType deviceType, bool bufferMode);
		Handle CreateInputObject(Handle self, DeviceType deviceType, bool bufferMode, [MarshalAs(UnmanagedType.LPStr)] string vendor);

		void DestroyInputObject(Handle self, Handle deviceHandle);

		void AddFactoryCreator(Handle self, Handle factoryHandle);
		void RemoveFactoryCreator(Handle self, Handle factoryHandle);
		void EnableAddOnFactory(Handle self, AddOnFactory factory);
	}

	[GeneratorType, ValueObject]
	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceTypeItem
	{
		public DeviceType DeviceType;

		[MarshalAs(UnmanagedType.LPStr)]
		public string Name;
	}
}
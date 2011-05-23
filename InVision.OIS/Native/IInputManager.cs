using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Attributes;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
	[OISInterface("InputManager")]
	public interface IInputManager : ICppInterface
	{
		[Method(Static = true)]
		uint GetVersionNumber();

		[Method]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetVersionName();

		[Method(Static = true)]
		IInputManager CreateInputSystem(int winHandle);

		[Method(Static = true)]
		IInputManager CreateInputSystem(NameValueItem[] parameters, int parametersCount);

		[Method(Static = true)]
		void DestroyInputSystem(IInputManager manager);

		[Method]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string InputSystemName();

		[Method]
		int GetNumberOfDevices(DeviceType iType);

		/// <summary>
		/// TODO CHECAR
		/// </summary>
		/// <returns></returns>
		[Method]
		IntPtr ListFreeDevices();

		[Method]
		IObject CreateInputObject(DeviceType iType, [MarshalAs(UnmanagedType.I1)] bool bufferMode);

		[Method]
		IObject CreateInputObject(DeviceType iType, [MarshalAs(UnmanagedType.I1)] bool bufferMode,
								 [MarshalAs(UnmanagedType.LPStr)] string vendor);

		[Method]
		void DestroyInputObject(IObject obj);

		[Method]
		void AddFactoryCreator(IFactoryCreator factory);

		[Method]
		void RemoveFactoryCreator(IFactoryCreator factory);

		[Method]
		void EnableAddOnFactory(AddOnFactory factory);
	}

	[OISInterface("FactoryCreator")]
	public interface IFactoryCreator : ICppInterface
	{

	}
}
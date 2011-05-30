using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Attributes;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
	[OISClass("InputManager")]
	public interface IInputManager : ICppInstance
	{
		[Method(Static = true, Implemented = true)]
		uint GetVersionNumber();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetVersionName();

		[Method(Static = true, Implemented = true)]
		IInputManager CreateInputSystem(int winHandle);

		[Method(Static = true, Implemented = true)]
		IInputManager CreateInputSystem(NameValueItem[] parameters, int parametersCount);

		[Method(Static = true, Implemented = true)]
		void DestroyInputSystem(IInputManager manager);

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string InputSystemName();

		[Method(Implemented = true)]
		int GetNumberOfDevices(DeviceType iType);

		/// <summary>
		/// TODO CHECAR
		/// </summary>
		/// <returns></returns>
		[Method(Implemented = true)]
		IntPtr ListFreeDevices();

		[Method(Implemented = true)]
		IObject CreateInputObject(DeviceType iType, [MarshalAs(UnmanagedType.I1)] bool bufferMode);

		[Method(Implemented = true)]
		IObject CreateInputObject(DeviceType iType, [MarshalAs(UnmanagedType.I1)] bool bufferMode,
								 [MarshalAs(UnmanagedType.LPStr)] string vendor);

		[Method(Implemented = true)]
		void DestroyInputObject(IObject obj);

		[Method(Implemented = true)]
		void AddFactoryCreator(IFactoryCreator factory);

		[Method(Implemented = true)]
		void RemoveFactoryCreator(IFactoryCreator factory);

		[Method(Implemented = true)]
		void EnableAddOnFactory(AddOnFactory factory);
	}
}
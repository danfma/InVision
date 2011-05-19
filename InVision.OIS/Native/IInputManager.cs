using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using InVision.Native.Ext;
using InVision.OIS.Attributes;
using InVision.OIS.Components;

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
		Handle CreateInputSystem(int winHandle);

		[Method(Static = true)]
		Handle CreateInputSystem(NameValueItem[] parameters, int parametersCount);

		[Method(Static = true)]
		void DestroyInputSystem(Handle manager);

		[Method]
		[return: MarshalAs(UnmanagedType.LPTStr)]
		string InputSystemName();

		[Method]
		int GetNumberOfDevices(ComponentType iType);

		/// <summary>
		/// TODO CHECAR
		/// </summary>
		/// <returns></returns>
		[Method]
		Handle ListFreeDevices();

		[Method]
		Handle CreateInputObject(ComponentType iType, [MarshalAs(UnmanagedType.I1)] bool bufferMode);

		[Method]
		Handle CreateInputObject(ComponentType iType, [MarshalAs(UnmanagedType.I1)] bool bufferMode, [MarshalAs(UnmanagedType.LPTStr)] string vendor);

		[Method]
		void DestroyInputObject(Handle obj);

		[Method]
		void AddFactoryCreator(Handle factory);

		[Method]
		void RemoveFactoryCreator(Handle factory);

		[Method]
		void EnableAddOnFactory(AddOnFactory factory);
	}
}

using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Attributes;
using InVision.OIS.Devices;
using InterfaceType = InVision.OIS.Devices.InterfaceType;

namespace InVision.OIS.Native
{
	[OISClass("Object")]
	public interface IObject : ICppInstance
	{
		[Destructor(Implemented = true)]
		void Destruct();

		[Method(Implemented = true)]
		DeviceType Type();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string Vendor();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		bool Buffered();

		[Method(Implemented = true)]
		void SetBuffered([MarshalAs(UnmanagedType.I1)] bool value);

		[Method(Implemented = true)]
		Handle GetCreator();

		[Method(Implemented = true)]
		void Capture();

		[Method(Implemented = true)]
		int GetID();

		[Method(Implemented = true)]
		Handle QueryInterface(InterfaceType interfaceType);
	}
}
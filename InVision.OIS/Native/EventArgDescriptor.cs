using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppDescriptor]
	[StructLayout(LayoutKind.Sequential)]
    public struct EventArgDescriptor
	{
		public Handle Self;
	}
}
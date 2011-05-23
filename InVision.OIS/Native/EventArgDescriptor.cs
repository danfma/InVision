using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.OIS.Native
{
    [CppDescriptor]
	[StructLayout(LayoutKind.Sequential)]
    public struct EventArgDescriptor
	{
		public Handle Self;
	}
}
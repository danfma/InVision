using System;
using System.Runtime.InteropServices;

namespace InVision.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct StringArray
	{
		public int Count;
		public IntPtr PStrings;
	}
}
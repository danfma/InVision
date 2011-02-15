using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct StringArray
	{
		public int Count;
		public IntPtr PStrings;
	}
}
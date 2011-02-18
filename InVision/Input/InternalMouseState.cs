using System;
using System.Runtime.InteropServices;

namespace InVision.Input
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct InternalMouseState
	{
		public int Width;
		public int Height;
		public int Buttons;
		public IntPtr X;
		public IntPtr Y;
		public IntPtr Z;
	}
}
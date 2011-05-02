using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct MouseStateDescriptor
	{
		private readonly IntPtr self;
		private readonly int* width;
		private readonly int* height;
		private readonly int* buttons;
		private readonly AxisDescriptor x;
		private readonly AxisDescriptor y;
		private readonly AxisDescriptor z;

		public MouseStateDescriptor(IntPtr self, int* width, int* height, int* buttons, AxisDescriptor x, AxisDescriptor y,
									AxisDescriptor z)
		{
			this.self = self;
			this.width = width;
			this.height = height;
			this.buttons = buttons;
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public IntPtr Self
		{
			get { return self; }
		}

		public int Width
		{
			get { return *width; }
			set { *width = value; }
		}

		public int Height
		{
			get { return *height; }
			set { *height = value; }
		}

		public AxisDescriptor X
		{
			get { return x; }
		}

		public AxisDescriptor Y
		{
			get { return y; }
		}

		public AxisDescriptor Z
		{
			get { return z; }
		}

		public int Buttons
		{
			get { return *buttons; }
		}
	}
}
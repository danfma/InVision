using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct MouseStateExtended
	{
		private readonly IntPtr self;
		private readonly int* width;
		private readonly int* height;
		private readonly AxisExtended x;
		private readonly AxisExtended y;
		private readonly AxisExtended z;
		private readonly int* buttons;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseStateExtended"/> struct.
		/// </summary>
		/// <param name="self">The self.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="z">The z.</param>
		/// <param name="buttons">The buttons.</param>
		public MouseStateExtended(IntPtr self, int* width, int* height, AxisExtended x, AxisExtended y, AxisExtended z,
								  int* buttons)
		{
			this.self = self;
			this.width = width;
			this.height = height;
			this.x = x;
			this.y = y;
			this.z = z;
			this.buttons = buttons;
		}

		public IntPtr Self
		{
			get { return self; }
		}

		public int Width
		{
			get { return *width; }
		}

		public int Height
		{
			get { return *height; }
		}

		public AxisExtended X
		{
			get { return x; }
		}

		public AxisExtended Y
		{
			get { return y; }
		}

		public AxisExtended Z
		{
			get { return z; }
		}

		public int Buttons
		{
			get { return *buttons; }
		}
	}
}
using System;
using System.Runtime.InteropServices;

namespace InVision.Input
{
	[StructLayout(LayoutKind.Sequential)]
	public struct MouseState : IMouseState, IHandleHolder
	{
		private readonly IntPtr handle;
		private readonly int width;
		private readonly int height;
		private readonly AxisComponent x;
		private readonly AxisComponent y;
		private readonly AxisComponent z;
		private readonly int buttons;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseState"/> struct.
		/// </summary>
		/// <param name="handle">The handle.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="z">The z.</param>
		/// <param name="buttons">The buttons.</param>
		internal MouseState(IntPtr handle, int width, int height, AxisComponent x,
		                    AxisComponent y, AxisComponent z, int buttons)
		{
			this.handle = handle;
			this.width = width;
			this.height = height;
			this.x = x;
			this.y = y;
			this.z = z;
			this.buttons = buttons;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseState"/> struct.
		/// </summary>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="z">The z.</param>
		/// <param name="buttons">The buttons.</param>
		public MouseState(int width, int height, AxisComponent x, AxisComponent y,
		                  AxisComponent z, int buttons)
		{
			handle = IntPtr.Zero;
			this.width = width;
			this.height = height;
			this.x = x;
			this.y = y;
			this.z = z;
			this.buttons = buttons;
		}

		/// <summary>
		/// 	Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		IntPtr IHandleHolder.Handle
		{
			get { return handle; }
		}

		/// <summary>
		/// 	Gets the width.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			get { return width; }
		}

		/// <summary>
		/// 	Gets the height.
		/// </summary>
		/// <value>The height.</value>
		public int Height
		{
			get { return height; }
		}

		/// <summary>
		/// 	Gets the X.
		/// </summary>
		/// <value>The X.</value>
		public AxisComponent X
		{
			get { return x; }
		}

		/// <summary>
		/// 	Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public AxisComponent Y
		{
			get { return y; }
		}

		/// <summary>
		/// 	Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public AxisComponent Z
		{
			get { return z; }
		}

		/// <summary>
		/// 	Gets the buttons.
		/// </summary>
		/// <value>The buttons.</value>
		public int Buttons
		{
			get { return buttons; }
		}

		/// <summary>
		/// 	Determines whether [is button down] [the specified button].
		/// </summary>
		/// <param name = "button">The button.</param>
		/// <returns>
		/// 	<c>true</c> if [is button down] [the specified button]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsButtonDown(MouseButton button)
		{
			return ((buttons & (1L << (int) button)) == 0) ? false : true;
		}
	}
}
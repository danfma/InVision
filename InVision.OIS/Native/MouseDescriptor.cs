using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	/// <summary>
	/// 
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct MouseDescriptor
	{
		private IntPtr _self;
		private MouseStateDescriptor _mouseState;

		/// <summary>
		/// Gets the self.
		/// </summary>
		/// <value>The self.</value>
		public IntPtr Self
		{
			get { return _self; }
		}

		/// <summary>
		/// Gets the state of the mouse.
		/// </summary>
		/// <value>The state of the mouse.</value>
		public MouseStateDescriptor MouseState
		{
			get { return _mouseState; }
		}
	}
}
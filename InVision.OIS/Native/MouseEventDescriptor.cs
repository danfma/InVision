using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct MouseEventDescriptor
	{
		private readonly EventArgDescriptor _base;
		private readonly MouseStateDescriptor _mouseState;

		/// <summary>
		/// Gets the base.
		/// </summary>
		/// <value>The base.</value>
		public EventArgDescriptor Base
		{
			get { return _base; }
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
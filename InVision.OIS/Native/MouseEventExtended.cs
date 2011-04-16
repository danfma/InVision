using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct MouseEventExtended
	{
		private EventArgExtended @base;
		private MouseStateExtended state;

		public EventArgExtended Base
		{
			get { return @base; }
		}

		public MouseStateExtended State
		{
			get { return state; }
		}
	}
}
using System;

namespace InVision.OIS
{
	public class Joystick : DeviceObject
	{
		public Joystick(IntPtr pSelf) : base(pSelf, true)
		{
		}

		public Joystick(bool ownsHandle) : base(ownsHandle)
		{
		}
	}
}
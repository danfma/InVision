using System;

namespace InVision.OIS
{
	public class Tablet : DeviceObject
	{
		public Tablet(IntPtr pSelf) : base(pSelf, true)
		{
		}

		public Tablet(bool ownsHandle) : base(ownsHandle)
		{
		}
	}
}
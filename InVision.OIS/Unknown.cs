using System;

namespace InVision.OIS
{
	public class Unknown : DeviceObject
	{
		public Unknown(IntPtr pSelf) : base(pSelf, true)
		{
		}

		public Unknown(bool ownsHandle) : base(ownsHandle)
		{
		}
	}
}
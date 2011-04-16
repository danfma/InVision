using System;
using InVision.Native;

namespace InVision.OIS
{
	public class OISEventArgs : ReferenceHandle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OISEventArgs"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		public OISEventArgs(IntPtr pSelf)
			: base(pSelf)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OISEventArgs"/> class.
		/// </summary>
		public OISEventArgs()
		{
		}

		/// <summary>
		/// Gets the device.
		/// </summary>
		/// <value>The device.</value>
		public DeviceObject Device
		{
			get { throw new NotImplementedException(); }
		}
	}
}
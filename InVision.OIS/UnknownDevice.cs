using System;
using InVision.OIS;

namespace InVision.Input
{
	public class UnknownDevice : Device
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnknownDevice"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal UnknownDevice(IntPtr pSelf, bool ownsHandle) : base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnknownDevice"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal UnknownDevice(bool ownsHandle) : base(ownsHandle)
		{
		}
	}
}
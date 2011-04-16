using System;

namespace InVision.Native
{
	public abstract class ReferenceHandle : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ReferenceHandle" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		protected ReferenceHandle(IntPtr pSelf)
			: base(pSelf)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ReferenceHandle" /> class.
		/// </summary>
		protected ReferenceHandle()
			: base(false)
		{
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
		}
	}
}
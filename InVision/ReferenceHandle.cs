using System;

namespace InVision
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
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			return true;
		}
	}
}
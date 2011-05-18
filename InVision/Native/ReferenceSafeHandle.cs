using System;

namespace InVision.Native
{
	public abstract class ReferenceSafeHandle : SafeHandle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ReferenceSafeHandle" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		protected ReferenceSafeHandle(IntPtr pSelf)
			: base(pSelf)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ReferenceSafeHandle" /> class.
		/// </summary>
		protected ReferenceSafeHandle()
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
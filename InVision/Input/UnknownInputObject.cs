using System;

namespace InVision.Input
{
	public class UnknownInputObject : InputObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnknownInputObject"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal UnknownInputObject(IntPtr pSelf, bool ownsHandle) : base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnknownInputObject"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal UnknownInputObject(bool ownsHandle) : base(ownsHandle)
		{
		}
	}
}
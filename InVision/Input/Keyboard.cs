using System;

namespace InVision.Input
{
	public class Keyboard : InputObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Keyboard"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal Keyboard(IntPtr pSelf, bool ownsHandle) : base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Keyboard"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal Keyboard(bool ownsHandle) : base(ownsHandle)
		{
		}
	}
}
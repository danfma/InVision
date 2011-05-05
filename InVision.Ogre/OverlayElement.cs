using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class OverlayElement : Handle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OverlayElement"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal OverlayElement(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{

		}

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>The caption.</value>
		public string Caption
		{
			get { return NativeOverlayElement.GetCaption(handle); }
			set { NativeOverlayElement.SetCaption(handle, value); }
		}
	}
}
using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Overlay : Handle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Overlay"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal Overlay(IntPtr pSelf, bool ownsHandle)
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
		/// Shows this instance.
		/// </summary>
		public void Show()
		{
			NativeOverlay.Show(handle);
		}

		/// <summary>
		/// Hides this instance.
		/// </summary>
		public void Hide()
		{
			NativeOverlay.Hide(handle);
		}
	}
}
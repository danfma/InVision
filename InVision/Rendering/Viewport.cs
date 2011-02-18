using System;
using InVision.Native.Ogre;

namespace InVision.Rendering
{
	public class Viewport : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Viewport" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal Viewport(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Viewport" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal Viewport(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Gets or sets the background colour.
		/// </summary>
		/// <value>The background colour.</value>
		public ColourValue BackgroundColour
		{
			get { return NativeOgreViewport.GetBackgroundColor(handle); }
			set { NativeOgreViewport.SetBackgroundColor(handle, value); }
		}

		/// <summary>
		/// Gets the actual width.
		/// </summary>
		/// <value>The actual width.</value>
		public int ActualWidth
		{
			get { return NativeOgreViewport.GetActualWidth(handle); }
		}

		/// <summary>
		/// Gets the actual height.
		/// </summary>
		/// <value>The actual height.</value>
		public int ActualHeight
		{
			get { return NativeOgreViewport.GetActualHeight(handle); }
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
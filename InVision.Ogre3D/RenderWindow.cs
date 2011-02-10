using System;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D
{
	public class RenderWindow : Handle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderWindow"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public RenderWindow(IntPtr pSelf, bool ownsHandle = false)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RenderWindow"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public RenderWindow(bool ownsHandle = true)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Releases the specified handle.
		/// </summary>
		/// <param name = "pSelf">The handle.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			return true;
		}

		/// <summary>
		/// Gets the width.
		/// </summary>
		/// <value>The width.</value>
		public uint Width
		{
			get { return NativeRenderWindow.GetWidth(handle); }
		}

		/// <summary>
		/// Gets the height.
		/// </summary>
		/// <value>The height.</value>
		public uint Height
		{
			get { return NativeRenderWindow.GetHeight(handle); }
		}
	}
}
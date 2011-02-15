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

		/// <summary>
		/// Adds the viewport.
		/// </summary>
		/// <param name="camera">The camera.</param>
		/// <param name="zOrder">The z order.</param>
		/// <param name="left">The left.</param>
		/// <param name="top">The top.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <returns></returns>
		public Viewport AddViewport(Camera camera, int zOrder = 0, float left = 0, float top = 0, float width = 0, float height = 0)
		{
			return NativeRenderWindow.AddViewport(
				handle,
				camera.DangerousGetHandle(),
				zOrder,
				left, top,
				width, height);
		}

		/// <summary>
		/// Writes the contents to timestamped file.
		/// </summary>
		/// <param name="filenamePrefix">The filename prefix.</param>
		/// <param name="filenameSuffix">The filename suffix.</param>
		/// <returns></returns>
		public string WriteContentsToTimestampedFile(string filenamePrefix, string filenameSuffix)
		{
			return NativeRenderWindow.WriteContentsToTimestampedFile(handle, filenamePrefix, filenameSuffix);
		}
	}
}
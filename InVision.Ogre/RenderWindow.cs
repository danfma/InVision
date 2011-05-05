using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
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
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
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

		/// <summary>
		/// Gets the custom attribute.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="data">The data.</param>
		public void GetCustomAttribute(string name, out IntPtr data)
		{
			NativeRenderWindow.GetCustomAttribute(handle, name, out data);
		}

		/// <summary>
		/// Gets the custom attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public T GetCustomAttribute<T>(string name)
		{
			IntPtr result;

			GetCustomAttribute(name, out result);

			return (T)Marshal.PtrToStructure(result, typeof(T));
		}

		/// <summary>
		/// Gets the statistics.
		/// </summary>
		/// <returns></returns>
		public FrameStats GetStatistics()
		{
			return NativeRenderWindow.GetStatistics(handle);
		}
	}
}
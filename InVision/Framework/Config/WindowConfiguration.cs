using System;

namespace InVision.Framework.Config
{
	public sealed class WindowConfiguration
	{
		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
		public int Width { get; set; }

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public int Height { get; set; }

		/// <summary>
		/// Sets the resolution.
		/// </summary>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		public void SetResolution(int width, int height)
		{
			Width = width;
			Height = height;
		}

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		public void Flush()
		{
			throw new NotImplementedException();
		}
	}
}
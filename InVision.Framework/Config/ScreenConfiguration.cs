using System.Xml.Serialization;
using InVision.GameMath;

namespace InVision.Framework.Config
{
	[XmlRoot("screen")]
	public class ScreenConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScreenConfiguration"/> class.
		/// </summary>
		public ScreenConfiguration()
		{
			Width = 640;
			Height = 480;
			BackgroundColor = Color.CornflowerBlue;
		}

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
		[XmlElement("width")]
		public uint Width { get; set; }

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		[XmlElement("height")]
		public uint Height { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ScreenConfiguration"/> is fullscreen.
		/// </summary>
		/// <value><c>true</c> if fullscreen; otherwise, <c>false</c>.</value>
		[XmlElement("fullscreen")]
		public bool Fullscreen { get; set; }

		/// <summary>
		/// Gets or sets the color of the background.
		/// </summary>
		/// <value>The color of the background.</value>
		[XmlElement("background-color")]
		public Color BackgroundColor { get; set; }
	}
}
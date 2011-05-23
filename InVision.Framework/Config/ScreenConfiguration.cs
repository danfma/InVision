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
		public int Width { get; set; }

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		[XmlElement("height")]
		public int Height { get; set; }

		/// <summary>
		/// Gets or sets the color of the background.
		/// </summary>
		/// <value>The color of the background.</value>
		[XmlElement("background-color")]
		public Color BackgroundColor { get; set; }
	}
}
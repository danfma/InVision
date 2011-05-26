using System.Xml.Serialization;

namespace InVision.Framework.Config
{
	[XmlRoot("game")]
	public class GameConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GameConfiguration"/> class.
		/// </summary>
		public GameConfiguration()
		{
			Name = "ProtoGame";
		}

		[XmlElement("name")]
		public string Name { get; set; }
	}
}
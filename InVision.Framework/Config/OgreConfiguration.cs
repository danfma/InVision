using System;
using System.Xml.Serialization;

namespace InVision.Framework.Config
{
	[Serializable]
	[XmlRoot("ogre")]
	public class OgreConfiguration
	{
		/// <summary>
		/// Gets or sets a value indicating whether [use ogre config].
		/// </summary>
		/// <value><c>true</c> if [use ogre config]; otherwise, <c>false</c>.</value>
		[XmlElement("use-ogre-config")]
		public bool UseOgreConfig { get; set; }

		/// <summary>
		/// Gets or sets the plugins directory.
		/// </summary>
		/// <value>The plugins directory.</value>
		[XmlElement("plugins-directory")]
		public string PluginsDirectory { get; set; }

		/// <summary>
		/// Gets or sets the plugins.
		/// </summary>
		/// <value>The plugins.</value>
		[XmlArray("plugins")]
		[XmlArrayItem("plugin")]
		public string[] Plugins { get; set; }

		/// <summary>
		/// Gets or sets the plugins filename.
		/// </summary>
		/// <value>The plugins filename.</value>
		[XmlElement("plugins-filename")]
		public string PluginsFilename { get; set; }

		/// <summary>
		/// Gets or sets the ogre config filename.
		/// </summary>
		/// <value>The ogre config filename.</value>
		[XmlElement("ogre-config-filename")]
		public string OgreConfigFilename { get; set; }
	}
}
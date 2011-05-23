using System.IO;

namespace InVision.Ogre.Config
{
	/// <summary>
	/// 
	/// </summary>
	public class PluginConfig
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PluginConfig"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		public PluginConfig(string filename)
		{
			Name = filename;
		}

		/// <summary>
		/// Gets or sets the filename.
		/// </summary>
		/// <value>The filename.</value>
		public string Name { get; private set; }

		/// <summary>
		/// Writes the specified writer.
		/// </summary>
		/// <param name="writer">The writer.</param>
		public void Write(StreamWriter writer)
		{
			writer.WriteLine("Plugin = {0}", Name);
		}
	}
}
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace InVision.Framework.Config
{
	[Serializable]
	[XmlRoot("configuration")]
	public class Configuration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Configuration"/> class.
		/// </summary>
		public Configuration()
		{
			Game = new GameConfiguration();
			Screen = new ScreenConfiguration();
			Scripting = new ScriptingConfiguration();
		}

		[XmlElement("game")]
		public GameConfiguration Game { get; set; }

		/// <summary>
		/// Gets or sets the screen.
		/// </summary>
		/// <value>The screen.</value>
		[XmlElement("screen")]
		public ScreenConfiguration Screen { get; set; }

		/// <summary>
		/// Gets or sets the scripting.
		/// </summary>
		/// <value>The scripting.</value>
		[XmlElement("scripting")]
		public ScriptingConfiguration Scripting { get; set; }

		/// <summary>
		/// Gets or sets the ogre configuration.
		/// </summary>
		/// <value>The ogre configuration.</value>
		[XmlElement("ogre")]
		public OgreConfiguration Ogre { get; set; }

		/// <summary>
		/// Loads the specified filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static Configuration Load(string filename)
		{
			var serializer = new XmlSerializer(typeof(Configuration));

			using (var file = new FileStream(filename, FileMode.Open))
			{
				return (Configuration)serializer.Deserialize(file);
			}
		}

		/// <summary>
		/// Loads the specified filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static T Load<T>(string filename) where T : Configuration
		{
			var serializer = new XmlSerializer(typeof(T));

			using (var file = new FileStream(filename, FileMode.Open))
			{
				return (T)serializer.Deserialize(file);
			}
		}

		/// <summary>
		/// Loads the or create.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static Configuration LoadOrCreate(string filename)
		{
			if (!File.Exists(filename))
				return new Configuration();

			return Load(filename);
		}

		/// <summary>
		/// Loads the or create.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static T LoadOrCreate<T>(string filename) where T : Configuration, new()
		{
			if (!File.Exists(filename))
				return new T();

			return Load<T>(filename);
		}
	}
}
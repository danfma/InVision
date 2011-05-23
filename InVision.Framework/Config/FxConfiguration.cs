using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace InVision.Framework.Config
{
	[Serializable]
	[XmlRoot("configuration")]
	public class FxConfiguration
	{
		private Type _gameFlowType;
		private IGameFlow _gameFlow;

		/// <summary>
		/// Initializes a new instance of the <see cref="FxConfiguration"/> class.
		/// </summary>
		public FxConfiguration()
		{
			Screen = new ScreenConfiguration();
			Scripting = new ScriptingConfiguration();
		}

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		[XmlIgnore]
		public static FxConfiguration Instance { get; private set; }

		/// <summary>
		/// Gets the game flow.
		/// </summary>
		/// <value>The game flow.</value>
		[XmlIgnore]
		public IGameFlow GameFlow
		{
			get { return _gameFlow ?? (_gameFlow = (IGameFlow)Activator.CreateInstance(_gameFlowType)); }
		}

		/// <summary>
		/// Gets or sets the type of the game flow.
		/// </summary>
		/// <value>The type of the game flow.</value>
		[XmlElement("game-flow-type")]
		public string GameFlowType
		{
			get { return _gameFlowType == null ? null : _gameFlowType.AssemblyQualifiedName; }
			set { _gameFlowType = Type.GetType(value, true); }
		}

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
		public static FxConfiguration Load(string filename)
		{
			var serializer = new XmlSerializer(typeof(FxConfiguration));

			using (var file = new FileStream(filename, FileMode.Open))
			{
				Instance = (FxConfiguration)serializer.Deserialize(file);
			}

			return Instance;
		}

		/// <summary>
		/// Loads the specified filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static T Load<T>(string filename) where T : FxConfiguration
		{
			var serializer = new XmlSerializer(typeof(T));

			using (var file = new FileStream(filename, FileMode.Open))
			{
				Instance = (T)serializer.Deserialize(file);
			}

			return (T)Instance;
		}

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static FxConfiguration Create()
		{
			return Instance = new FxConfiguration();
		}

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static T Create<T>() where T : FxConfiguration, new()
		{
			return (T)(Instance = new T());
		}

		/// <summary>
		/// Loads the or create.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static FxConfiguration LoadOrCreate(string filename)
		{
			if (!File.Exists(filename))
				return Create();

			return Load(filename);
		}

		/// <summary>
		/// Loads the or create.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static T LoadOrCreate<T>(string filename) where T : FxConfiguration, new()
		{
			if (!File.Exists(filename))
				return Create<T>();

			return Load<T>(filename);
		}
	}
}
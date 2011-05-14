using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace InVision.Framework.Config
{
	[Serializable]
	[XmlRoot("configuration")]
	public sealed class FxConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FxConfiguration"/> class.
		/// </summary>
		private FxConfiguration()
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
			get { return (IGameFlow) Activator.CreateInstance(GameFlowType); }
		}

		/// <summary>
		/// Gets or sets the type of the game flow.
		/// </summary>
		/// <value>The type of the game flow.</value>
		[XmlElement("game-flow-type", typeof (Type))]
		public Type GameFlowType { get; set; }

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
		/// Loads the specified filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static FxConfiguration Load(string filename)
		{
			var serializer = new XmlSerializer(typeof (FxConfiguration));

			using (var file = new FileStream(filename, FileMode.Open))
			{
				Instance = (FxConfiguration) serializer.Deserialize(file);
			}

			return Instance;
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
	}
}
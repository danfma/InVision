using System;
using System.IO;
using InVision;
using InVision.Framework;
using InVision.Ogre.Config;

namespace Tutano
{
	public class Tutano : DisposableObject
	{
		/// <summary>
		/// Gets or sets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public TutanoConfiguration Configuration { get; private set; }

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Configuration = null;
			}
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public void Initialize()
		{
			Configuration = new TutanoConfigLoader().Load(this);

			if (string.IsNullOrEmpty(Configuration.GameFlowType))
				Configuration.GameFlowType = typeof(DefaultGameFlow).AssemblyQualifiedName;

			SetupOgre();
		}

		/// <summary>
		/// Setups the ogre.
		/// </summary>
		private void SetupOgre()
		{
			string ogreConfigDir = Path.GetFullPath("Config/Ogre/");

			if (!Directory.Exists(ogreConfigDir))
				Directory.CreateDirectory(ogreConfigDir);

			Configuration.Ogre.OgreConfigFilename = Path.Combine(ogreConfigDir, "ogre.cfg");
			Configuration.Ogre.PluginsFilename = Path.Combine(ogreConfigDir, "plugins.cfg");

			if (File.Exists(Configuration.Ogre.PluginsFilename))
				return;

			var pluginsConfig = new PluginsConfig {
				PluginsFolder = Configuration.Ogre.PluginsDirectory ?? Path.GetFullPath(TutanoConfigLoader.NativeDirectory)
			};

			foreach (var plugin in Configuration.Ogre.Plugins)
			{
				var pluginConfig = new PluginConfig(plugin);
				pluginsConfig.Add(pluginConfig);
			}

			pluginsConfig.Write(Configuration.Ogre.PluginsFilename);
		}

		/// <summary>
		/// Runs this instance.
		/// </summary>
		public void Run()
		{
			var app = new GameApplication();
			app.Initialize(Configuration);
			app.Execute();
		}
	}
}
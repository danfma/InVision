using System;
using System.Collections.Generic;
using System.Linq;
using InVision.GameMath;
using InVision.Ogre3D;
using InVision.Ogre3D.Util;

namespace InVision.Rendering.Launcher
{
	internal class MainClass
	{
		public static void Main(string[] args)
		{
			var configFile = new ConfigFile();
			configFile.Load("Config/resources.cfg");

			var settings =
				from section in configFile.GetSections()
				from setting in section.Value
				select new { Section = section.Key, Setting = setting.Key, setting.Value };

			foreach (var setting in settings)
			{
				Console.WriteLine("Section: {0} Setting: {1} Value: {2}",
					setting.Section, setting.Setting, setting.Value);
			}

			Console.Read();

			//StartOgre();
		}

		private static void StartOgre()
		{
			using (var root = new Root("Config/plugins.cfg", "Config/ogre.cfg"))
			{
				if (!root.RestoreConfig())
				{
					if (root.ShowConfigDialog())
						root.SaveConfig();
					else
						return;
				}

				IEnumerable<RenderSystem> renderSystems = root.AvailableRenderers;

				foreach (RenderSystem renderSystem in renderSystems)
				{
					Console.WriteLine("RenderSystem: {0}", renderSystem.Name);
				}

				root.Initialise(false);

				var options = new NameValueDictionary();
				options["title"] = "My Custom OGRE window managed";

				var window = root.CreateRenderWindow("MainWindow", 800, 600, false, options);
				var sceneManager = root.CreateSceneManager(SceneType.Generic, "MySceneManager");

				var camera = sceneManager.CreateCamera("MainCamera");
				camera.AspectRatio = window.Width / (float)window.Height;
				camera.FOVy = Radian.FromDegrees(30f);
				camera.NearClipDistance = 5f;
				camera.FarClipDistance = 1000f;
				camera.PolygonMode = PolygonMode.Solid;
				camera.Position = new Vector3(0, 1, 10);

				float counter = 0;

				root.FrameEvent.EnableListeners();
				root.FrameEvent.FrameEnded +=
					e =>
					{
						counter += e.TimeSinceLastFrame;

						return counter < 10;
					};

				root.StartRendering();
			}
		}
	}
}
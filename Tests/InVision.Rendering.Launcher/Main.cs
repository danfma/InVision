using System;
using System.Collections.Generic;
using InVision.Collections;
using OpenTK;

namespace InVision.Rendering.Launcher
{
	internal class MainClass
	{
		public static void Main(string[] args)
		{
			StartOgre();
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
				camera.AspectRatio = window.Width/(float) window.Height;
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
using System;
using System.Collections.Generic;
using InVision.Ogre3D;
using InVision.Ogre3D.Util;
using OpenTK;
using MVector3 = Mono.GameMath.Vector3;

namespace InVision.Rendering.Launcher
{
	internal class MainClass
	{
		public static void Main(string[] args)
		{
			var vlist = new MVector3[1024 * 1024 * 50];
			int times = 5;
			int timeCounter = 0;
			long ticksSum = 0;

			vlist[0] = new MVector3(0);
			vlist[1] = new MVector3(1);

			do
			{
				long start = DateTime.Now.Ticks;


				for (int i = 2; i < vlist.Length; i++)
				{
					vlist[i] = vlist[i - 1] + vlist[i - 2];
				}

				ticksSum += DateTime.Now.Ticks - start;

			} while (++timeCounter < times);

			Console.WriteLine("Media de execução: {0}s", new TimeSpan(ticksSum / times).TotalSeconds);
			Console.WriteLine("Tempo total: {0}s", new TimeSpan(ticksSum).TotalSeconds);

			//StartOgre();

			Console.Read();
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
				camera.Position = new Vector3(0, 2, 0);

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
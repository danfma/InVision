using System;
using InVision.Extensions;
using InVision.FMod;
using InVision.FMod.Native;
using InVision.Framework.States;
using InVision.GameMath;
using InVision.Ogre;

namespace Karel.Flow
{
	public class KarelGameState : GameState
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="KarelGameState"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public KarelGameState(string name)
			: base(name)
		{
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public override void Initialize()
		{
			ConfigFile.LoadResources("Config/Ogre/resources.cfg");
			ConfigureScene();
			ConfigureAudio();

			base.Initialize();
		}

		/// <summary>
		/// Configures the scene.
		/// </summary>
		private void ConfigureScene()
		{
			var world = KarelGameFlow.World;

			if (world == null)
				return;

			dynamic ogre = GameApplication.Variables.Ogre;
			var root = (Root)ogre.Root;

			var sceneManager = root.CreateSceneManager(SceneType.Generic);
			sceneManager.AmbientLight = new Color(0.5f, 0.5f, 0.5f);
			ogre.SceneManager = sceneManager;

			Degree fieldOfView = 60f.Degree();

			var camera = sceneManager.CreateCamera("MainCamera");
			camera.Position = new Vector3(world.Rows / 2f, 2f * world.Columns, 0);
			camera.LookAt(new Vector3(world.Rows / 2f, 0, world.Columns / 2f));
			camera.NearClipDistance = 0.5f;
			camera.FieldOfView = fieldOfView;
			ogre.MainCamera = camera;

			var renderWindow = (RenderWindow)ogre.RenderWindow;
			var viewport = renderWindow.AddViewport(camera);
			viewport.BackgroundColor = Color.Black;
			ogre.Viewport = viewport;

			float aspect = viewport.ActualWidth / (float)viewport.ActualHeight;
			camera.AspectRatio = aspect;

			TextureManager.Instance.DefaultNumMipmaps = 5;
			TextureManager.Instance.ReloadAll();

			var light = sceneManager.CreateLight("MainLight");
			var lightPos = camera.Position + new Vector3(0, 15, 0);
			light.SetPosition(lightPos.X, lightPos.Y, lightPos.Z);
		}

		/// <summary>
		/// Configures the audio.
		/// </summary>
		private void ConfigureAudio()
		{
			var audioSystem = (AudioSystem)GameApplication.Variables.AudioSystem;
			audioSystem.Init(32, INITFLAGS.NORMAL);
			audioSystem.SetStreamBufferSize(64 * 1024, TIMEUNIT.RAWBYTES);
		}
	}
}
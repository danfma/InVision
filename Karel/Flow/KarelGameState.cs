using System;
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

			dynamic ogre = GameApplication.GlobalVariables.Ogre;
			var root = (Root)ogre.Root;

			var sceneManager = root.CreateSceneManager(SceneType.Generic);
			sceneManager.AmbientLight = new Color(0.7f, 0.3f, 0.2f);
			ogre.SceneManager = sceneManager;

			var camera = sceneManager.CreateCamera("MainCamera");
			camera.Position = new Vector3(0, world.Rows + world.Columns, -(world.Rows + world.Columns));
			camera.LookAt(new Vector3());
			camera.NearClipDistance = 0.5f;
			ogre.MainCamera = camera;

			var renderWindow = (RenderWindow)ogre.RenderWindow;
			var viewport = renderWindow.AddViewport(camera);
			viewport.BackgroundColor = Color.Black;
			ogre.Viewport = viewport;

			float aspect = viewport.ActualWidth / (float)viewport.ActualHeight;
			camera.AspectRatio = aspect;

			TextureManager.Instance.DefaultNumMipmaps = 5;

			var light = sceneManager.CreateLight("MainLight");
			var lightPos = camera.Position + new Vector3(0, 10, 0);
			light.SetPosition(lightPos.X, lightPos.Y, lightPos.Z);
		}

		/// <summary>
		/// Configures the audio.
		/// </summary>
		private void ConfigureAudio()
		{
			var audioSystem = (AudioSystem)GameApplication.GlobalVariables.AudioSystem;
			audioSystem.Init(32, INITFLAGS.NORMAL);
			audioSystem.SetStreamBufferSize(64 * 1024, TIMEUNIT.RAWBYTES);
		}
	}
}
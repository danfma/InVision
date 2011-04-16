using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using InVision.GameMath;
using InVision.Rendering;
using InVision.Rendering.Listeners;

namespace InVision.TutorialFx
{
	public abstract partial class BaseApplication
	{
		protected Camera Camera;
		protected CameraMan CameraMan;
		protected DebugOverlay DebugOverlay;
		protected string PluginsCfg = "plugins.cfg";
		protected int RenderMode;
		protected string ResourcesCfg = "resources.cfg";
		protected Root Root;
		protected SceneManager SceneMgr;
		protected bool ShutDown;
		protected int TextureMode;
		protected RenderWindow Window;

		/// <summary>
		/// Gets or sets the plugin directory.
		/// </summary>
		/// <value>The plugin directory.</value>
		public string ConfigDirectory { get; set; }

		/// <summary>
		/// Goes this instance.
		/// </summary>
		public void Go()
		{
			try
			{
				if (!Setup())
					return;

				Root.StartRendering();

				DestroyScene();
			}
			catch (SEHException e)
			{
				Console.WriteLine(e);

				MessageBox.Show(
					"An Ogre error has occurred. Check the Ogre.log file for details", "Exception",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);

				MessageBox.Show(
					e.Message, "Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Setups this instance.
		/// </summary>
		/// <returns></returns>
		protected virtual bool Setup()
		{
			if (!string.IsNullOrEmpty(ConfigDirectory))
				PluginsCfg = Path.Combine(ConfigDirectory, PluginsCfg);

			Root = new Root(PluginsCfg);

			if (!Configure())
				return false;

			ChooseSceneManager();
			CreateCamera();
			CreateViewports();

			TextureManager.Instance.DefaultNumMipmaps = 5;

			CreateResourceListener();
			LoadResources();

			CreateScene();

			CreateFrameListeners();
			InitializeInput();

			DebugOverlay = new DebugOverlay(Window);
			DebugOverlay.AdditionalInfo = "Bilinear";

			return true;
		}

		protected virtual bool Configure()
		{
			if (Root.ShowConfigDialog())
			{
				Window = Root.Initialise(true, "TutorialApplication Render Window");
				return true;
			}

			return false;
		}

		protected virtual void ChooseSceneManager()
		{
			SceneMgr = Root.CreateSceneManager(SceneType.Generic);
		}

		protected virtual void CreateCamera()
		{
			Camera = SceneMgr.CreateCamera("PlayerCam");

			Camera.Position = new Vector3(0, 100, 250);

			Camera.LookAt(new Vector3(0, 50, 0));
			Camera.NearClipDistance = 5;

			CameraMan = new CameraMan(Camera);
		}

		protected virtual void CreateViewports()
		{
			// Create one viewport, entire window
			Viewport vp = Window.AddViewport(Camera);
			vp.BackgroundColour = ColourValues.Black;

			// Alter the camera aspect ratio to match the viewport
			float aspectRatio = vp.ActualWidth / (float)vp.ActualHeight;

			if (float.IsNaN(aspectRatio))
				Camera.SetAutoAspectRatio(true);
			else
				Camera.AspectRatio = aspectRatio;
		}

		protected virtual void CreateResourceListener()
		{
		}

		protected virtual void LoadResources()
		{
			if (!string.IsNullOrEmpty(ConfigDirectory))
				ResourcesCfg = Path.Combine(ConfigDirectory, ResourcesCfg);

			// Load resource paths from config file
			var cf = new ConfigFile();
			cf.Load(ResourcesCfg, "\t:=", true);

			// Go through all sections & settings in the file
			var settings =
				from section in cf.GetSections()
				from setting in section.Value
				select new { Section = section.Key, Setting = setting.Key, setting.Value };

			foreach (var setting in settings)
			{
				ResourceGroupManager.Instance.AddResourceLocation(
					setting.Value, setting.Setting, setting.Section);
			}

			ResourceGroupManager.Instance.InitialiseAllResourceGroups();
		}

		protected void ReloadAllTextures()
		{
			TextureManager.Instance.ReloadAll();
		}

		protected void CycleTextureFilteringMode()
		{
			TextureMode = (TextureMode + 1) % 4;
			switch (TextureMode)
			{
				case 0:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.Bilinear);
					DebugOverlay.AdditionalInfo = "BiLinear";
					break;

				case 1:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.Trilinear);
					DebugOverlay.AdditionalInfo = "TriLinear";
					break;

				case 2:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.Anisotropic);
					MaterialManager.Instance.DefaultAnisotropy = 8;
					DebugOverlay.AdditionalInfo = "Anisotropic";
					break;

				case 3:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.None);
					MaterialManager.Instance.DefaultAnisotropy = 1;
					DebugOverlay.AdditionalInfo = "None";
					break;
			}
		}

		protected void CyclePolygonMode()
		{
			RenderMode = (RenderMode + 1) % 3;

			switch (RenderMode)
			{
				case 0:
					Camera.PolygonMode = PolygonMode.Solid;
					break;

				case 1:
					Camera.PolygonMode = PolygonMode.Wireframe;
					break;

				case 2:
					Camera.PolygonMode = PolygonMode.Points;
					break;
			}
		}

		protected void TakeScreenshot()
		{
			Window.WriteContentsToTimestampedFile("screenshot", ".png");
		}

		protected virtual void CreateFrameListeners()
		{
			Root.FrameEvent.FrameStarted += OnFrameRenderingQueued;
		}

		protected virtual bool OnFrameRenderingQueued(FrameEvent evt)
		{
			if (Window.IsClosed)
				return false;

			if (ShutDown)
				return false;

			try
			{
				ProcessInput();

				UpdateScene(evt);

				CameraMan.UpdateCamera(evt.TimeSinceLastFrame);
				DebugOverlay.Update(evt.TimeSinceLastFrame);

				return true;
			}
			catch (ShutdownException)
			{
				ShutDown = true;
				return false;
			}
		}

		protected void Shutdown()
		{
			throw new ShutdownException();
		}

		protected virtual void CreateScene()
		{
		}

		protected virtual void UpdateScene(FrameEvent evt)
		{
		}

		protected virtual void DestroyScene()
		{
		}
	}
}
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using InVision.Rendering;
using InVision.Rendering.Listeners;
using OpenTK;

namespace InVision.TutorialFx
{
	public abstract partial class BaseApplication
	{
		protected Camera mCamera;
		protected CameraMan mCameraMan;
		protected DebugOverlay mDebugOverlay;
		protected string mPluginsCfg = "plugins.cfg";
		protected int mRenderMode;
		protected string mResourcesCfg = "resources.cfg";
		protected Root mRoot;
		protected SceneManager mSceneMgr;
		protected bool mShutDown;
		protected int mTextureMode;
		protected RenderWindow mWindow;

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

				mRoot.StartRendering();

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
				mPluginsCfg = Path.Combine(ConfigDirectory, mPluginsCfg);

			mRoot = new Root(mPluginsCfg);

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

			mDebugOverlay = new DebugOverlay(mWindow);
			mDebugOverlay.AdditionalInfo = "Bilinear";

			return true;
		}

		protected virtual bool Configure()
		{
			if (mRoot.ShowConfigDialog())
			{
				mWindow = mRoot.Initialise(true, "TutorialApplication Render Window");
				return true;
			}

			return false;
		}

		protected virtual void ChooseSceneManager()
		{
			mSceneMgr = mRoot.CreateSceneManager(SceneType.Generic);
		}

		protected virtual void CreateCamera()
		{
			mCamera = mSceneMgr.CreateCamera("PlayerCam");

			mCamera.Position = new Vector3(0, 100, 250);

			mCamera.LookAt(new Vector3(0, 50, 0));
			mCamera.NearClipDistance = 5;

			mCameraMan = new CameraMan(mCamera);
		}

		protected virtual void CreateViewports()
		{
			// Create one viewport, entire window
			var vp = mWindow.AddViewport(mCamera);
			vp.BackgroundColour = ColourValues.Black;

			// Alter the camera aspect ratio to match the viewport
			float aspectRatio = vp.ActualWidth / (float)vp.ActualHeight;

			if (float.IsNaN(aspectRatio))
				mCamera.SetAutoAspectRatio(true);
			else
				mCamera.AspectRatio = aspectRatio;
		}

		protected virtual void CreateResourceListener()
		{
		}

		protected virtual void LoadResources()
		{
			if (!string.IsNullOrEmpty(ConfigDirectory))
				mResourcesCfg = Path.Combine(ConfigDirectory, mResourcesCfg);

			// Load resource paths from config file
			var cf = new ConfigFile();
			cf.Load(mResourcesCfg, "\t:=", true);

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
			mTextureMode = (mTextureMode + 1) % 4;
			switch (mTextureMode)
			{
				case 0:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.Bilinear);
					mDebugOverlay.AdditionalInfo = "BiLinear";
					break;

				case 1:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.Trilinear);
					mDebugOverlay.AdditionalInfo = "TriLinear";
					break;

				case 2:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.Anisotropic);
					MaterialManager.Instance.DefaultAnisotropy = 8;
					mDebugOverlay.AdditionalInfo = "Anisotropic";
					break;

				case 3:
					MaterialManager.Instance.SetDefaultTextureFiltering(TextureFilterOption.None);
					MaterialManager.Instance.DefaultAnisotropy = 1;
					mDebugOverlay.AdditionalInfo = "None";
					break;
			}
		}

		protected void CyclePolygonMode()
		{
			mRenderMode = (mRenderMode + 1) % 3;

			switch (mRenderMode)
			{
				case 0:
					mCamera.PolygonMode = PolygonMode.Solid;
					break;

				case 1:
					mCamera.PolygonMode = PolygonMode.Wireframe;
					break;

				case 2:
					mCamera.PolygonMode = PolygonMode.Points;
					break;
			}
		}

		protected void TakeScreenshot()
		{
			mWindow.WriteContentsToTimestampedFile("screenshot", ".png");
		}

		protected virtual void CreateFrameListeners()
		{
			mRoot.FrameEvent.FrameStarted += OnFrameRenderingQueued;
		}

		protected virtual bool OnFrameRenderingQueued(FrameEvent evt)
		{
			if (mWindow.IsClosed)
				return false;

			if (mShutDown)
				return false;

			try
			{
				ProcessInput();

				UpdateScene(evt);

				mCameraMan.UpdateCamera(evt.TimeSinceLastFrame);
				mDebugOverlay.Update(evt.TimeSinceLastFrame);

				return true;
			}
			catch (ShutdownException)
			{
				mShutDown = true;
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
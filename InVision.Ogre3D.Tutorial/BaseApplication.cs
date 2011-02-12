using System;
using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Ogre3D.Listeners;

namespace InVision.Ogre3D.Tutorial
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

				System.Windows.Forms.MessageBox.Show(
					"An Ogre error has occurred. Check the Ogre.log file for details", "Exception",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Error);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);

				System.Windows.Forms.MessageBox.Show(
					e.Message, "Error",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		protected virtual bool Setup()
		{
			mRoot = new Root(mPluginsCfg);

			if (!Configure())
				return false;

			ChooseSceneManager();
			CreateCamera();
			CreateViewports();

			TextureManager.Singleton.DefaultNumMipmaps = 5;

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
			else
			{
				return false;
			}
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
			mCamera.AspectRatio = (vp.ActualWidth / (float)vp.ActualHeight);
		}

		protected virtual void CreateResourceListener()
		{
		}

		protected virtual void LoadResources()
		{
			// Load resource paths from config file
			var cf = new ConfigFile();
			cf.Load(mResourcesCfg, "\t:=", true);

			// Go through all sections & settings in the file
			var seci = cf.GetSectionIterator();
			while (seci.MoveNext())
			{
				foreach (var pair in seci.Current)
				{
					ResourceGroupManager.Singleton.AddResourceLocation(
						pair.Value, pair.Key, seci.CurrentKey);
				}
			}

			ResourceGroupManager.Singleton.InitialiseAllResourceGroups();
		}

		protected void ReloadAllTextures()
		{
			TextureManager.Singleton.ReloadAll();
		}

		protected void CycleTextureFilteringMode()
		{
			mTextureMode = (mTextureMode + 1) % 4;
			switch (mTextureMode)
			{
				case 0:
					MaterialManager.Singleton.SetDefaultTextureFiltering(TextureFilterOptions.TFO_BILINEAR);
					mDebugOverlay.AdditionalInfo = "BiLinear";
					break;

				case 1:
					MaterialManager.Singleton.SetDefaultTextureFiltering(TextureFilterOptions.TFO_TRILINEAR);
					mDebugOverlay.AdditionalInfo = "TriLinear";
					break;

				case 2:
					MaterialManager.Singleton.SetDefaultTextureFiltering(TextureFilterOptions.TFO_ANISOTROPIC);
					MaterialManager.Singleton.DefaultAnisotropy = 8;
					mDebugOverlay.AdditionalInfo = "Anisotropic";
					break;

				case 3:
					MaterialManager.Singleton.SetDefaultTextureFiltering(TextureFilterOptions.TFO_NONE);
					MaterialManager.Singleton.DefaultAnisotropy = 1;
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
			mRoot.FrameRenderingQueued += new FrameListener.FrameRenderingQueuedHandler(OnFrameRenderingQueued);
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

				mCameraMan.UpdateCamera(evt.timeSinceLastFrame);

				mDebugOverlay.Update(evt.timeSinceLastFrame);

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
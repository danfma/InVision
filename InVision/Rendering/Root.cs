using System;
using System.Collections.Generic;
using InVision.Collections;
using InVision.Native;
using InVision.Native.Ogre;
using InVision.Rendering.Listeners;

namespace InVision.Rendering
{
	public sealed class Root : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Root" /> class.
		/// </summary>
		/// <param name = "pluginFilename">The plugin filename.</param>
		/// <param name = "configFilename">The config filename.</param>
		/// <param name = "logFilename">The log filename.</param>
		public Root(string pluginFilename = "plugins.cfg", string configFilename = "ogre.cfg", string logFilename = null)
		{
			if (Instance != null)
				throw new InvalidOperationException("Only one instance is allowed");

			IntPtr pRoot;

			if (logFilename == null)
				pRoot = NativeOgreRoot.New(pluginFilename, configFilename);
			else
				pRoot = NativeOgreRoot.NewWithLog(pluginFilename, configFilename, logFilename);

			Instance = this;

			SetHandle(pRoot);
			InitializeComponents();
		}

		/// <summary>
		/// 	Gets or sets the frame event.
		/// </summary>
		/// <value>The frame event.</value>
		public FrameEventDispatcher FrameEvent { get; private set; }

		/// <summary>
		/// 	Gets the available renderers.
		/// </summary>
		/// <value>The available renderers.</value>
		public IEnumerable<RenderSystem> AvailableRenderers
		{
			get { return NativeOgreRoot.GetAvailableRenderers(handle); }
		}

		/// <summary>
		/// 	Gets the render system.
		/// </summary>
		/// <value>The render system.</value>
		public RenderSystem RenderSystem
		{
			get { return NativeOgreRoot.GetRenderSystem(handle); }
		}

		/// <summary>
		/// 	Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static Root Instance { get; private set; }

		/// <summary>
		/// 	Initializes this instance.
		/// </summary>
		private void InitializeComponents()
		{
			FrameEvent = new FrameEventDispatcher();
		}

		/// <summary>
		/// 	Releases the unmanaged resources used by the <see cref = "T:System.Runtime.InteropServices.SafeHandle" /> class specifying whether to perform a normal dispose operation.
		/// </summary>
		/// <param name = "disposing">true for a normal dispose operation; false to finalize the handle.</param>
		protected override void Dispose(bool disposing)
		{
			if (FrameEvent != null)
			{
				FrameEvent.Dispose();
				FrameEvent = null;
			}

			base.Dispose(disposing);

			if (Instance != null && ReferenceEquals(this, Instance))
				Instance = null;
		}


		/// <summary>
		/// 	Releases the specified handle.
		/// </summary>
		/// <param name = "pSelf">The handle.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			NativeOgreRoot.Delete(pSelf);
			SetHandleAsInvalid();

			return true;
		}

		/// <summary>
		/// 	Saves the config.
		/// </summary>
		public void SaveConfig()
		{
			NativeOgreRoot.SaveConfig(handle);
		}

		/// <summary>
		/// 	Restores the config.
		/// </summary>
		/// <returns></returns>
		public bool RestoreConfig()
		{
			return NativeOgreRoot.RestoreConfig(handle);
		}

		/// <summary>
		/// 	Shows the config dialog.
		/// </summary>
		/// <returns></returns>
		public bool ShowConfigDialog()
		{
			return NativeOgreRoot.ShowConfigDialog(handle);
		}

		/// <summary>
		/// 	Initialises the specified auto create window.
		/// </summary>
		/// <param name = "autoCreateWindow">if set to <c>true</c> [auto create window].</param>
		/// <param name = "winTitle">The win title.</param>
		/// <param name = "capabilitiesConfig">The capabilities config.</param>
		/// <returns></returns>
		public RenderWindow Initialise(bool autoCreateWindow, string winTitle = null, string capabilitiesConfig = null)
		{
			IntPtr pRenderWindow;

			if (winTitle == null && capabilitiesConfig == null)
				pRenderWindow = NativeOgreRoot.Initialise(handle, autoCreateWindow);
			else if (winTitle != null && capabilitiesConfig == null)
				pRenderWindow = NativeOgreRoot.InitialiseWithTitle(handle, autoCreateWindow, winTitle);
			else
				pRenderWindow = NativeOgreRoot.InitialiseWithTitleAndCap(handle, autoCreateWindow, winTitle, capabilitiesConfig);

			if (pRenderWindow == IntPtr.Zero)
				return null;

			return pRenderWindow.AsHandle(ptr => new RenderWindow(ptr));
		}

		/// <summary>
		/// 	Starts the rendering.
		/// </summary>
		public void StartRendering()
		{
			NativeOgreRoot.StartRendering(handle);
		}

		/// <summary>
		/// 	Loads the plugin.
		/// </summary>
		/// <param name = "pluginName">Name of the plugin.</param>
		public void LoadPlugin(string pluginName)
		{
			NativeOgreRoot.LoadPlugin(handle, pluginName);
		}

		/// <summary>
		/// 	Unloads the plugin.
		/// </summary>
		/// <param name = "pluginName">Name of the plugin.</param>
		public void UnloadPlugin(string pluginName)
		{
			NativeOgreRoot.UnloadPlugin(handle, pluginName);
		}

		/// <summary>
		/// 	Gets the name of the render system by.
		/// </summary>
		/// <param name = "name">The name.</param>
		/// <returns></returns>
		public RenderSystem GetRenderSystemByName(string name)
		{
			return NativeOgreRoot.GetRenderSystemByName(handle, name);
		}

		/// <summary>
		/// 	Sets the render system.
		/// </summary>
		/// <param name = "renderSystem">The render system.</param>
		public void SetRenderSystem(RenderSystem renderSystem)
		{
			NativeOgreRoot.SetRenderSystem(handle, renderSystem.DangerousGetHandle());
		}

		/// <summary>
		/// 	Enables the frame dispatcher.
		/// </summary>
		/// <param name = "dispatcher">The dispatcher.</param>
		public void EnableFrameDispatcher(FrameEventDispatcher dispatcher)
		{
			NativeOgreRoot.AddFrameListener(handle, dispatcher.DangerousGetHandle());
		}

		/// <summary>
		/// 	Disables the frame dispatcher.
		/// </summary>
		/// <param name = "dispatcher">The dispatcher.</param>
		public void DisableFrameDispatcher(FrameEventDispatcher dispatcher)
		{
			NativeOgreRoot.RemoveFrameListener(handle, dispatcher.DangerousGetHandle());
		}

		/// <summary>
		/// 	Creates the render window.
		/// </summary>
		/// <param name = "windowName">Name of the window.</param>
		/// <param name = "width">The width.</param>
		/// <param name = "height">The height.</param>
		/// <param name = "fullscreen">if set to <c>true</c> [fullscreen].</param>
		/// <param name = "options">The options.</param>
		/// <returns></returns>
		public RenderWindow CreateRenderWindow(string windowName, int width, int height, bool fullscreen = false,
											   NameValueDictionary options = null)
		{
			IntPtr pRenderWindow;

			if (options == null)
				pRenderWindow = NativeOgreRoot.CreateRenderWindow(handle, windowName, width, height, fullscreen);
			else
			{
				options.Flush();
				pRenderWindow = NativeOgreRoot.CreateRenderWindow(handle, windowName, width, height, fullscreen,
																  options.DictionaryHandle);
			}

			return pRenderWindow.AsHandle(ptr => new RenderWindow(ptr));
		}

		/// <summary>
		/// 	Creates the scene manager.
		/// </summary>
		/// <param name = "sceneType">Type of the scene.</param>
		/// <param name = "instanceName">Name of the instance.</param>
		/// <returns></returns>
		public SceneManager CreateSceneManager(SceneType sceneType, string instanceName = null)
		{
			IntPtr pSceneManager;

			if (string.IsNullOrEmpty(instanceName))
				pSceneManager = NativeOgreRoot.CreateSceneManagerByType(handle, sceneType);
			else
				pSceneManager = NativeOgreRoot.CreateSceneManagerByType(handle, sceneType, instanceName);

			return pSceneManager.AsHandle(ptr => new SceneManager(ptr));
		}

		/// <summary>
		/// 	Creates the scene manager.
		/// </summary>
		/// <param name = "typeName">Name of the type.</param>
		/// <param name = "instanceName">Name of the instance.</param>
		/// <returns></returns>
		public SceneManager CreateSceneManager(string typeName, string instanceName = null)
		{
			IntPtr pSceneManager;

			if (string.IsNullOrEmpty(instanceName))
				pSceneManager = NativeOgreRoot.CreateSceneManagerByTypeName(handle, typeName);
			else
				pSceneManager = NativeOgreRoot.CreateSceneManagerByTypeName(handle, typeName, instanceName);

			return pSceneManager.AsHandle(ptr => new SceneManager(ptr));
		}
	}
}
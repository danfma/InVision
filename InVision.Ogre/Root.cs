using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Root : CppWrapper<IRoot>
	{
		private static readonly IRoot Static = CreateCppInstance<IRoot>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Root"/> class.
		/// </summary>
		/// <param name="native">The native.</param>
		protected Root(IRoot native)
			: base(native)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Root"/> class.
		/// </summary>
		public Root(
			string pluginFilename = "Ogre-Plugins.cfg",
			string configFilename = "Ogre.cfg",
			string logFilename = "Ogre.log")
			: this(CreateCppInstance<IRoot>())
		{
			Native.Construct(pluginFilename, configFilename, logFilename).SetOwner(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.Destruct();

			base.Dispose(disposing);
		}

		#region IRoot

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static Root Instance
		{
			get
			{
				IRoot root = Static.GetSingleton();

				return GetOwner<Root>(root);
			}
		}

		/// <summary>
		/// Saves the config.
		/// </summary>
		public void SaveConfig()
		{
			Native.SaveConfig();
		}

		/// <summary>
		/// Restores the config.
		/// </summary>
		/// <returns></returns>
		public bool RestoreConfig()
		{
			return Native.RestoreConfig();
		}

		/// <summary>
		/// Shows the config dialog.
		/// </summary>
		/// <returns></returns>
		public bool ShowConfigDialog()
		{
			return Native.ShowConfigDialog();
		}

		/// <summary>
		/// Adds the render system.
		/// </summary>
		/// <param name="renderSystem">The render system.</param>
		public void AddRenderSystem(RenderSystem renderSystem)
		{
			Native.AddRenderSystem(renderSystem != null ? renderSystem.Native : null);
		}

		/// <summary>
		/// Gets the name of the render system by.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public IntPtr GetRenderSystemByName(string name)
		{
			return Native.GetRenderSystemByName(name);
		}

		/// <summary>
		/// Sets the render system.
		/// </summary>
		/// <param name="renderSystem">The render system.</param>
		public void SetRenderSystem(RenderSystem renderSystem)
		{
			Native.SetRenderSystem(renderSystem != null ? renderSystem.Native : null);
		}

		/// <summary>
		/// Gets the render system.
		/// </summary>
		/// <returns></returns>
		public RenderSystem GetRenderSystem()
		{
			return GetOrCreateOwner(Native.GetRenderSystem(), native => new RenderSystem(native));
		}

		/// <summary>
		/// Initializes the specified auto create window.
		/// </summary>
		/// <param name="autoCreateWindow">if set to <c>true</c> [auto create window].</param>
		/// <returns></returns>
		public RenderWindow Initialize(bool autoCreateWindow)
		{
			return GetOrCreateOwner(Native.Initialize(autoCreateWindow), native => new RenderWindow(native));
		}

		/// <summary>
		/// Initializes the specified auto create window.
		/// </summary>
		/// <param name="autoCreateWindow">if set to <c>true</c> [auto create window].</param>
		/// <param name="windowTitle">The window title.</param>
		/// <returns></returns>
		public RenderWindow Initialize(bool autoCreateWindow, string windowTitle)
		{
			return GetOrCreateOwner(Native.Initialize(autoCreateWindow, windowTitle), native => new RenderWindow(native));
		}

		/// <summary>
		/// Initializes the specified auto create window.
		/// </summary>
		/// <param name="autoCreateWindow">if set to <c>true</c> [auto create window].</param>
		/// <param name="windowTitle">The window title.</param>
		/// <param name="customCapabilities">The custom capabilities.</param>
		/// <returns></returns>
		public RenderWindow Initialize(bool autoCreateWindow, string windowTitle, string customCapabilities)
		{
			return GetOrCreateOwner(Native.Initialize(autoCreateWindow, windowTitle, customCapabilities),
									native => new RenderWindow(native));
		}

		/// <summary>
		/// Determines whether this instance is initialized.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance is initialized; otherwise, <c>false</c>.
		/// </returns>
		public bool IsInitialized()
		{
			return Native.IsInitialized();
		}

		/// <summary>
		/// Uses the custom render system capabilities.
		/// </summary>
		/// <param name="capabilities">The capabilities.</param>
		public void UseCustomRenderSystemCapabilities(RenderSystemCapabilities capabilities)
		{
			Native.UseCustomRenderSystemCapabilities(capabilities != null ? capabilities.Native : null);
		}

		/// <summary>
		/// Gets the remove render queue structures on clear.
		/// </summary>
		/// <returns></returns>
		public bool GetRemoveRenderQueueStructuresOnClear()
		{
			return Native.GetRemoveRenderQueueStructuresOnClear();
		}

		/// <summary>
		/// Sets the remove render queue structures on clear.
		/// </summary>
		/// <param name="value">if set to <c>true</c> [value].</param>
		public void SetRemoveRenderQueueStructuresOnClear(bool value)
		{
			Native.SetRemoveRenderQueueStructuresOnClear(value);
		}

		/// <summary>
		/// Adds the scene manager factory.
		/// </summary>
		/// <param name="factory">The factory.</param>
		public void AddSceneManagerFactory(SceneManagerFactory factory)
		{
			Native.AddSceneManagerFactory(factory != null ? factory.Native : null);
		}

		/// <summary>
		/// Removes the scene manager factory.
		/// </summary>
		/// <param name="factory">The factory.</param>
		public void RemoveSceneManagerFactory(SceneManagerFactory factory)
		{
			Native.RemoveSceneManagerFactory(factory != null ? factory.Native : null);
		}

		/// <summary>
		/// Creates the scene manager.
		/// </summary>
		/// <param name="sceneType">Type of the scene.</param>
		/// <returns></returns>
		public SceneManager CreateSceneManager(SceneType sceneType)
		{
			return GetOrCreateOwner(Native.CreateSceneManager(sceneType), native => new SceneManager(native));
		}

		/// <summary>
		/// Creates the scene manager.
		/// </summary>
		/// <param name="sceneType">Type of the scene.</param>
		/// <param name="instanceName">Name of the instance.</param>
		/// <returns></returns>
		public SceneManager CreateSceneManager(SceneType sceneType, string instanceName)
		{
			return GetOrCreateOwner(Native.CreateSceneManager(sceneType, instanceName),
									native => new SceneManager(native));
		}

		#endregion
	}

	public class SceneManager : CppWrapper<ISceneManager>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SceneManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public SceneManager(ISceneManager nativeInstance)
			: base(nativeInstance)
		{
		}
	}

	public class SceneManagerFactory : CppWrapper<ISceneManagerFactory>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SceneManagerFactory"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public SceneManagerFactory(ISceneManagerFactory nativeInstance)
			: base(nativeInstance)
		{
		}
	}

	public class RenderSystemCapabilities : CppWrapper<IRenderSystemCapabilities>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderSystemCapabilities"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public RenderSystemCapabilities(IRenderSystemCapabilities nativeInstance)
			: base(nativeInstance)
		{
		}
	}

	public class RenderWindow : CppWrapper<IRenderWindow>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderWindow"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public RenderWindow(IRenderWindow nativeInstance)
			: base(nativeInstance)
		{
		}
	}

	public class RenderSystem : CppWrapper<IRenderSystem>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderSystem"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public RenderSystem(IRenderSystem nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}
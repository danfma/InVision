using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("Root")]
	public interface IRoot : ICppInstance, ISingleton<IRoot>
	{
		[Constructor(Implemented = true)]
		IRoot Construct();

		[Constructor(Implemented = true)]
		IRoot Construct(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename);

		[Constructor(Implemented = true)]
		IRoot Construct(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename);

		[Constructor(Implemented = true)]
		IRoot Construct(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename,
			[MarshalAs(UnmanagedType.LPStr)] string logFilename);

		[Destructor(Implemented = true)]
		void Destruct();

		[Method(Implemented = true)]
		void SaveConfig();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		bool RestoreConfig();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		bool ShowConfigDialog();

		[Method]
		void AddRenderSystem(IRenderSystem renderSystem);

		[Method]
		IntPtr GetRenderSystemByName([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method]
		void SetRenderSystem(IRenderSystem renderSystem);

		[Method]
		IRenderSystem GetRenderSystem();

		[Method(Implemented = true)]
		IRenderWindow Initialize(
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow);

		[Method(Implemented = true)]
		IRenderWindow Initialize(
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string windowTitle);

		[Method(Implemented = true)]
		IRenderWindow Initialize(
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string windowTitle,
			[MarshalAs(UnmanagedType.LPStr)] string customCapabilities);

		[Method(Implemented = true)]
		bool IsInitialized();

		[Method]
		void UseCustomRenderSystemCapabilities(IRenderSystemCapabilities capabilities);

		[Method]
		bool GetRemoveRenderQueueStructuresOnClear();

		[Method]
		void SetRemoveRenderQueueStructuresOnClear([MarshalAs(UnmanagedType.I1)] bool value);

		[Method]
		void AddSceneManagerFactory(ISceneManagerFactory factory);

		[Method]
		void RemoveSceneManagerFactory(ISceneManagerFactory factory);

		[Method(Implemented = true)]
		ISceneManager CreateSceneManager(SceneType sceneType);

		[Method(Implemented = true)]
		ISceneManager CreateSceneManager(SceneType sceneType, [MarshalAs(UnmanagedType.LPStr)] string instanceName);

		[Method(Implemented = true)]
		IRenderWindow CreateRenderWindow(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			uint width, uint height,
			[MarshalAs(UnmanagedType.I1)] bool fullscreen);

		[Method(Implemented = true)]
		IRenderWindow CreateRenderWindow(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			uint width, uint height,
			[MarshalAs(UnmanagedType.I1)] bool fullscreen,
			NameValuePairList list);

		[Method(Implemented = true)]
		void LoadPlugin([MarshalAs(UnmanagedType.LPStr)] string plugin);

		[Method(Implemented = true)]
		void UnloadPlugin([MarshalAs(UnmanagedType.LPStr)] string plugin);

		[Method(Implemented = true)]
		bool RenderOneFrame([MarshalAs(UnmanagedType.I1)] bool clearWindowMessages);

		[Method(Implemented = true)]
		void CheckWindowMessages();

		[Method(Implemented = true)]
		void StartRendering();

		[Method(Implemented = true)]
		void AddFrameListener(IFrameListener listener);

		[Method(Implemented = true)]
		void RemoveFrameListener(IFrameListener listener);
	}
}
using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreInterface("Root")]
	public interface IRoot : ICppInterface, ISingleton<IRoot>
	{
		[Constructor]
		IRoot Construct();

		[Constructor]
		IRoot Construct(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename);

		[Constructor]
		IRoot Construct(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename);

		[Constructor]
		IRoot Construct(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename,
			[MarshalAs(UnmanagedType.LPStr)] string logFilename);

		[Destructor]
		void Destruct();

		[Method]
		void SaveConfig();

		[Method]
		[return: MarshalAs(UnmanagedType.I1)]
		bool RestoreConfig();

		[Method]
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

		[Method]
		IRenderWindow Initialize(
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow);

		[Method]
		IRenderWindow Initialize(
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string windowTitle);

		[Method]
		IRenderWindow Initialize(
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string windowTitle,
			[MarshalAs(UnmanagedType.LPStr)] string customCapabilities);

		[Method]
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

		[Method]
		ISceneManager CreateSceneManager(SceneType sceneType);

		[Method]
		ISceneManager CreateSceneManager(SceneType sceneType, [MarshalAs(UnmanagedType.LPStr)] string instanceName);

		[Method]
		IRenderWindow CreateRenderWindow(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			uint width, uint height,
			[MarshalAs(UnmanagedType.I1)] bool fullscreen);

		[Method]
		IRenderWindow CreateRenderWindow(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			uint width, uint height,
			[MarshalAs(UnmanagedType.I1)] bool fullscreen,
			NameValuePairList list);

		[Method]
		void LoadPlugin([MarshalAs(UnmanagedType.LPStr)] string plugin);

		[Method]
		void UnloadPlugin([MarshalAs(UnmanagedType.LPStr)] string plugin);

		[Method]
		bool RenderOneFrame([MarshalAs(UnmanagedType.I1)] bool clearWindowMessages);

		[Method]
		void CheckWindowMessages();
	}
}
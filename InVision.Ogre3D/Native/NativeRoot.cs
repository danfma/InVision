using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeRoot : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "RootNew")]
		public static extern IntPtr New(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename);

		[DllImport(Library, EntryPoint = "RootNewWithLog")]
		public static extern IntPtr NewWithLog(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename,
			[MarshalAs(UnmanagedType.LPStr)] string logFilename);

		[DllImport(Library, EntryPoint = "RootDelete")]
		public static extern void Delete(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "RootSaveConfig")]
		public static extern void SaveConfig(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "RootRestoreConfig")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RestoreConfig(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "RootShowConfigDialog")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowConfigDialog(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "RootInitialise")]
		public static extern IntPtr Initialise(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.Bool)] bool autoCreateWindow);

		[DllImport(Library, EntryPoint = "RootInitialiseWithTitle")]
		public static extern IntPtr InitialiseWithTitle(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.Bool)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string winTitle);

		[DllImport(Library, EntryPoint = "RootInitialiseWithTitleAndCap")]
		public static extern IntPtr InitialiseWithTitleAndCap(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.Bool)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string winTitle,
			[MarshalAs(UnmanagedType.LPStr)] string capabilitiesConfig);

		[DllImport(Library, EntryPoint = "RootStartRendering")]
		public static extern void StartRendering(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "RootAddFrameListener")]
		public static extern void AddFrameListener(IntPtr pRoot, IntPtr listener);

		[DllImport(Library, EntryPoint = "RootRemoveFrameListener")]
		public static extern void RemoveFrameListener(IntPtr pRoot, IntPtr listener);

		[DllImport(Library, EntryPoint = "RootLoadPlugin")]
		public static extern void LoadPlugin(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string pluginName);

		[DllImport(Library, EntryPoint = "RootUnloadPlugin")]
		public static extern void UnloadPlugin(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string pluginName);

		[DllImport(Library, EntryPoint = "RootGetAvailableRenderers")]
		public static extern IntPtr _GetAvailableRenderers(IntPtr pRoot);

		/// <summary>
		/// 	Gets the available renderers.
		/// </summary>
		/// <param name = "pRoot">The p root.</param>
		/// <returns></returns>
		public static IEnumerable<RenderSystem> GetAvailableRenderers(IntPtr pRoot)
		{
			return _GetAvailableRenderers(pRoot).
				AsEnumeration(pRenderSystem => new RenderSystem(pRenderSystem, false));
		}

		[DllImport(Library, EntryPoint = "RootGetRenderSystemByName")]
		public static extern IntPtr _GetRenderSystemByName(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// 	Gets the name of the render system by.
		/// </summary>
		/// <param name = "pRoot">The p root.</param>
		/// <param name = "name">The name.</param>
		/// <returns></returns>
		public static RenderSystem GetRenderSystemByName(IntPtr pRoot, string name)
		{
			return _GetRenderSystemByName(pRoot, name).
				AsHandle(pRenderSystem => new RenderSystem(pRenderSystem, false));
		}

		[DllImport(Library, EntryPoint = "RootSetRenderSystem")]
		public static extern void SetRenderSystem(IntPtr pRoot, IntPtr renderSystem);

		[DllImport(Library, EntryPoint = "RootGetRenderSystem")]
		public static extern IntPtr _GetRenderSystem(IntPtr pRoot);

		public static RenderSystem GetRenderSystem(IntPtr pRoot)
		{
			return _GetRenderSystem(pRoot).
				AsHandle(pRenderSystem => new RenderSystem(pRenderSystem, false));
		}

		[DllImport(Library, EntryPoint = "RootCreateRenderWindow")]
		public static extern IntPtr CreateRenderWindow(IntPtr pRoot, string windowName, int width, int height, bool fullscreen);

		[DllImport(Library, EntryPoint = "RootCreateRenderWindow2")]
		public static extern IntPtr CreateRenderWindow(IntPtr pRoot, string windowName, int width, int height, bool fullscreen,
													   IntPtr pairListConfig);

		[DllImport(Library, EntryPoint = "RootCreateSceneManagerByType")]
		public static extern IntPtr CreateSceneManagerByType(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.U4)] SceneType type);

		[DllImport(Library, EntryPoint = "RootCreateSceneManagerByType2")]
		public static extern IntPtr CreateSceneManagerByType(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.U4)] SceneType type,
			[MarshalAs(UnmanagedType.LPStr)] string instanceName);


		[DllImport(Library, EntryPoint = "RootCreateSceneManagerByTypeName")]
		public static extern IntPtr CreateSceneManagerByTypeName(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string typeName);

		[DllImport(Library, EntryPoint = "RootCreateSceneManagerByTypeName2")]
		public static extern IntPtr CreateSceneManagerByTypeName(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string typeName,
			[MarshalAs(UnmanagedType.LPStr)] string instanceName);
	}
}
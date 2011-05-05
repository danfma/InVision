using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	internal sealed class NativeOgreRoot : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "root_new")]
		public static extern IntPtr New(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename);

		[DllImport(Library, EntryPoint = "root_new_with_log")]
		public static extern IntPtr NewWithLog(
			[MarshalAs(UnmanagedType.LPStr)] string pluginFilename,
			[MarshalAs(UnmanagedType.LPStr)] string configFilename,
			[MarshalAs(UnmanagedType.LPStr)] string logFilename);

		[DllImport(Library, EntryPoint = "root_delete")]
		public static extern void Delete(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "root_save_config")]
		public static extern void SaveConfig(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "root_restore_config")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RestoreConfig(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "root_show_config_dialog")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowConfigDialog(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "root_initialise")]
		public static extern IntPtr Initialise(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.Bool)] bool autoCreateWindow);

		[DllImport(Library, EntryPoint = "root_initialise_with_title")]
		public static extern IntPtr InitialiseWithTitle(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.Bool)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string winTitle);

		[DllImport(Library, EntryPoint = "root_initialise_with_title_and_cap")]
		public static extern IntPtr InitialiseWithTitleAndCap(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.Bool)] bool autoCreateWindow,
			[MarshalAs(UnmanagedType.LPStr)] string winTitle,
			[MarshalAs(UnmanagedType.LPStr)] string capabilitiesConfig);

		[DllImport(Library, EntryPoint = "root_start_rendering")]
		public static extern void StartRendering(IntPtr pRoot);

		[DllImport(Library, EntryPoint = "root_add_framelistener")]
		public static extern void AddFrameListener(IntPtr pRoot, IntPtr listener);

		[DllImport(Library, EntryPoint = "root_remove_framelistener")]
		public static extern void RemoveFrameListener(IntPtr pRoot, IntPtr listener);

		[DllImport(Library, EntryPoint = "root_load_plugin")]
		public static extern void LoadPlugin(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string pluginName);

		[DllImport(Library, EntryPoint = "root_unload_plugin")]
		public static extern void UnloadPlugin(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string pluginName);

		[DllImport(Library, EntryPoint = "root_get_available_renderers")]
		public static extern IntPtr _GetAvailableRenderers(IntPtr pRoot);

		/// <summary>
		/// 	Gets the available renderers.
		/// </summary>
		/// <param name = "pRoot">The p root.</param>
		/// <returns></returns>
		public static IEnumerable<RenderSystem> GetAvailableRenderers(IntPtr pRoot)
		{
			return _GetAvailableRenderers(pRoot).
				AsEnumeration(pRenderSystem => new RenderSystem(pRenderSystem, false)).
				Select(p => p.Value);
		}

		[DllImport(Library, EntryPoint = "root_get_rendersystem_by_name")]
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

		[DllImport(Library, EntryPoint = "root_set_rendersystem")]
		public static extern void SetRenderSystem(IntPtr pRoot, IntPtr renderSystem);

		[DllImport(Library, EntryPoint = "root_get_rendersystem")]
		public static extern IntPtr _GetRenderSystem(IntPtr pRoot);

		public static RenderSystem GetRenderSystem(IntPtr pRoot)
		{
			return _GetRenderSystem(pRoot).
				AsHandle(pRenderSystem => new RenderSystem(pRenderSystem, false));
		}

		[DllImport(Library, EntryPoint = "root_create_renderwindow")]
		public static extern IntPtr CreateRenderWindow(IntPtr pRoot, string windowName, int width, int height, bool fullscreen);

		[DllImport(Library, EntryPoint = "root_create_renderwindow_with_params")]
		public static extern IntPtr CreateRenderWindow(IntPtr pRoot, string windowName, int width, int height, bool fullscreen,
													   IntPtr pairListConfig);

		[DllImport(Library, EntryPoint = "root_create_scenemanager_by_type")]
		public static extern IntPtr CreateSceneManagerByType(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.U4)] SceneType type);

		[DllImport(Library, EntryPoint = "root_create_scenemanager_by_type2")]
		public static extern IntPtr CreateSceneManagerByType(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.U4)] SceneType type,
			[MarshalAs(UnmanagedType.LPStr)] string instanceName);


		[DllImport(Library, EntryPoint = "root_create_scenemanager_by_typename")]
		public static extern IntPtr CreateSceneManagerByTypeName(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string typeName);

		[DllImport(Library, EntryPoint = "root_create_scenemanager_by_typename2")]
		public static extern IntPtr CreateSceneManagerByTypeName(
			IntPtr pRoot,
			[MarshalAs(UnmanagedType.LPStr)] string typeName,
			[MarshalAs(UnmanagedType.LPStr)] string instanceName);
	}
}
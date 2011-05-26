/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Native;
using InVision.Ogre;
using InVision.Ogre.Native;

namespace InVision.Ogre.Native
{
	internal sealed class NativeRenderSystemCapabilities : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRenderSystemCapabilities()
		{
			Init();
		}
		
	}
	
	internal sealed class NativeLog : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeLog()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "log_add_listener")]
		public static extern void AddListener(
			Handle self, 
			Handle listener);
		
		[DllImport(Library, EntryPoint = "log_remove_listener")]
		public static extern void RemoveListener(
			Handle self, 
			Handle listener);
		
		[DllImport(Library, EntryPoint = "log_get_name")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String GetName(Handle self);
		
		[DllImport(Library, EntryPoint = "log_is_debug_output_enabled")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool IsDebugOutputEnabled(Handle self);
		
		[DllImport(Library, EntryPoint = "log_is_file_output_suppressed")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool IsFileOutputSuppressed(Handle self);
		
		[DllImport(Library, EntryPoint = "log_is_time_stamp_enabled")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool IsTimeStampEnabled(Handle self);
		
		[DllImport(Library, EntryPoint = "log_log_message")]
		public static extern void LogMessage(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String message, 
			LogMessageLevel level, 
			[MarshalAs(UnmanagedType.I1)] bool maskDebug);
	}
	
	internal sealed class NativeRoot : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRoot()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "root_check_window_messages")]
		public static extern void CheckWindowMessages(Handle self);
		
		[DllImport(Library, EntryPoint = "new_root_m1")]
		public static extern Handle Construct();
		
		[DllImport(Library, EntryPoint = "new_root_m2")]
		public static extern Handle Construct([MarshalAs(UnmanagedType.LPStr)] String pluginFilename);
		
		[DllImport(Library, EntryPoint = "new_root_m3")]
		public static extern Handle Construct(
			[MarshalAs(UnmanagedType.LPStr)] String pluginFilename, 
			[MarshalAs(UnmanagedType.LPStr)] String configFilename);
		
		[DllImport(Library, EntryPoint = "new_root_m4")]
		public static extern Handle Construct(
			[MarshalAs(UnmanagedType.LPStr)] String pluginFilename, 
			[MarshalAs(UnmanagedType.LPStr)] String configFilename, 
			[MarshalAs(UnmanagedType.LPStr)] String logFilename);
		
		[DllImport(Library, EntryPoint = "delete_root")]
		public static extern void Destruct(Handle self);
		
		[DllImport(Library, EntryPoint = "root_save_config")]
		public static extern void SaveConfig(Handle self);
		
		[DllImport(Library, EntryPoint = "root_restore_config")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool RestoreConfig(Handle self);
		
		[DllImport(Library, EntryPoint = "root_show_config_dialog")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ShowConfigDialog(Handle self);
		
		[DllImport(Library, EntryPoint = "root_add_render_system")]
		public static extern void AddRenderSystem(
			Handle self, 
			Handle renderSystem);
		
		[DllImport(Library, EntryPoint = "root_get_render_system_by_name")]
		public static extern IntPtr GetRenderSystemByName(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
		
		[DllImport(Library, EntryPoint = "root_set_render_system")]
		public static extern void SetRenderSystem(
			Handle self, 
			Handle renderSystem);
		
		[DllImport(Library, EntryPoint = "root_get_render_system")]
		public static extern Handle GetRenderSystem(Handle self);
		
		[DllImport(Library, EntryPoint = "root_initialize_m1")]
		public static extern Handle Initialize(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow);
		
		[DllImport(Library, EntryPoint = "root_initialize_m2")]
		public static extern Handle Initialize(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow, 
			[MarshalAs(UnmanagedType.LPStr)] String windowTitle);
		
		[DllImport(Library, EntryPoint = "root_initialize_m3")]
		public static extern Handle Initialize(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] bool autoCreateWindow, 
			[MarshalAs(UnmanagedType.LPStr)] String windowTitle, 
			[MarshalAs(UnmanagedType.LPStr)] String customCapabilities);
		
		[DllImport(Library, EntryPoint = "root_is_initialized")]
		public static extern bool IsInitialized(Handle self);
		
		[DllImport(Library, EntryPoint = "root_use_custom_render_system_capabilities")]
		public static extern void UseCustomRenderSystemCapabilities(
			Handle self, 
			Handle capabilities);
		
		[DllImport(Library, EntryPoint = "root_get_remove_render_queue_structures_on_clear")]
		public static extern bool GetRemoveRenderQueueStructuresOnClear(Handle self);
		
		[DllImport(Library, EntryPoint = "root_set_remove_render_queue_structures_on_clear")]
		public static extern void SetRemoveRenderQueueStructuresOnClear(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] bool value);
		
		[DllImport(Library, EntryPoint = "root_add_scene_manager_factory")]
		public static extern void AddSceneManagerFactory(
			Handle self, 
			Handle factory);
		
		[DllImport(Library, EntryPoint = "root_remove_scene_manager_factory")]
		public static extern void RemoveSceneManagerFactory(
			Handle self, 
			Handle factory);
		
		[DllImport(Library, EntryPoint = "root_create_scene_manager_m1")]
		public static extern Handle CreateSceneManager(
			Handle self, 
			SceneType sceneType);
		
		[DllImport(Library, EntryPoint = "root_create_scene_manager_m2")]
		public static extern Handle CreateSceneManager(
			Handle self, 
			SceneType sceneType, 
			[MarshalAs(UnmanagedType.LPStr)] String instanceName);
		
		[DllImport(Library, EntryPoint = "root_create_render_window_m1")]
		public static extern Handle CreateRenderWindow(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			uint width, 
			uint height, 
			[MarshalAs(UnmanagedType.I1)] bool fullscreen);
		
		[DllImport(Library, EntryPoint = "root_create_render_window_m2")]
		public static extern Handle CreateRenderWindow(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			uint width, 
			uint height, 
			[MarshalAs(UnmanagedType.I1)] bool fullscreen, 
			NameValuePairList list);
		
		[DllImport(Library, EntryPoint = "root_load_plugin")]
		public static extern void LoadPlugin(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String plugin);
		
		[DllImport(Library, EntryPoint = "root_unload_plugin")]
		public static extern void UnloadPlugin(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String plugin);
		
		[DllImport(Library, EntryPoint = "root_render_one_frame")]
		public static extern bool RenderOneFrame(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] bool clearWindowMessages);
		
		[DllImport(Library, EntryPoint = "root_get_singleton")]
		public static extern Handle GetSingleton();
	}
	
	internal sealed class NativeCamera : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeCamera()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "camera_set_position")]
		public static extern void SetPosition(
			Handle self, 
			Vector3 pos);
		
		[DllImport(Library, EntryPoint = "camera_look_at")]
		public static extern void LookAt(
			Handle self, 
			Vector3 direction);
		
		[DllImport(Library, EntryPoint = "camera_set_near_clip_distance")]
		public static extern void SetNearClipDistance(
			Handle self, 
			float distance);
		
		[DllImport(Library, EntryPoint = "camera_set_aspect_ratio")]
		public static extern void SetAspectRatio(
			Handle self, 
			float aspectRatio);
	}
	
	internal sealed class NativeSceneManagerFactory : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeSceneManagerFactory()
		{
			Init();
		}
		
	}
	
	internal sealed class NativeRenderSystem : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRenderSystem()
		{
			Init();
		}
		
	}
	
	internal sealed class NativeLogManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeLogManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_logmanager")]
		public static extern Handle Construct();
		
		[DllImport(Library, EntryPoint = "delete_logmanager")]
		public static extern void Destruct(Handle self);
		
		[DllImport(Library, EntryPoint = "logmanager_create_log")]
		public static extern Handle CreateLog(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			[MarshalAs(UnmanagedType.I1)] bool defaultLog, 
			[MarshalAs(UnmanagedType.I1)] bool debuggerOutput, 
			[MarshalAs(UnmanagedType.I1)] bool suppressFileOutput);
		
		[DllImport(Library, EntryPoint = "logmanager_get_log")]
		public static extern Handle GetLog(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
		
		[DllImport(Library, EntryPoint = "logmanager_get_default_log")]
		public static extern Handle GetDefaultLog(Handle self);
		
		[DllImport(Library, EntryPoint = "logmanager_destroy_log_m1")]
		public static extern void DestroyLog(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
		
		[DllImport(Library, EntryPoint = "logmanager_destroy_log_m2")]
		public static extern void DestroyLog(
			Handle self, 
			Handle log);
		
		[DllImport(Library, EntryPoint = "logmanager_set_default_log")]
		public static extern Handle SetDefaultLog(
			Handle self, 
			Handle log);
		
		[DllImport(Library, EntryPoint = "logmanager_log_message")]
		public static extern void LogMessage(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String message, 
			LogMessageLevel logLevel, 
			[MarshalAs(UnmanagedType.I1)] bool maskDebug);
		
		[DllImport(Library, EntryPoint = "logmanager_set_log_detail")]
		public static extern void SetLogDetail(
			Handle self, 
			LoggingLevel level);
		
		[DllImport(Library, EntryPoint = "logmanager_get_singleton")]
		public static extern Handle GetSingleton();
	}
	
	internal sealed class NativeCustomLogListener : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeCustomLogListener()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_customloglistener")]
		public static extern Handle Construct(LogListenerMessageLoggedHandler messageLoggedHandler);
		
		[DllImport(Library, EntryPoint = "delete_customloglistener")]
		public static extern void Destruct(Handle self);
	}
	
	internal sealed class NativeViewport : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeViewport()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "viewport_set_background_color")]
		public static extern void SetBackgroundColor(
			Handle self, 
			Color color);
	}
	
	internal sealed class NativeSceneManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeSceneManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "scenemanager_clear_scene")]
		public static extern void ClearScene(Handle self);
		
		[DllImport(Library, EntryPoint = "scenemanager_set_ambient_light")]
		public static extern void SetAmbientLight(
			Handle self, 
			Color color);
		
		[DllImport(Library, EntryPoint = "scenemanager_get_ambient_light")]
		public static extern Color GetAmbientLight(Handle self);
		
		[DllImport(Library, EntryPoint = "scenemanager_create_camera")]
		public static extern Handle CreateCamera(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
	}
	
	internal sealed class NativeRenderWindow : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRenderWindow()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "renderwindow_get_custom_attribute")]
		public static extern void GetCustomAttribute(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			out IntPtr data);
		
		[DllImport(Library, EntryPoint = "renderwindow_add_viewport")]
		public static extern Handle AddViewport(
			Handle self, 
			Handle camera, 
			int zOrder, 
			float left, 
			float top, 
			float width, 
			float height);
		
		[DllImport(Library, EntryPoint = "renderwindow_is_closed")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool IsClosed(Handle self);
	}
	
}

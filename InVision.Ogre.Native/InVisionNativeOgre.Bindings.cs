/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Native;
using InVision.Ogre;
using InVision.Ogre.Listeners;
using InVision.Ogre.Native;

namespace InVision.Ogre.Native
{
	internal sealed unsafe class NativeStringInterface : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeStringInterface()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeRenderable : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRenderable()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeOverlayElement : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeOverlayElement()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "overlayelement_get_caption")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern String GetCaption(Handle self);
		
		[DllImport(Library, EntryPoint = "overlayelement_set_caption")]
		public static extern void SetCaption(
			Handle self, 
			[MarshalAs(UnmanagedType.LPWStr)] String value);
		
		[DllImport(Library, EntryPoint = "overlayelement_show")]
		public static extern void Show(Handle self);
	}
	
	internal sealed unsafe class NativeOverlay : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeOverlay()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "overlay_show")]
		public static extern void Show(Handle self);
	}
	
	internal sealed unsafe class NativeAnimableObject : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeAnimableObject()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeShadowCaster : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeShadowCaster()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "shadowcaster_get_cast_shadows")]
		public static extern bool GetCastShadows(Handle self);
		
		[DllImport(Library, EntryPoint = "shadowcaster_get_edge_list")]
		public static extern Handle GetEdgeList(Handle self);
		
		[DllImport(Library, EntryPoint = "shadowcaster_has_edge_list")]
		public static extern bool HasEdgeList(Handle self);
		
		[DllImport(Library, EntryPoint = "shadowcaster_get_world_bounding_box")]
		public static extern BoundingBox GetWorldBoundingBox(
			Handle self, 
			bool derive);
		
		[DllImport(Library, EntryPoint = "shadowcaster_get_light_cap_bounds")]
		public static extern BoundingBox GetLightCapBounds(Handle self);
		
		[DllImport(Library, EntryPoint = "shadowcaster_get_dark_cap_bounds")]
		public static extern BoundingBox GetDarkCapBounds(
			Handle self, 
			Handle light, 
			float dirLightExtrusionDist);
		
		[DllImport(Library, EntryPoint = "shadowcaster_get_point_extrusion_distance")]
		public static extern float GetPointExtrusionDistance(
			Handle self, 
			Handle light);
	}
	
	internal sealed unsafe class NativeMovableObject : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeMovableObject()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "movableobject_get_cast_shadows")]
		public static extern bool GetCastShadows(Handle self);
		
		[DllImport(Library, EntryPoint = "movableobject_get_edge_list")]
		public static extern Handle GetEdgeList(Handle self);
		
		[DllImport(Library, EntryPoint = "movableobject_has_edge_list")]
		public static extern bool HasEdgeList(Handle self);
		
		[DllImport(Library, EntryPoint = "movableobject_get_world_bounding_box")]
		public static extern BoundingBox GetWorldBoundingBox(
			Handle self, 
			bool derive);
		
		[DllImport(Library, EntryPoint = "movableobject_get_light_cap_bounds")]
		public static extern BoundingBox GetLightCapBounds(Handle self);
		
		[DllImport(Library, EntryPoint = "movableobject_get_dark_cap_bounds")]
		public static extern BoundingBox GetDarkCapBounds(
			Handle self, 
			Handle light, 
			float dirLightExtrusionDist);
		
		[DllImport(Library, EntryPoint = "movableobject_get_point_extrusion_distance")]
		public static extern float GetPointExtrusionDistance(
			Handle self, 
			Handle light);
	}
	
	internal sealed unsafe class NativeFrameListener : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeFrameListener()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "delete_framelistener")]
		public static extern void Destruct(Handle self);
		
		[DllImport(Library, EntryPoint = "framelistener_frame_started")]
		public static extern bool FrameStarted(
			Handle self, 
			FrameEvent frameEvent);
		
		[DllImport(Library, EntryPoint = "framelistener_frame_rendering_queued")]
		public static extern bool FrameRenderingQueued(
			Handle self, 
			FrameEvent frameEvent);
		
		[DllImport(Library, EntryPoint = "framelistener_frame_ended")]
		public static extern bool FrameEnded(
			Handle self, 
			FrameEvent frameEvent);
	}
	
	internal sealed unsafe class NativeRenderSystemCapabilities : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRenderSystemCapabilities()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeLog : InVision.Native.PlatformInvoke
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
	
	internal sealed unsafe class NativeResourceGroupManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeResourceGroupManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "resourcegroupmanager_add_resource_location_m1")]
		public static extern void AddResourceLocation(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			[MarshalAs(UnmanagedType.LPStr)] String locType);
		
		[DllImport(Library, EntryPoint = "resourcegroupmanager_add_resource_location_m2")]
		public static extern void AddResourceLocation(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			[MarshalAs(UnmanagedType.LPStr)] String locType, 
			[MarshalAs(UnmanagedType.LPStr)] String resGroup);
		
		[DllImport(Library, EntryPoint = "resourcegroupmanager_add_resource_location_m3")]
		public static extern void AddResourceLocation(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			[MarshalAs(UnmanagedType.LPStr)] String locType, 
			[MarshalAs(UnmanagedType.LPStr)] String resGroup, 
			[MarshalAs(UnmanagedType.I1)] bool recursive);
		
		[DllImport(Library, EntryPoint = "resourcegroupmanager_initialize_all_resource_groups")]
		public static extern void InitializeAllResourceGroups(Handle self);
		
		[DllImport(Library, EntryPoint = "resourcegroupmanager_get_singleton")]
		public static extern Handle GetSingleton();
	}
	
	internal sealed unsafe class NativeRenderTarget : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRenderTarget()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeFrustum : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeFrustum()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeRoot : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRoot()
		{
			Init();
		}
		
		
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
		
		[DllImport(Library, EntryPoint = "root_check_window_messages")]
		public static extern void CheckWindowMessages(Handle self);
		
		[DllImport(Library, EntryPoint = "root_start_rendering")]
		public static extern void StartRendering(Handle self);
		
		[DllImport(Library, EntryPoint = "root_add_frame_listener")]
		public static extern void AddFrameListener(
			Handle self, 
			Handle listener);
		
		[DllImport(Library, EntryPoint = "root_remove_frame_listener")]
		public static extern void RemoveFrameListener(
			Handle self, 
			Handle listener);
		
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
	
	internal sealed unsafe class NativeNode : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeNode()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeCustomFrameListener : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeCustomFrameListener()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_customframelistener")]
		public static extern Handle Construct(
			FrameEventHandler frameStarted, 
			FrameEventHandler frameEnded, 
			FrameEventHandler frameRenderingQueued);
	}
	
	internal sealed unsafe class NativeAxisAlignedBox : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeAxisAlignedBox()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeCamera : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeCamera()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "camera_get_position")]
		public static extern Vector3 GetPosition(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_set_position")]
		public static extern void SetPosition(
			Handle self, 
			Vector3 pos);
		
		[DllImport(Library, EntryPoint = "camera_look_at")]
		public static extern void LookAt(
			Handle self, 
			Vector3 direction);
		
		[DllImport(Library, EntryPoint = "camera_get_near_clip_distance")]
		public static extern float GetNearClipDistance(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_set_near_clip_distance")]
		public static extern void SetNearClipDistance(
			Handle self, 
			float distance);
		
		[DllImport(Library, EntryPoint = "camera_get_aspect_ratio")]
		public static extern float GetAspectRatio(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_set_aspect_ratio")]
		public static extern void SetAspectRatio(
			Handle self, 
			float aspectRatio);
		
		[DllImport(Library, EntryPoint = "camera_get_far_clip_distance")]
		public static extern float GetFarClipDistance(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_set_far_clip_distance")]
		public static extern void SetFarClipDistance(
			Handle self, 
			float value);
		
		[DllImport(Library, EntryPoint = "camera_set_auto_aspect_ratio")]
		public static extern void SetAutoAspectRatio(
			Handle self, 
			bool value);
		
		[DllImport(Library, EntryPoint = "camera_get_polygon_mode")]
		public static extern PolygonMode GetPolygonMode(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_set_polygon_mode")]
		public static extern void SetPolygonMode(
			Handle self, 
			PolygonMode value);
		
		[DllImport(Library, EntryPoint = "camera_get_direction")]
		public static extern Vector3 GetDirection(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_get_right")]
		public static extern Vector3 GetRight(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_get_up")]
		public static extern Vector3 GetUp(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_move")]
		public static extern void Move(
			Handle self, 
			Vector3 distance);
		
		[DllImport(Library, EntryPoint = "camera_yaw")]
		public static extern void Yaw(
			Handle self, 
			float valueRadians);
		
		[DllImport(Library, EntryPoint = "camera_pitch")]
		public static extern void Pitch(
			Handle self, 
			float valueRadians);
		
		[DllImport(Library, EntryPoint = "camera_get_cast_shadows")]
		public static extern bool GetCastShadows(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_get_edge_list")]
		public static extern Handle GetEdgeList(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_has_edge_list")]
		public static extern bool HasEdgeList(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_get_world_bounding_box")]
		public static extern BoundingBox GetWorldBoundingBox(
			Handle self, 
			bool derive);
		
		[DllImport(Library, EntryPoint = "camera_get_light_cap_bounds")]
		public static extern BoundingBox GetLightCapBounds(Handle self);
		
		[DllImport(Library, EntryPoint = "camera_get_dark_cap_bounds")]
		public static extern BoundingBox GetDarkCapBounds(
			Handle self, 
			Handle light, 
			float dirLightExtrusionDist);
		
		[DllImport(Library, EntryPoint = "camera_get_point_extrusion_distance")]
		public static extern float GetPointExtrusionDistance(
			Handle self, 
			Handle light);
	}
	
	internal sealed unsafe class NativeScriptLoader : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeScriptLoader()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeEntity : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeEntity()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeConfigFile : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeConfigFile()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_configfile")]
		public static extern Handle Construct();
		
		[DllImport(Library, EntryPoint = "delete_configfile")]
		public static extern void Destruct(Handle self);
		
		[DllImport(Library, EntryPoint = "configfile_load")]
		public static extern void Load(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String filename, 
			[MarshalAs(UnmanagedType.LPStr)] String separators, 
			[MarshalAs(UnmanagedType.I1)] bool trimWhitespace);
		
		[DllImport(Library, EntryPoint = "configfile_get_sections")]
		public static extern void GetSections(
			Handle self, 
			out SettingsBySection* settingsBySection);
		
		[DllImport(Library, EntryPoint = "configfile_delete_settings_by_section")]
		public static extern void DeleteSettingsBySection(SettingsBySection* settingsBySection);
	}
	
	internal sealed unsafe class NativeResourceManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeResourceManager()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeMaterialManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeMaterialManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "materialmanager_set_default_texture_filtering")]
		public static extern void SetDefaultTextureFiltering(
			Handle self, 
			TextureFilterOption option);
		
		[DllImport(Library, EntryPoint = "materialmanager_set_default_anisotropy")]
		public static extern void SetDefaultAnisotropy(
			Handle self, 
			uint max);
		
		[DllImport(Library, EntryPoint = "materialmanager_get_default_anisotropy")]
		public static extern uint GetDefaultAnisotropy(Handle self);
		
		[DllImport(Library, EntryPoint = "materialmanager_get_singleton")]
		public static extern Handle GetSingleton();
	}
	
	internal sealed unsafe class NativeLogListener : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeLogListener()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "delete_loglistener")]
		public static extern void Destruct(Handle self);
	}
	
	internal sealed unsafe class NativeEdgeData : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeEdgeData()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeSceneManagerFactory : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeSceneManagerFactory()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeRenderSystem : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeRenderSystem()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeSceneNode : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeSceneNode()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "scenenode_attach_object")]
		public static extern void AttachObject(
			Handle self, 
			Handle obj);
		
		[DllImport(Library, EntryPoint = "scenenode_num_attached_objects")]
		public static extern ushort NumAttachedObjects(Handle self);
		
		[DllImport(Library, EntryPoint = "scenenode_get_attached_object_m1")]
		public static extern Handle GetAttachedObject(
			Handle self, 
			ushort index);
		
		[DllImport(Library, EntryPoint = "scenenode_get_attached_object_m2")]
		public static extern Handle GetAttachedObject(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
		
		[DllImport(Library, EntryPoint = "scenenode_detach_object_m1")]
		public static extern Handle DetachObject(
			Handle self, 
			ushort index);
		
		[DllImport(Library, EntryPoint = "scenenode_detach_object_m2")]
		public static extern void DetachObject(
			Handle self, 
			Handle movableObject);
		
		[DllImport(Library, EntryPoint = "scenenode_detach_object_m3")]
		public static extern Handle DetachObject(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
		
		[DllImport(Library, EntryPoint = "scenenode_detach_all_objects")]
		public static extern void DetachAllObjects(Handle self);
		
		[DllImport(Library, EntryPoint = "scenenode_create_child_scene_node_m1")]
		public static extern Handle CreateChildSceneNode(Handle self);
		
		[DllImport(Library, EntryPoint = "scenenode_create_child_scene_node_m2")]
		public static extern Handle CreateChildSceneNode(
			Handle self, 
			Vector3 translate);
		
		[DllImport(Library, EntryPoint = "scenenode_create_child_scene_node_m3")]
		public static extern Handle CreateChildSceneNode(
			Handle self, 
			Vector3 translate, 
			Quaternion rotate);
		
		[DllImport(Library, EntryPoint = "scenenode_create_child_scene_node_m4")]
		public static extern Handle CreateChildSceneNode(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
		
		[DllImport(Library, EntryPoint = "scenenode_create_child_scene_node_m5")]
		public static extern Handle CreateChildSceneNode(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			Vector3 translate);
		
		[DllImport(Library, EntryPoint = "scenenode_create_child_scene_node_m6")]
		public static extern Handle CreateChildSceneNode(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			Vector3 translate, 
			Quaternion rotate);
	}
	
	internal sealed unsafe class NativeOverlayManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeOverlayManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "overlaymanager_get_overlay_element")]
		public static extern Handle GetOverlayElement(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name, 
			[MarshalAs(UnmanagedType.I1)] bool isTemplate);
		
		[DllImport(Library, EntryPoint = "overlaymanager_get_by_name")]
		public static extern Handle GetByName(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
		
		[DllImport(Library, EntryPoint = "overlaymanager_get_singleton")]
		public static extern Handle GetSingleton();
	}
	
	internal sealed unsafe class NativeLogManager : InVision.Native.PlatformInvoke
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
	
	internal sealed unsafe class NativeLight : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeLight()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "light_set_position_m1")]
		public static extern void SetPosition(
			Handle self, 
			float x, 
			float y, 
			float z);
		
		[DllImport(Library, EntryPoint = "light_set_position_m2")]
		public static extern void SetPosition(
			Handle self, 
			Vector3 pos);
		
		[DllImport(Library, EntryPoint = "light_get_position")]
		public static extern Vector3 GetPosition(Handle self);
	}
	
	internal sealed unsafe class NativeCustomLogListener : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeCustomLogListener()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_customloglistener")]
		public static extern Handle Construct(LogListenerMessageLoggedHandler messageLoggedHandler);
	}
	
	internal sealed unsafe class NativeViewport : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeViewport()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_viewport")]
		public static extern Handle Construct(
			Handle camera, 
			Handle renderTarget, 
			float left, 
			float top, 
			float width, 
			float height, 
			int zOrder);
		
		[DllImport(Library, EntryPoint = "delete_viewport")]
		public static extern void Destruct(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_set_background_color")]
		public static extern void SetBackgroundColor(
			Handle self, 
			Color color);
		
		[DllImport(Library, EntryPoint = "viewport_get_background_color")]
		public static extern Color GetBackgroundColor(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_update")]
		public static extern void Update(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_clear")]
		public static extern void Clear(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_camera")]
		public static extern Handle GetCamera(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_set_camera")]
		public static extern void SetCamera(
			Handle self, 
			Handle camera);
		
		[DllImport(Library, EntryPoint = "viewport_get_left")]
		public static extern float GetLeft(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_top")]
		public static extern float GetTop(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_width")]
		public static extern float GetWidth(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_height")]
		public static extern float GetHeight(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_actual_left")]
		public static extern int GetActualLeft(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_actual_top")]
		public static extern int GetActualTop(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_actual_width")]
		public static extern int GetActualWidth(Handle self);
		
		[DllImport(Library, EntryPoint = "viewport_get_actual_height")]
		public static extern int GetActualHeight(Handle self);
	}
	
	internal sealed unsafe class NativeSceneManager : InVision.Native.PlatformInvoke
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
		
		[DllImport(Library, EntryPoint = "scenemanager_create_entity_m1")]
		public static extern Handle CreateEntity(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String meshName);
		
		[DllImport(Library, EntryPoint = "scenemanager_create_entity_m2")]
		public static extern Handle CreateEntity(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String entityName, 
			[MarshalAs(UnmanagedType.LPStr)] String meshName);
		
		[DllImport(Library, EntryPoint = "scenemanager_get_root_scene_node")]
		public static extern Handle GetRootSceneNode(Handle self);
		
		[DllImport(Library, EntryPoint = "scenemanager_create_light_m1")]
		public static extern Handle CreateLight(Handle self);
		
		[DllImport(Library, EntryPoint = "scenemanager_create_light_m2")]
		public static extern Handle CreateLight(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String name);
	}
	
	internal sealed unsafe class NativeRenderWindow : InVision.Native.PlatformInvoke
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
		
		[DllImport(Library, EntryPoint = "renderwindow_write_contents_to_timestamped_file")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String WriteContentsToTimestampedFile(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String filenamePrefix, 
			[MarshalAs(UnmanagedType.LPStr)] String filenameSuffix);
		
		[DllImport(Library, EntryPoint = "renderwindow_get_statistics")]
		public static extern FrameStats GetStatistics(Handle self);
	}
	
	internal sealed unsafe class NativeTextureManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeTextureManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "texturemanager_set_default_num_mipmaps")]
		public static extern void SetDefaultNumMipmaps(
			Handle self, 
			int num);
		
		[DllImport(Library, EntryPoint = "texturemanager_get_default_num_mipmaps")]
		public static extern int GetDefaultNumMipmaps(Handle self);
		
		[DllImport(Library, EntryPoint = "texturemanager_reload_all")]
		public static extern void ReloadAll(
			Handle self, 
			bool reloadableOnly);
		
		[DllImport(Library, EntryPoint = "texturemanager_get_singleton")]
		public static extern Handle GetSingleton();
	}
	
}

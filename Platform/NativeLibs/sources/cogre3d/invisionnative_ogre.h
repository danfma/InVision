#ifndef __INVISIONNATIVE_OGRE_H__
#define __INVISIONNATIVE_OGRE_H__

#include <InvisionHandle.h>
#include "invisionnative.h"

extern "C"
{
	/*
	 * Enumeration POLYGON_MODE
	 */
	#define POLYGON_MODE _int
	#define POLYGON_MODE_POINTS 0x1
	#define POLYGON_MODE_WIREFRAME 0x2
	#define POLYGON_MODE_SOLID 0x3
	
	/*
	 * Enumeration TEXTURE_FILTER_OPTION
	 */
	#define TEXTURE_FILTER_OPTION _int
	#define TEXTURE_FILTER_OPTION_NONE 0x0
	#define TEXTURE_FILTER_OPTION_BILINEAR 0x1
	#define TEXTURE_FILTER_OPTION_TRILINEAR 0x2
	#define TEXTURE_FILTER_OPTION_ANISOTROPIC 0x3
	
	/*
	 * Enumeration SCENE_TYPE
	 */
	#define SCENE_TYPE _int
	#define SCENE_TYPE_GENERIC 0x1
	#define SCENE_TYPE_EXTERIOR_CLOSE 0x2
	#define SCENE_TYPE_EXTERIOR_FAR 0x4
	#define SCENE_TYPE_EXTERIOR_REAL_FAR 0x8
	#define SCENE_TYPE_INTERIOR 0x10
	
	/*
	 * Enumeration LOG_MESSAGE_LEVEL
	 */
	#define LOG_MESSAGE_LEVEL _int
	#define LOG_MESSAGE_LEVEL_TRIVIAL 0x1
	#define LOG_MESSAGE_LEVEL_NORMAL 0x2
	#define LOG_MESSAGE_LEVEL_CRITICAL 0x3
	
	/*
	 * Enumeration LOGGING_LEVEL
	 */
	#define LOGGING_LEVEL _int
	#define LOGGING_LEVEL_LOW 0x1
	#define LOGGING_LEVEL_NORMAL 0x2
	#define LOGGING_LEVEL_BOREME 0x3
	
	
	/*
	 * Prototypes
	 */
	
	struct SettingsBySection;
	struct FrameStats;
	struct Setting;
	struct NameValuePairList;
	struct FrameEvent;
	struct NameValuePair;
	
	typedef _bool (INV_CALL *FrameEventHandler)(FrameEvent e);
	typedef void (INV_CALL *LogListenerMessageLoggedHandler)(_string message, LOG_MESSAGE_LEVEL level, _bool maskDebug, _string name);
	
	#include "invisionnative_ogre_settings_by_section.h"
	#include "invisionnative_ogre_frame_stats.h"
	#include "invisionnative_ogre_setting.h"
	#include "invisionnative_ogre_name_value_pair_list.h"
	#include "invisionnative_ogre_frame_event.h"
	#include "invisionnative_ogre_name_value_pair.h"
	
	
	/*
	 * Function group: InVision.Ogre.Native.IStringInterface
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderable
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IOverlayElement
	 */
	
	/**
	 * Method: OverlayElement::getCaption (OK)
	 */
	INV_EXPORT _wchar*
	INV_CALL overlayelement_get_caption(InvHandle self);
	
	/**
	 * Method: OverlayElement::setCaption (OK)
	 */
	INV_EXPORT void
	INV_CALL overlayelement_set_caption(InvHandle self, _wstring value);
	
	/**
	 * Method: OverlayElement::show (OK)
	 */
	INV_EXPORT void
	INV_CALL overlayelement_show(InvHandle self);
	
	/**
	 * Method: OverlayElement::deleteWideString (NOT IMPLEMENTED)
	 */
	INV_EXPORT void
	INV_CALL overlayelement_delete_wide_string(_wchar* pdata);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IOverlay
	 */
	
	/**
	 * Method: Overlay::show (OK)
	 */
	INV_EXPORT void
	INV_CALL overlay_show(InvHandle self);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IAnimableObject
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IShadowCaster
	 */
	
	/**
	 * Method: ShadowCaster::getCastShadows (OK)
	 */
	INV_EXPORT _bool
	INV_CALL shadowcaster_get_cast_shadows(InvHandle self);
	
	/**
	 * Method: ShadowCaster::getEdgeList (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL shadowcaster_get_edge_list(InvHandle self);
	
	/**
	 * Method: ShadowCaster::hasEdgeList (OK)
	 */
	INV_EXPORT _bool
	INV_CALL shadowcaster_has_edge_list(InvHandle self);
	
	/**
	 * Method: ShadowCaster::getWorldBoundingBox (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL shadowcaster_get_world_bounding_box(InvHandle self, _bool derive);
	
	/**
	 * Method: ShadowCaster::getLightCapBounds (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL shadowcaster_get_light_cap_bounds(InvHandle self);
	
	/**
	 * Method: ShadowCaster::getDarkCapBounds (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL shadowcaster_get_dark_cap_bounds(InvHandle self, InvHandle light, _float dirLightExtrusionDist);
	
	/**
	 * Method: ShadowCaster::getPointExtrusionDistance (NOT IMPLEMENTED)
	 */
	INV_EXPORT _float
	INV_CALL shadowcaster_get_point_extrusion_distance(InvHandle self, InvHandle light);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IMovableObject
	 */
	
	/**
	 * Method: MovableObject::getCastShadows (OK)
	 */
	INV_EXPORT _bool
	INV_CALL movableobject_get_cast_shadows(InvHandle self);
	
	/**
	 * Method: MovableObject::getEdgeList (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL movableobject_get_edge_list(InvHandle self);
	
	/**
	 * Method: MovableObject::hasEdgeList (OK)
	 */
	INV_EXPORT _bool
	INV_CALL movableobject_has_edge_list(InvHandle self);
	
	/**
	 * Method: MovableObject::getWorldBoundingBox (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL movableobject_get_world_bounding_box(InvHandle self, _bool derive);
	
	/**
	 * Method: MovableObject::getLightCapBounds (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL movableobject_get_light_cap_bounds(InvHandle self);
	
	/**
	 * Method: MovableObject::getDarkCapBounds (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL movableobject_get_dark_cap_bounds(InvHandle self, InvHandle light, _float dirLightExtrusionDist);
	
	/**
	 * Method: MovableObject::getPointExtrusionDistance (NOT IMPLEMENTED)
	 */
	INV_EXPORT _float
	INV_CALL movableobject_get_point_extrusion_distance(InvHandle self, InvHandle light);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IFrameListener
	 */
	
	/**
	 * Method: FrameListener::~FrameListener (OK)
	 */
	INV_EXPORT void
	INV_CALL delete_framelistener(InvHandle self);
	
	/**
	 * Method: FrameListener::frameStarted (OK)
	 */
	INV_EXPORT _bool
	INV_CALL framelistener_frame_started(InvHandle self, FrameEvent frameEvent);
	
	/**
	 * Method: FrameListener::frameRenderingQueued (OK)
	 */
	INV_EXPORT _bool
	INV_CALL framelistener_frame_rendering_queued(InvHandle self, FrameEvent frameEvent);
	
	/**
	 * Method: FrameListener::frameEnded (OK)
	 */
	INV_EXPORT _bool
	INV_CALL framelistener_frame_ended(InvHandle self, FrameEvent frameEvent);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderSystemCapabilities
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.ILog
	 */
	
	/**
	 * Method: Log::addListener (OK)
	 */
	INV_EXPORT void
	INV_CALL log_add_listener(InvHandle self, InvHandle listener);
	
	/**
	 * Method: Log::removeListener (OK)
	 */
	INV_EXPORT void
	INV_CALL log_remove_listener(InvHandle self, InvHandle listener);
	
	/**
	 * Method: Log::getName (OK)
	 */
	INV_EXPORT _string
	INV_CALL log_get_name(InvHandle self);
	
	/**
	 * Method: Log::isDebugOutputEnabled (OK)
	 */
	INV_EXPORT _bool
	INV_CALL log_is_debug_output_enabled(InvHandle self);
	
	/**
	 * Method: Log::isFileOutputSuppressed (OK)
	 */
	INV_EXPORT _bool
	INV_CALL log_is_file_output_suppressed(InvHandle self);
	
	/**
	 * Method: Log::isTimeStampEnabled (OK)
	 */
	INV_EXPORT _bool
	INV_CALL log_is_time_stamp_enabled(InvHandle self);
	
	/**
	 * Method: Log::logMessage (OK)
	 */
	INV_EXPORT void
	INV_CALL log_log_message(InvHandle self, _string message, LOG_MESSAGE_LEVEL level, _bool maskDebug);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IResourceGroupManager
	 */
	
	/**
	 * Method: ResourceGroupManager::addResourceLocation (OK)
	 */
	INV_EXPORT void
	INV_CALL resourcegroupmanager_add_resource_location_m1(InvHandle self, _string name, _string locType);
	
	/**
	 * Method: ResourceGroupManager::addResourceLocation (OK)
	 */
	INV_EXPORT void
	INV_CALL resourcegroupmanager_add_resource_location_m2(InvHandle self, _string name, _string locType, _string resGroup);
	
	/**
	 * Method: ResourceGroupManager::addResourceLocation (OK)
	 */
	INV_EXPORT void
	INV_CALL resourcegroupmanager_add_resource_location_m3(InvHandle self, _string name, _string locType, _string resGroup, _bool recursive);
	
	/**
	 * Method: ResourceGroupManager::initializeAllResourceGroups (OK)
	 */
	INV_EXPORT void
	INV_CALL resourcegroupmanager_initialize_all_resource_groups(InvHandle self);
	
	/**
	 * Method: ResourceGroupManager::getSingleton (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL resourcegroupmanager_get_singleton();
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderTarget
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IFrustum
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRoot
	 */
	
	/**
	 * Method: Root::Root (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m1();
	
	/**
	 * Method: Root::Root (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m2(_string pluginFilename);
	
	/**
	 * Method: Root::Root (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m3(_string pluginFilename, _string configFilename);
	
	/**
	 * Method: Root::Root (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m4(_string pluginFilename, _string configFilename, _string logFilename);
	
	/**
	 * Method: Root::~Root (OK)
	 */
	INV_EXPORT void
	INV_CALL delete_root(InvHandle self);
	
	/**
	 * Method: Root::checkWindowMessages (OK)
	 */
	INV_EXPORT void
	INV_CALL root_check_window_messages(InvHandle self);
	
	/**
	 * Method: Root::startRendering (OK)
	 */
	INV_EXPORT void
	INV_CALL root_start_rendering(InvHandle self);
	
	/**
	 * Method: Root::addFrameListener (OK)
	 */
	INV_EXPORT void
	INV_CALL root_add_frame_listener(InvHandle self, InvHandle listener);
	
	/**
	 * Method: Root::removeFrameListener (OK)
	 */
	INV_EXPORT void
	INV_CALL root_remove_frame_listener(InvHandle self, InvHandle listener);
	
	/**
	 * Method: Root::saveConfig (OK)
	 */
	INV_EXPORT void
	INV_CALL root_save_config(InvHandle self);
	
	/**
	 * Method: Root::restoreConfig (OK)
	 */
	INV_EXPORT _bool
	INV_CALL root_restore_config(InvHandle self);
	
	/**
	 * Method: Root::showConfigDialog (OK)
	 */
	INV_EXPORT _bool
	INV_CALL root_show_config_dialog(InvHandle self);
	
	/**
	 * Method: Root::addRenderSystem (NOT IMPLEMENTED)
	 */
	INV_EXPORT void
	INV_CALL root_add_render_system(InvHandle self, InvHandle renderSystem);
	
	/**
	 * Method: Root::getRenderSystemByName (NOT IMPLEMENTED)
	 */
	INV_EXPORT _any
	INV_CALL root_get_render_system_by_name(InvHandle self, _string name);
	
	/**
	 * Method: Root::setRenderSystem (NOT IMPLEMENTED)
	 */
	INV_EXPORT void
	INV_CALL root_set_render_system(InvHandle self, InvHandle renderSystem);
	
	/**
	 * Method: Root::getRenderSystem (NOT IMPLEMENTED)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_get_render_system(InvHandle self);
	
	/**
	 * Method: Root::initialize (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_initialize_m1(InvHandle self, _bool autoCreateWindow);
	
	/**
	 * Method: Root::initialize (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_initialize_m2(InvHandle self, _bool autoCreateWindow, _string windowTitle);
	
	/**
	 * Method: Root::initialize (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_initialize_m3(InvHandle self, _bool autoCreateWindow, _string windowTitle, _string customCapabilities);
	
	/**
	 * Method: Root::isInitialized (OK)
	 */
	INV_EXPORT _bool
	INV_CALL root_is_initialized(InvHandle self);
	
	/**
	 * Method: Root::useCustomRenderSystemCapabilities (NOT IMPLEMENTED)
	 */
	INV_EXPORT void
	INV_CALL root_use_custom_render_system_capabilities(InvHandle self, InvHandle capabilities);
	
	/**
	 * Method: Root::getRemoveRenderQueueStructuresOnClear (NOT IMPLEMENTED)
	 */
	INV_EXPORT _bool
	INV_CALL root_get_remove_render_queue_structures_on_clear(InvHandle self);
	
	/**
	 * Method: Root::setRemoveRenderQueueStructuresOnClear (NOT IMPLEMENTED)
	 */
	INV_EXPORT void
	INV_CALL root_set_remove_render_queue_structures_on_clear(InvHandle self, _bool value);
	
	/**
	 * Method: Root::addSceneManagerFactory (NOT IMPLEMENTED)
	 */
	INV_EXPORT void
	INV_CALL root_add_scene_manager_factory(InvHandle self, InvHandle factory);
	
	/**
	 * Method: Root::removeSceneManagerFactory (NOT IMPLEMENTED)
	 */
	INV_EXPORT void
	INV_CALL root_remove_scene_manager_factory(InvHandle self, InvHandle factory);
	
	/**
	 * Method: Root::createSceneManager (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_create_scene_manager_m1(InvHandle self, SCENE_TYPE sceneType);
	
	/**
	 * Method: Root::createSceneManager (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_create_scene_manager_m2(InvHandle self, SCENE_TYPE sceneType, _string instanceName);
	
	/**
	 * Method: Root::createRenderWindow (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_create_render_window_m1(InvHandle self, _string name, _uint width, _uint height, _bool fullscreen);
	
	/**
	 * Method: Root::createRenderWindow (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_create_render_window_m2(InvHandle self, _string name, _uint width, _uint height, _bool fullscreen, NameValuePairList list);
	
	/**
	 * Method: Root::loadPlugin (OK)
	 */
	INV_EXPORT void
	INV_CALL root_load_plugin(InvHandle self, _string plugin);
	
	/**
	 * Method: Root::unloadPlugin (OK)
	 */
	INV_EXPORT void
	INV_CALL root_unload_plugin(InvHandle self, _string plugin);
	
	/**
	 * Method: Root::renderOneFrame (OK)
	 */
	INV_EXPORT _bool
	INV_CALL root_render_one_frame(InvHandle self, _bool clearWindowMessages);
	
	/**
	 * Method: Root::getSingleton (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL root_get_singleton();
	
	
	/*
	 * Function group: InVision.Ogre.Native.INode
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.ICustomFrameListener
	 */
	
	/**
	 * Method: CustomFrameListener::CustomFrameListener (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_customframelistener(FrameEventHandler frameStarted, FrameEventHandler frameEnded, FrameEventHandler frameRenderingQueued);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IAxisAlignedBox
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.ICamera
	 */
	
	/**
	 * Method: Camera::getPosition (OK)
	 */
	INV_EXPORT Vector3
	INV_CALL camera_get_position(InvHandle self);
	
	/**
	 * Method: Camera::setPosition (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_set_position(InvHandle self, Vector3 pos);
	
	/**
	 * Method: Camera::lookAt (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_look_at(InvHandle self, Vector3 direction);
	
	/**
	 * Method: Camera::getNearClipDistance (OK)
	 */
	INV_EXPORT _float
	INV_CALL camera_get_near_clip_distance(InvHandle self);
	
	/**
	 * Method: Camera::setNearClipDistance (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_set_near_clip_distance(InvHandle self, _float distance);
	
	/**
	 * Method: Camera::getAspectRatio (OK)
	 */
	INV_EXPORT _float
	INV_CALL camera_get_aspect_ratio(InvHandle self);
	
	/**
	 * Method: Camera::setAspectRatio (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_set_aspect_ratio(InvHandle self, _float aspectRatio);
	
	/**
	 * Method: Camera::getFarClipDistance (OK)
	 */
	INV_EXPORT _float
	INV_CALL camera_get_far_clip_distance(InvHandle self);
	
	/**
	 * Method: Camera::setFarClipDistance (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_set_far_clip_distance(InvHandle self, _float value);
	
	/**
	 * Method: Camera::setAutoAspectRatio (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_set_auto_aspect_ratio(InvHandle self, _bool value);
	
	/**
	 * Method: Camera::getPolygonMode (OK)
	 */
	INV_EXPORT POLYGON_MODE
	INV_CALL camera_get_polygon_mode(InvHandle self);
	
	/**
	 * Method: Camera::setPolygonMode (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_set_polygon_mode(InvHandle self, POLYGON_MODE value);
	
	/**
	 * Method: Camera::getDirection (OK)
	 */
	INV_EXPORT Vector3
	INV_CALL camera_get_direction(InvHandle self);
	
	/**
	 * Method: Camera::getRight (OK)
	 */
	INV_EXPORT Vector3
	INV_CALL camera_get_right(InvHandle self);
	
	/**
	 * Method: Camera::getUp (OK)
	 */
	INV_EXPORT Vector3
	INV_CALL camera_get_up(InvHandle self);
	
	/**
	 * Method: Camera::move (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_move(InvHandle self, Vector3 distance);
	
	/**
	 * Method: Camera::yaw (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_yaw(InvHandle self, _float valueRadians);
	
	/**
	 * Method: Camera::pitch (OK)
	 */
	INV_EXPORT void
	INV_CALL camera_pitch(InvHandle self, _float valueRadians);
	
	/**
	 * Method: Camera::getCastShadows (OK)
	 */
	INV_EXPORT _bool
	INV_CALL camera_get_cast_shadows(InvHandle self);
	
	/**
	 * Method: Camera::getEdgeList (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL camera_get_edge_list(InvHandle self);
	
	/**
	 * Method: Camera::hasEdgeList (OK)
	 */
	INV_EXPORT _bool
	INV_CALL camera_has_edge_list(InvHandle self);
	
	/**
	 * Method: Camera::getWorldBoundingBox (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL camera_get_world_bounding_box(InvHandle self, _bool derive);
	
	/**
	 * Method: Camera::getLightCapBounds (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL camera_get_light_cap_bounds(InvHandle self);
	
	/**
	 * Method: Camera::getDarkCapBounds (NOT IMPLEMENTED)
	 */
	INV_EXPORT BoundingBox
	INV_CALL camera_get_dark_cap_bounds(InvHandle self, InvHandle light, _float dirLightExtrusionDist);
	
	/**
	 * Method: Camera::getPointExtrusionDistance (NOT IMPLEMENTED)
	 */
	INV_EXPORT _float
	INV_CALL camera_get_point_extrusion_distance(InvHandle self, InvHandle light);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IScriptLoader
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IEntity
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IConfigFile
	 */
	
	/**
	 * Method: ConfigFile::ConfigFile (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_configfile();
	
	/**
	 * Method: ConfigFile::~ConfigFile (OK)
	 */
	INV_EXPORT void
	INV_CALL delete_configfile(InvHandle self);
	
	/**
	 * Method: ConfigFile::load (OK)
	 */
	INV_EXPORT void
	INV_CALL configfile_load(InvHandle self, _string filename, _string separators, _bool trimWhitespace);
	
	/**
	 * Method: ConfigFile::getSections (OK)
	 */
	INV_EXPORT void
	INV_CALL configfile_get_sections(InvHandle self, SettingsBySection** settingsBySection);
	
	/**
	 * Method: ConfigFile::deleteSettingsBySection (OK)
	 */
	INV_EXPORT void
	INV_CALL configfile_delete_settings_by_section(SettingsBySection* settingsBySection);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IResourceManager
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IMaterialManager
	 */
	
	/**
	 * Method: MaterialManager::setDefaultTextureFiltering (OK)
	 */
	INV_EXPORT void
	INV_CALL materialmanager_set_default_texture_filtering(InvHandle self, TEXTURE_FILTER_OPTION option);
	
	/**
	 * Method: MaterialManager::setDefaultAnisotropy (OK)
	 */
	INV_EXPORT void
	INV_CALL materialmanager_set_default_anisotropy(InvHandle self, _uint max);
	
	/**
	 * Method: MaterialManager::getDefaultAnisotropy (OK)
	 */
	INV_EXPORT _uint
	INV_CALL materialmanager_get_default_anisotropy(InvHandle self);
	
	/**
	 * Method: MaterialManager::getSingleton (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL materialmanager_get_singleton();
	
	
	/*
	 * Function group: InVision.Ogre.Native.ILogListener
	 */
	
	/**
	 * Method: LogListener::~LogListener (OK)
	 */
	INV_EXPORT void
	INV_CALL delete_loglistener(InvHandle self);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IEdgeData
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.ISceneManagerFactory
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderSystem
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.ISceneNode
	 */
	
	/**
	 * Method: SceneNode::attachObject (OK)
	 */
	INV_EXPORT void
	INV_CALL scenenode_attach_object(InvHandle self, InvHandle obj);
	
	/**
	 * Method: SceneNode::numAttachedObjects (OK)
	 */
	INV_EXPORT _ushort
	INV_CALL scenenode_num_attached_objects(InvHandle self);
	
	/**
	 * Method: SceneNode::getAttachedObject (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_get_attached_object_m1(InvHandle self, _ushort index);
	
	/**
	 * Method: SceneNode::getAttachedObject (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_get_attached_object_m2(InvHandle self, _string name);
	
	/**
	 * Method: SceneNode::detachObject (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_detach_object_m1(InvHandle self, _ushort index);
	
	/**
	 * Method: SceneNode::detachObject (OK)
	 */
	INV_EXPORT void
	INV_CALL scenenode_detach_object_m2(InvHandle self, InvHandle movableObject);
	
	/**
	 * Method: SceneNode::detachObject (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_detach_object_m3(InvHandle self, _string name);
	
	/**
	 * Method: SceneNode::detachAllObjects (OK)
	 */
	INV_EXPORT void
	INV_CALL scenenode_detach_all_objects(InvHandle self);
	
	/**
	 * Method: SceneNode::createChildSceneNode (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_create_child_scene_node_m1(InvHandle self);
	
	/**
	 * Method: SceneNode::createChildSceneNode (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_create_child_scene_node_m2(InvHandle self, Vector3 translate);
	
	/**
	 * Method: SceneNode::createChildSceneNode (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_create_child_scene_node_m3(InvHandle self, Vector3 translate, Quaternion rotate);
	
	/**
	 * Method: SceneNode::createChildSceneNode (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_create_child_scene_node_m4(InvHandle self, _string name);
	
	/**
	 * Method: SceneNode::createChildSceneNode (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_create_child_scene_node_m5(InvHandle self, _string name, Vector3 translate);
	
	/**
	 * Method: SceneNode::createChildSceneNode (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenenode_create_child_scene_node_m6(InvHandle self, _string name, Vector3 translate, Quaternion rotate);
	
	/**
	 * Method: SceneNode::setPosition (OK)
	 */
	INV_EXPORT void
	INV_CALL scenenode_set_position(InvHandle self, Vector3 value);
	
	/**
	 * Method: SceneNode::getPosition (OK)
	 */
	INV_EXPORT Vector3
	INV_CALL scenenode_get_position(InvHandle self);
	
	/**
	 * Method: SceneNode::setScale (OK)
	 */
	INV_EXPORT void
	INV_CALL scenenode_set_scale(InvHandle self, Vector3 scale);
	
	/**
	 * Method: SceneNode::getScale (OK)
	 */
	INV_EXPORT Vector3
	INV_CALL scenenode_get_scale(InvHandle self);
	
	/**
	 * Method: SceneNode::getOrientation (OK)
	 */
	INV_EXPORT Quaternion
	INV_CALL scenenode_get_orientation(InvHandle self);
	
	/**
	 * Method: SceneNode::setOrientation (OK)
	 */
	INV_EXPORT void
	INV_CALL scenenode_set_orientation(InvHandle self, Quaternion orientation);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IOverlayManager
	 */
	
	/**
	 * Method: OverlayManager::getOverlayElement (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL overlaymanager_get_overlay_element(InvHandle self, _string name, _bool isTemplate);
	
	/**
	 * Method: OverlayManager::getByName (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL overlaymanager_get_by_name(InvHandle self, _string name);
	
	/**
	 * Method: OverlayManager::getSingleton (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL overlaymanager_get_singleton();
	
	
	/*
	 * Function group: InVision.Ogre.Native.ILogManager
	 */
	
	/**
	 * Method: LogManager::LogManager (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_logmanager();
	
	/**
	 * Method: LogManager::~LogManager (OK)
	 */
	INV_EXPORT void
	INV_CALL delete_logmanager(InvHandle self);
	
	/**
	 * Method: LogManager::createLog (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_create_log(InvHandle self, _string name, _bool defaultLog, _bool debuggerOutput, _bool suppressFileOutput);
	
	/**
	 * Method: LogManager::getLog (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_get_log(InvHandle self, _string name);
	
	/**
	 * Method: LogManager::getDefaultLog (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_get_default_log(InvHandle self);
	
	/**
	 * Method: LogManager::destroyLog (OK)
	 */
	INV_EXPORT void
	INV_CALL logmanager_destroy_log_m1(InvHandle self, _string name);
	
	/**
	 * Method: LogManager::destroyLog (OK)
	 */
	INV_EXPORT void
	INV_CALL logmanager_destroy_log_m2(InvHandle self, InvHandle log);
	
	/**
	 * Method: LogManager::setDefaultLog (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_set_default_log(InvHandle self, InvHandle log);
	
	/**
	 * Method: LogManager::logMessage (OK)
	 */
	INV_EXPORT void
	INV_CALL logmanager_log_message(InvHandle self, _string message, LOG_MESSAGE_LEVEL logLevel, _bool maskDebug);
	
	/**
	 * Method: LogManager::setLogDetail (OK)
	 */
	INV_EXPORT void
	INV_CALL logmanager_set_log_detail(InvHandle self, LOGGING_LEVEL level);
	
	/**
	 * Method: LogManager::getSingleton (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_get_singleton();
	
	
	/*
	 * Function group: InVision.Ogre.Native.ILight
	 */
	
	/**
	 * Method: Light::setPosition (OK)
	 */
	INV_EXPORT void
	INV_CALL light_set_position_m1(InvHandle self, _float x, _float y, _float z);
	
	/**
	 * Method: Light::setPosition (OK)
	 */
	INV_EXPORT void
	INV_CALL light_set_position_m2(InvHandle self, Vector3 pos);
	
	/**
	 * Method: Light::getPosition (OK)
	 */
	INV_EXPORT Vector3
	INV_CALL light_get_position(InvHandle self);
	
	
	/*
	 * Function group: InVision.Ogre.Native.ICustomLogListener
	 */
	
	/**
	 * Method: CustomLogListener::CustomLogListener (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_customloglistener(LogListenerMessageLoggedHandler messageLoggedHandler);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IViewport
	 */
	
	/**
	 * Method: Viewport::Viewport (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL new_viewport(InvHandle camera, InvHandle renderTarget, _float left, _float top, _float width, _float height, _int zOrder);
	
	/**
	 * Method: Viewport::~Viewport (OK)
	 */
	INV_EXPORT void
	INV_CALL delete_viewport(InvHandle self);
	
	/**
	 * Method: Viewport::setBackgroundColor (OK)
	 */
	INV_EXPORT void
	INV_CALL viewport_set_background_color(InvHandle self, Color color);
	
	/**
	 * Method: Viewport::getBackgroundColor (OK)
	 */
	INV_EXPORT Color
	INV_CALL viewport_get_background_color(InvHandle self);
	
	/**
	 * Method: Viewport::update (OK)
	 */
	INV_EXPORT void
	INV_CALL viewport_update(InvHandle self);
	
	/**
	 * Method: Viewport::clear (OK)
	 */
	INV_EXPORT void
	INV_CALL viewport_clear(InvHandle self);
	
	/**
	 * Method: Viewport::getCamera (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL viewport_get_camera(InvHandle self);
	
	/**
	 * Method: Viewport::setCamera (OK)
	 */
	INV_EXPORT void
	INV_CALL viewport_set_camera(InvHandle self, InvHandle camera);
	
	/**
	 * Method: Viewport::getLeft (OK)
	 */
	INV_EXPORT _float
	INV_CALL viewport_get_left(InvHandle self);
	
	/**
	 * Method: Viewport::getTop (OK)
	 */
	INV_EXPORT _float
	INV_CALL viewport_get_top(InvHandle self);
	
	/**
	 * Method: Viewport::getWidth (OK)
	 */
	INV_EXPORT _float
	INV_CALL viewport_get_width(InvHandle self);
	
	/**
	 * Method: Viewport::getHeight (OK)
	 */
	INV_EXPORT _float
	INV_CALL viewport_get_height(InvHandle self);
	
	/**
	 * Method: Viewport::getActualLeft (OK)
	 */
	INV_EXPORT _int
	INV_CALL viewport_get_actual_left(InvHandle self);
	
	/**
	 * Method: Viewport::getActualTop (OK)
	 */
	INV_EXPORT _int
	INV_CALL viewport_get_actual_top(InvHandle self);
	
	/**
	 * Method: Viewport::getActualWidth (OK)
	 */
	INV_EXPORT _int
	INV_CALL viewport_get_actual_width(InvHandle self);
	
	/**
	 * Method: Viewport::getActualHeight (OK)
	 */
	INV_EXPORT _int
	INV_CALL viewport_get_actual_height(InvHandle self);
	
	
	/*
	 * Function group: InVision.Ogre.Native.ISceneManager
	 */
	
	/**
	 * Method: SceneManager::clearScene (OK)
	 */
	INV_EXPORT void
	INV_CALL scenemanager_clear_scene(InvHandle self);
	
	/**
	 * Method: SceneManager::setAmbientLight (OK)
	 */
	INV_EXPORT void
	INV_CALL scenemanager_set_ambient_light(InvHandle self, Color color);
	
	/**
	 * Method: SceneManager::getAmbientLight (OK)
	 */
	INV_EXPORT Color
	INV_CALL scenemanager_get_ambient_light(InvHandle self);
	
	/**
	 * Method: SceneManager::createCamera (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenemanager_create_camera(InvHandle self, _string name);
	
	/**
	 * Method: SceneManager::createEntity (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenemanager_create_entity_m1(InvHandle self, _string meshName);
	
	/**
	 * Method: SceneManager::createEntity (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenemanager_create_entity_m2(InvHandle self, _string entityName, _string meshName);
	
	/**
	 * Method: SceneManager::getRootSceneNode (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenemanager_get_root_scene_node(InvHandle self);
	
	/**
	 * Method: SceneManager::createLight (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenemanager_create_light_m1(InvHandle self);
	
	/**
	 * Method: SceneManager::createLight (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL scenemanager_create_light_m2(InvHandle self, _string name);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderWindow
	 */
	
	/**
	 * Method: RenderWindow::getCustomAttribute (OK)
	 */
	INV_EXPORT void
	INV_CALL renderwindow_get_custom_attribute(InvHandle self, _string name, _any* data);
	
	/**
	 * Method: RenderWindow::addViewport (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL renderwindow_add_viewport(InvHandle self, InvHandle camera, _int zOrder, _float left, _float top, _float width, _float height);
	
	/**
	 * Method: RenderWindow::isClosed (OK)
	 */
	INV_EXPORT _bool
	INV_CALL renderwindow_is_closed(InvHandle self);
	
	/**
	 * Method: RenderWindow::writeContentsToTimestampedFile (OK)
	 */
	INV_EXPORT _string
	INV_CALL renderwindow_write_contents_to_timestamped_file(InvHandle self, _string filenamePrefix, _string filenameSuffix);
	
	/**
	 * Method: RenderWindow::getStatistics (OK)
	 */
	INV_EXPORT FrameStats
	INV_CALL renderwindow_get_statistics(InvHandle self);
	
	
	/*
	 * Function group: InVision.Ogre.Native.ITextureManager
	 */
	
	/**
	 * Method: TextureManager::setDefaultNumMipmaps (OK)
	 */
	INV_EXPORT void
	INV_CALL texturemanager_set_default_num_mipmaps(InvHandle self, _int num);
	
	/**
	 * Method: TextureManager::getDefaultNumMipmaps (OK)
	 */
	INV_EXPORT _int
	INV_CALL texturemanager_get_default_num_mipmaps(InvHandle self);
	
	/**
	 * Method: TextureManager::reloadAll (OK)
	 */
	INV_EXPORT void
	INV_CALL texturemanager_reload_all(InvHandle self, _bool reloadableOnly);
	
	/**
	 * Method: TextureManager::getSingleton (OK)
	 */
	INV_EXPORT InvHandle
	INV_CALL texturemanager_get_singleton();
	
	
}


#ifdef __cplusplus
#include <Ogre.h>
#include "cCustomFrameListener.h"
#include "cCustomLogListener.h"

using namespace invision;

inline Ogre::StringInterface* asStringInterface(InvHandle self) {
	return castHandle< Ogre::StringInterface >(self);
}

inline Ogre::Renderable* asRenderable(InvHandle self) {
	return castHandle< Ogre::Renderable >(self);
}

inline Ogre::OverlayElement* asOverlayElement(InvHandle self) {
	return castHandle< Ogre::OverlayElement >(self);
}

inline Ogre::Overlay* asOverlay(InvHandle self) {
	return castHandle< Ogre::Overlay >(self);
}

inline Ogre::AnimableObject* asAnimableObject(InvHandle self) {
	return castHandle< Ogre::AnimableObject >(self);
}

inline Ogre::ShadowCaster* asShadowCaster(InvHandle self) {
	return castHandle< Ogre::ShadowCaster >(self);
}

inline Ogre::MovableObject* asMovableObject(InvHandle self) {
	return castHandle< Ogre::MovableObject >(self);
}

inline Ogre::FrameListener* asFrameListener(InvHandle self) {
	return castHandle< Ogre::FrameListener >(self);
}

inline Ogre::RenderSystemCapabilities* asRenderSystemCapabilities(InvHandle self) {
	return castHandle< Ogre::RenderSystemCapabilities >(self);
}

inline Ogre::Log* asLog(InvHandle self) {
	return castHandle< Ogre::Log >(self);
}

inline Ogre::ResourceGroupManager* asResourceGroupManager(InvHandle self) {
	return castHandle< Ogre::ResourceGroupManager >(self);
}

inline Ogre::RenderTarget* asRenderTarget(InvHandle self) {
	return castHandle< Ogre::RenderTarget >(self);
}

inline Ogre::Frustum* asFrustum(InvHandle self) {
	return castHandle< Ogre::Frustum >(self);
}

inline Ogre::Root* asRoot(InvHandle self) {
	return castHandle< Ogre::Root >(self);
}

inline Ogre::Node* asNode(InvHandle self) {
	return castHandle< Ogre::Node >(self);
}

inline CustomFrameListener* asCustomFrameListener(InvHandle self) {
	return castHandle< CustomFrameListener >(self);
}

inline Ogre::AxisAlignedBox* asAxisAlignedBox(InvHandle self) {
	return castHandle< Ogre::AxisAlignedBox >(self);
}

inline Ogre::Camera* asCamera(InvHandle self) {
	return castHandle< Ogre::Camera >(self);
}

inline Ogre::ScriptLoader* asScriptLoader(InvHandle self) {
	return castHandle< Ogre::ScriptLoader >(self);
}

inline Ogre::Entity* asEntity(InvHandle self) {
	return castHandle< Ogre::Entity >(self);
}

inline Ogre::ConfigFile* asConfigFile(InvHandle self) {
	return castHandle< Ogre::ConfigFile >(self);
}

inline Ogre::ResourceManager* asResourceManager(InvHandle self) {
	return castHandle< Ogre::ResourceManager >(self);
}

inline Ogre::MaterialManager* asMaterialManager(InvHandle self) {
	return castHandle< Ogre::MaterialManager >(self);
}

inline Ogre::LogListener* asLogListener(InvHandle self) {
	return castHandle< Ogre::LogListener >(self);
}

inline Ogre::EdgeData* asEdgeData(InvHandle self) {
	return castHandle< Ogre::EdgeData >(self);
}

inline Ogre::SceneManagerFactory* asSceneManagerFactory(InvHandle self) {
	return castHandle< Ogre::SceneManagerFactory >(self);
}

inline Ogre::RenderSystem* asRenderSystem(InvHandle self) {
	return castHandle< Ogre::RenderSystem >(self);
}

inline Ogre::SceneNode* asSceneNode(InvHandle self) {
	return castHandle< Ogre::SceneNode >(self);
}

inline Ogre::OverlayManager* asOverlayManager(InvHandle self) {
	return castHandle< Ogre::OverlayManager >(self);
}

inline Ogre::LogManager* asLogManager(InvHandle self) {
	return castHandle< Ogre::LogManager >(self);
}

inline Ogre::Light* asLight(InvHandle self) {
	return castHandle< Ogre::Light >(self);
}

inline CustomLogListener* asCustomLogListener(InvHandle self) {
	return castHandle< CustomLogListener >(self);
}

inline Ogre::Viewport* asViewport(InvHandle self) {
	return castHandle< Ogre::Viewport >(self);
}

inline Ogre::SceneManager* asSceneManager(InvHandle self) {
	return castHandle< Ogre::SceneManager >(self);
}

inline Ogre::RenderWindow* asRenderWindow(InvHandle self) {
	return castHandle< Ogre::RenderWindow >(self);
}

inline Ogre::TextureManager* asTextureManager(InvHandle self) {
	return castHandle< Ogre::TextureManager >(self);
}

/*
 * Initializer
 */
struct InVisionNative_Ogre
{
	InVisionNative_Ogre()
	{
		register_converter< Ogre::OverlayElement, Ogre::StringInterface >();
		register_converter< Ogre::OverlayElement, Ogre::Renderable >();
		register_converter< Ogre::MovableObject, Ogre::AnimableObject >();
		register_converter< Ogre::MovableObject, Ogre::ShadowCaster >();
		register_converter< Ogre::ResourceGroupManager, Ogre::Singleton< Ogre::ResourceGroupManager > >();
		register_converter< Ogre::Frustum, Ogre::MovableObject >();
		register_converter< Ogre::Frustum, Ogre::AnimableObject >();
		register_converter< Ogre::Frustum, Ogre::ShadowCaster >();
		register_converter< Ogre::Frustum, Ogre::Renderable >();
		register_converter< Ogre::Root, Ogre::Singleton< Ogre::Root > >();
		register_converter< CustomFrameListener, Ogre::FrameListener >();
		register_converter< Ogre::Camera, Ogre::AnimableObject >();
		register_converter< Ogre::Camera, Ogre::ShadowCaster >();
		register_converter< Ogre::Camera, Ogre::Renderable >();
		register_converter< Ogre::Entity, Ogre::MovableObject >();
		register_converter< Ogre::Entity, Ogre::AnimableObject >();
		register_converter< Ogre::Entity, Ogre::ShadowCaster >();
		register_converter< Ogre::ResourceManager, Ogre::ScriptLoader >();
		register_converter< Ogre::MaterialManager, Ogre::Singleton< Ogre::MaterialManager > >();
		register_converter< Ogre::SceneNode, Ogre::Node >();
		register_converter< Ogre::OverlayManager, Ogre::ScriptLoader >();
		register_converter< Ogre::OverlayManager, Ogre::Singleton< Ogre::OverlayManager > >();
		register_converter< Ogre::LogManager, Ogre::Singleton< Ogre::LogManager > >();
		register_converter< Ogre::Light, Ogre::MovableObject >();
		register_converter< Ogre::Light, Ogre::AnimableObject >();
		register_converter< Ogre::Light, Ogre::ShadowCaster >();
		register_converter< CustomLogListener, Ogre::LogListener >();
		register_converter< Ogre::RenderWindow, Ogre::RenderTarget >();
		register_converter< Ogre::TextureManager, Ogre::Singleton< Ogre::TextureManager > >();
	}
};

static InVisionNative_Ogre __initInVisionNative_Ogre;

#endif // __cplusplus
#endif // __INVISIONNATIVE_OGRE_H__

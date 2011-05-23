#ifndef __INVISIONNATIVE_OGRE_H__
#define __INVISIONNATIVE_OGRE_H__

#include <InvisionHandle.h>

extern "C"
{
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
	
	
	typedef void (INV_CALL *LogListenerMessageLoggedHandler)(_string message, LOG_MESSAGE_LEVEL level, _bool maskDebug, _string name);
	
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderSystemCapabilities
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.ILog
	 */
	
	/**
	 * Method: Log::addListener
	 */
	INV_EXPORT void
	INV_CALL log_add_listener(InvHandle self, InvHandle listener);
	
	/**
	 * Method: Log::removeListener
	 */
	INV_EXPORT void
	INV_CALL log_remove_listener(InvHandle self, InvHandle listener);
	
	/**
	 * Method: Log::getName
	 */
	INV_EXPORT _string
	INV_CALL log_get_name(InvHandle self);
	
	/**
	 * Method: Log::isDebugOutputEnabled
	 */
	INV_EXPORT _bool
	INV_CALL log_is_debug_output_enabled(InvHandle self);
	
	/**
	 * Method: Log::isFileOutputSuppressed
	 */
	INV_EXPORT _bool
	INV_CALL log_is_file_output_suppressed(InvHandle self);
	
	/**
	 * Method: Log::isTimeStampEnabled
	 */
	INV_EXPORT _bool
	INV_CALL log_is_time_stamp_enabled(InvHandle self);
	
	/**
	 * Method: Log::logMessage
	 */
	INV_EXPORT void
	INV_CALL log_log_message(InvHandle self, _string message, LOG_MESSAGE_LEVEL level, _bool maskDebug);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRoot
	 */
	
	/**
	 * Method: Root::Root
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m1();
	
	/**
	 * Method: Root::Root
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m2(_string pluginFilename);
	
	/**
	 * Method: Root::Root
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m3(_string pluginFilename, _string configFilename);
	
	/**
	 * Method: Root::Root
	 */
	INV_EXPORT InvHandle
	INV_CALL new_root_m4(_string pluginFilename, _string configFilename, _string logFilename);
	
	/**
	 * Method: Root::~Root
	 */
	INV_EXPORT void
	INV_CALL delete_root(InvHandle self);
	
	/**
	 * Method: Root::saveConfig
	 */
	INV_EXPORT void
	INV_CALL root_save_config(InvHandle self);
	
	/**
	 * Method: Root::restoreConfig
	 */
	INV_EXPORT _bool
	INV_CALL root_restore_config(InvHandle self);
	
	/**
	 * Method: Root::showConfigDialog
	 */
	INV_EXPORT _bool
	INV_CALL root_show_config_dialog(InvHandle self);
	
	/**
	 * Method: Root::addRenderSystem
	 */
	INV_EXPORT void
	INV_CALL root_add_render_system(InvHandle self, InvHandle renderSystem);
	
	/**
	 * Method: Root::getRenderSystemByName
	 */
	INV_EXPORT _any
	INV_CALL root_get_render_system_by_name(InvHandle self, _string name);
	
	/**
	 * Method: Root::setRenderSystem
	 */
	INV_EXPORT void
	INV_CALL root_set_render_system(InvHandle self, InvHandle renderSystem);
	
	/**
	 * Method: Root::getRenderSystem
	 */
	INV_EXPORT InvHandle
	INV_CALL root_get_render_system(InvHandle self);
	
	/**
	 * Method: Root::initialize
	 */
	INV_EXPORT InvHandle
	INV_CALL root_initialize_m1(InvHandle self, _bool autoCreateWindow);
	
	/**
	 * Method: Root::initialize
	 */
	INV_EXPORT InvHandle
	INV_CALL root_initialize_m2(InvHandle self, _bool autoCreateWindow, _string windowTitle);
	
	/**
	 * Method: Root::initialize
	 */
	INV_EXPORT InvHandle
	INV_CALL root_initialize_m3(InvHandle self, _bool autoCreateWindow, _string windowTitle, _string customCapabilities);
	
	/**
	 * Method: Root::isInitialized
	 */
	INV_EXPORT _bool
	INV_CALL root_is_initialized(InvHandle self);
	
	/**
	 * Method: Root::useCustomRenderSystemCapabilities
	 */
	INV_EXPORT void
	INV_CALL root_use_custom_render_system_capabilities(InvHandle self, InvHandle capabilities);
	
	/**
	 * Method: Root::getRemoveRenderQueueStructuresOnClear
	 */
	INV_EXPORT _bool
	INV_CALL root_get_remove_render_queue_structures_on_clear(InvHandle self);
	
	/**
	 * Method: Root::setRemoveRenderQueueStructuresOnClear
	 */
	INV_EXPORT void
	INV_CALL root_set_remove_render_queue_structures_on_clear(InvHandle self, _bool value);
	
	/**
	 * Method: Root::addSceneManagerFactory
	 */
	INV_EXPORT void
	INV_CALL root_add_scene_manager_factory(InvHandle self, InvHandle factory);
	
	/**
	 * Method: Root::removeSceneManagerFactory
	 */
	INV_EXPORT void
	INV_CALL root_remove_scene_manager_factory(InvHandle self, InvHandle factory);
	
	/**
	 * Method: Root::createSceneManager
	 */
	INV_EXPORT InvHandle
	INV_CALL root_create_scene_manager_m1(InvHandle self, SCENE_TYPE sceneType);
	
	/**
	 * Method: Root::createSceneManager
	 */
	INV_EXPORT InvHandle
	INV_CALL root_create_scene_manager_m2(InvHandle self, SCENE_TYPE sceneType, _string instanceName);
	
	/**
	 * Method: Root::getSingleton
	 */
	INV_EXPORT InvHandle
	INV_CALL root_get_singleton();
	
	
	/*
	 * Function group: InVision.Ogre.Native.ICamera
	 */
	
	/**
	 * Method: Camera::setPosition
	 */
	INV_EXPORT void
	INV_CALL camera_set_position(InvHandle self, Vector3 pos);
	
	/**
	 * Method: Camera::lookAt
	 */
	INV_EXPORT void
	INV_CALL camera_look_at(InvHandle self, Vector3 direction);
	
	/**
	 * Method: Camera::setNearClipDistance
	 */
	INV_EXPORT void
	INV_CALL camera_set_near_clip_distance(InvHandle self, _float distance);
	
	/**
	 * Method: Camera::setAspectRatio
	 */
	INV_EXPORT void
	INV_CALL camera_set_aspect_ratio(InvHandle self, _float aspectRatio);
	
	
	/*
	 * Function group: InVision.Ogre.Native.ISceneManagerFactory
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderSystem
	 */
	
	
	/*
	 * Function group: InVision.Ogre.Native.ILogManager
	 */
	
	/**
	 * Method: LogManager::LogManager
	 */
	INV_EXPORT InvHandle
	INV_CALL new_logmanager();
	
	/**
	 * Method: LogManager::~LogManager
	 */
	INV_EXPORT void
	INV_CALL delete_logmanager(InvHandle self);
	
	/**
	 * Method: LogManager::createLog
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_create_log(InvHandle self, _string name, _bool defaultLog, _bool debuggerOutput, _bool suppressFileOutput);
	
	/**
	 * Method: LogManager::getLog
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_get_log(InvHandle self, _string name);
	
	/**
	 * Method: LogManager::getDefaultLog
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_get_default_log(InvHandle self);
	
	/**
	 * Method: LogManager::destroyLog
	 */
	INV_EXPORT void
	INV_CALL logmanager_destroy_log_m1(InvHandle self, _string name);
	
	/**
	 * Method: LogManager::destroyLog
	 */
	INV_EXPORT void
	INV_CALL logmanager_destroy_log_m2(InvHandle self, InvHandle log);
	
	/**
	 * Method: LogManager::setDefaultLog
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_set_default_log(InvHandle self, InvHandle log);
	
	/**
	 * Method: LogManager::logMessage
	 */
	INV_EXPORT void
	INV_CALL logmanager_log_message(InvHandle self, _string message, LOG_MESSAGE_LEVEL logLevel, _bool maskDebug);
	
	/**
	 * Method: LogManager::setLogDetail
	 */
	INV_EXPORT void
	INV_CALL logmanager_set_log_detail(InvHandle self, LOGGING_LEVEL level);
	
	/**
	 * Method: LogManager::getSingleton
	 */
	INV_EXPORT InvHandle
	INV_CALL logmanager_get_singleton();
	
	
	/*
	 * Function group: InVision.Ogre.Native.IViewport
	 */
	
	/**
	 * Method: Viewport::setBackgroundColor
	 */
	INV_EXPORT void
	INV_CALL viewport_set_background_color(InvHandle self, Color color);
	
	
	/*
	 * Function group: InVision.Ogre.Native.ISceneManager
	 */
	
	/**
	 * Method: SceneManager::clearScene
	 */
	INV_EXPORT void
	INV_CALL scenemanager_clear_scene(InvHandle self);
	
	/**
	 * Method: SceneManager::setAmbientLight
	 */
	INV_EXPORT void
	INV_CALL scenemanager_set_ambient_light(InvHandle self, Color color);
	
	/**
	 * Method: SceneManager::getAmbientLight
	 */
	INV_EXPORT Color
	INV_CALL scenemanager_get_ambient_light(InvHandle self);
	
	/**
	 * Method: SceneManager::createCamera
	 */
	INV_EXPORT InvHandle
	INV_CALL scenemanager_create_camera(InvHandle self, _string name);
	
	
	/*
	 * Function group: InVision.Ogre.Native.IRenderWindow
	 */
	
	/**
	 * Method: RenderWindow::getCustomAttribute
	 */
	INV_EXPORT void
	INV_CALL renderwindow_get_custom_attribute(InvHandle self, _string name, _any* data);
	
	/**
	 * Method: RenderWindow::addViewport
	 */
	INV_EXPORT InvHandle
	INV_CALL renderwindow_add_viewport(InvHandle self, InvHandle camera, _int zOrder, _float left, _float top, _float width, _float height);
	
	
	/*
	 * Function group: InVision.Ogre.Native.ICustomLogListener
	 */
	
	/**
	 * Method: CustomLogListener::CustomLogListener
	 */
	INV_EXPORT InvHandle
	INV_CALL new_customloglistener(LogListenerMessageLoggedHandler messageLoggedHandler);
	
	/**
	 * Method: CustomLogListener::~CustomLogListener
	 */
	INV_EXPORT void
	INV_CALL delete_customloglistener(InvHandle self);
	
	
}


#ifdef __cplusplus
#include <Ogre.h>
#include "cCustomLogListener.h"

using namespace invision;

inline Ogre::RenderSystemCapabilities* asRenderSystemCapabilities(InvHandle self) {
	return castHandle< Ogre::RenderSystemCapabilities >(self);
}

inline Ogre::Log* asLog(InvHandle self) {
	return castHandle< Ogre::Log >(self);
}

inline Ogre::Root* asRoot(InvHandle self) {
	return castHandle< Ogre::Root >(self);
}

inline Ogre::Camera* asCamera(InvHandle self) {
	return castHandle< Ogre::Camera >(self);
}

inline Ogre::SceneManagerFactory* asSceneManagerFactory(InvHandle self) {
	return castHandle< Ogre::SceneManagerFactory >(self);
}

inline Ogre::RenderSystem* asRenderSystem(InvHandle self) {
	return castHandle< Ogre::RenderSystem >(self);
}

inline Ogre::LogManager* asLogManager(InvHandle self) {
	return castHandle< Ogre::LogManager >(self);
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

inline CustomLogListener* asCustomLogListener(InvHandle self) {
	return castHandle< CustomLogListener >(self);
}

#endif // __cplusplus
#endif // __INVISIONNATIVE_OGRE_H__

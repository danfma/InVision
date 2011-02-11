#ifndef OGREROOT_H
#define OGREROOT_H

#include "invision/Common.h"
#include "invision/NameValueParamsHandle.h"

extern "C"
{
	//
	// Ogre::RootHandle prefix = Root
	//

	/*
	 * Creation and destruction
	 */

	__EXPORT HRoot __ENTRY root_new(
		const char* pluginFilename,
		const char* configFilename);

	__EXPORT HRoot __ENTRY root_new_with_log(
		const char* pluginFilename,
		const char* configFilename,
		const char* logFilename);

	__EXPORT void __ENTRY root_delete(
		HRoot self);

	/*
	 * Methods
	 */

	__EXPORT void __ENTRY root_save_config(
		HRoot self);

	__EXPORT Bool __ENTRY root_restore_config(
		HRoot self);

	__EXPORT Bool __ENTRY root_show_config_dialog(
		HRoot self);

	// TODO addRenderSystem

	__EXPORT HEnumerator __ENTRY root_get_available_renderers(
		HRoot self);

	/** NEW */
	__EXPORT HRenderSystem __ENTRY root_get_rendersystem_by_name(
		HRoot self,
		const char* name);

	__EXPORT HRenderWindow __ENTRY root_initialise_with_title_and_cap(
		HRoot self,
		Bool autoCreateWindow,
		const char* title,
		const char* capabilitiesConfig);

	__EXPORT HRenderWindow __ENTRY root_initialise_with_title(
		HRoot self,
		Bool autoCreateWindow,
		const char* title);

	__EXPORT HRenderWindow __ENTRY root_initialise(
		HRoot self,
		Bool autoCreateWindow);

	__EXPORT Bool __ENTRY root_is_initialised(
		HRoot self);

	// TODO useCustomRenderSystemCapabilities

	/** NEW */
	__EXPORT Bool __ENTRY root_get_remove_render_queue_structures_on_clear(
		HRoot self);

	/** NEW */
	__EXPORT void __ENTRY root_set_remove_render_queue_structures_on_clear(
		HRoot self,
		Bool value);

	// TODO addSceneManagerFactory
	// TODO removeSceneManagerFactory
	// TODO getSceneManagerMetaData
	// TODO getSceneManagerMetaDataIterator

	__EXPORT HSceneManager __ENTRY root_create_scenemanager_by_typename(
		HRoot self,
		const char* typeName);

	__EXPORT HSceneManager __ENTRY root_create_scenemanager_by_typename2(
		HRoot self,
		const char* typeName,
		const char* instanceName);

	__EXPORT HSceneManager __ENTRY root_create_scenemanager_by_type(
		HRoot self,
		UInt32 type);

	__EXPORT HSceneManager __ENTRY root_create_scenemanager_by_type2(
		HRoot self,
		UInt32 type,
		const char* instanceName);

	/** NEW */
	__EXPORT void __ENTRY root_destroy_scenemanager(
		HRoot self,
		HSceneManager sceneManager);

	/** NEW */
	__EXPORT HSceneManager __ENTRY root_get_scenemanager(
		HRoot self,
		const char* instanceName);

	/** NEW */
	__EXPORT Bool __ENTRY root_has_scenemanager(
		HRoot self,
		const char* instanceName);

	// TODO getSceneManagerIterator

	/** NEW */
	__EXPORT HTextureManager __ENTRY root_get_texturemanager(
		HRoot self);

	/** NEW */
	__EXPORT HMeshManager __ENTRY root_get_meshmanager(
		HRoot self);

	/** NEW */
	__EXPORT const char* __ENTRY root_get_error_description(
		HRoot self,
		Int64 errorNumber);

	__EXPORT void __ENTRY root_add_framelistener(
		HRoot self,
		HFrameListener listener);

	__EXPORT void __ENTRY root_remove_framelistener(
		HRoot self,
		HFrameListener listener);

	/** NEW */
	__EXPORT void __ENTRY root_queue_end_rendering(
		HRoot self);

	__EXPORT void __ENTRY root_start_rendering(
		HRoot self);

	/** NEW */
	__EXPORT Bool __ENTRY root_render_one_frame(
		HRoot self);

	/** NEW */
	__EXPORT Bool __ENTRY root_render_one_frame_with_time(
		HRoot self,
		float timeSinceLastFrame);

	/** NEW */
	__EXPORT void __ENTRY root_shutdown(
		HRoot self);

	// TODO addResourceLocation
	// TODO removeResourceLocation
	// TODO createFileStream
	// TODO openFileStream
	// TODO convertColourValue
	
	__EXPORT HRenderWindow __ENTRY root_get_auto_created_window(
		HRoot self);

	__EXPORT HRenderWindow __ENTRY root_create_renderwindow(
		HRoot self,
		const char* name,
		UInt32 width, UInt32 height,
		Bool fullscreen);

	__EXPORT HRenderWindow __ENTRY root_create_renderwindow_with_params(
		HRoot self,
		const char* name,
		UInt32 width, UInt32 height,
		Bool fullscreen,
		HNameValuePairList pairList);

	// TODO createRenderWindows
	// TODO detachRenderTarget
	// TODO getRenderTarget

	__EXPORT void __ENTRY root_load_plugin(
		HRoot self,
		const char *pluginName);

	__EXPORT void __ENTRY root_unload_plugin(
		HRoot self,
		const char *pluginName);

	// TODO installPlugin
	// TODO uninstallPlugin
	// TODO getInstalledPlugins
	// TODO getTimer

	// RAISING METHODS
	// TODO _fireFrameStarted(FrameEvent)
	// TODO _fireFrameRenderingQueued(FrameEvent)
	// TODO _fireFrameEnded(FrameEvent)
	// TODO _fireFrameStarted
	// TODO _fireFrameRenderingQueued()
	// TODO _fireFrameEnded()

	/** NEW */
	__EXPORT UInt64 __ENTRY root_get_next_frame_number(
		HRoot self);

	/** NEW */
	__EXPORT HSceneManager root_get_current_scenemanager(
		HRoot self);

	// TODO _getCurrentSceneManager
	// TODO _pushCurrentSceneManager
	// TODO _popCurrentSceneManager
	// TODO _updateAllRenderTargets()
	// TODO _updateAllRenderTargets(FrameEvent)

	// TODO createRenderQueueInvocationSequence
	// TODO getRenderQueueInvocationSequence
	// TODO destroyRenderQueueInvocationSequence

	/** NEW */
	__EXPORT void __ENTRY root_clear_event_times(
		HRoot self);

	/** NEW */
	__EXPORT void __ENTRY root_set_frame_smoothing_period(
		HRoot self,
		float period);

	/** NEW */
	__EXPORT float __ENTRY root_get_frame_smoothing_period(
		HRoot self);

	// TODO addMovableObjectFactory
	// TODO removeMovableObjectFactory

	/** NEW */
	__EXPORT Bool __ENTRY root_has_movable_object_factory(
		HRoot self,
		const char* typeName);

	// TODO getMovableObjectFactory
	// TODO _allocateNextMovableObjectTypeFlag
	// TODO getMovableObjectFactoryIterator

	/** NEW */
	__EXPORT UInt32 __ENTRY root_get_display_monitor_count(
		HRoot self);

	// TODO getWorkQueue
	// TODO setWorkQueue


	/*
	 * Static methods
	 */

	__EXPORT HRoot __ENTRY root_get_singleton();

}


#endif // OGREROOT_H

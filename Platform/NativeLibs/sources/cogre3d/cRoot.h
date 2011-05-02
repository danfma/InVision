#ifndef OGREROOT_H
#define OGREROOT_H

#include "cOgre.h"
#include "NameValueParamsHandle.h"

extern "C"
{
	//
	// Ogre::RootHandle prefix = Root
	//

	/*
	 * Creation and destruction
	 */

	INV_EXPORT HRoot INV_CALL root_new(
		const _string pluginFilename,
		const _string configFilename);

	INV_EXPORT HRoot INV_CALL root_new_with_log(
		const _string pluginFilename,
		const _string configFilename,
		const _string logFilename);

	INV_EXPORT void INV_CALL root_delete(
		HRoot self);

	/*
	 * Methods
	 */

	INV_EXPORT void INV_CALL root_save_config(
		HRoot self);

	INV_EXPORT _bool INV_CALL root_restore_config(
		HRoot self);

	INV_EXPORT _bool INV_CALL root_show_config_dialog(
		HRoot self);

	// TODO addRenderSystem

	INV_EXPORT HEnumerator INV_CALL root_get_available_renderers(
		HRoot self);

	/** NEW */
	INV_EXPORT HRenderSystem INV_CALL root_get_rendersystem_by_name(
		HRoot self,
		const _string name);

	INV_EXPORT HRenderWindow INV_CALL root_initialise_with_title_and_cap(
		HRoot self,
		_bool autoCreateWindow,
		const _string title,
		const _string capabilitiesConfig);

	INV_EXPORT HRenderWindow INV_CALL root_initialise_with_title(
		HRoot self,
		_bool autoCreateWindow,
		const _string title);

	INV_EXPORT HRenderWindow INV_CALL root_initialise(
		HRoot self,
		_bool autoCreateWindow);

	INV_EXPORT _bool INV_CALL root_is_initialised(
		HRoot self);

	// TODO useCustomRenderSystemCapabilities

	/** NEW */
	INV_EXPORT _bool INV_CALL root_get_remove_render_queue_structures_on_clear(
		HRoot self);

	/** NEW */
	INV_EXPORT void INV_CALL root_set_remove_render_queue_structures_on_clear(
		HRoot self,
		_bool value);

	// TODO addSceneManagerFactory
	// TODO removeSceneManagerFactory
	// TODO getSceneManagerMetaData
	// TODO getSceneManagerMetaDataIterator

	INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_typename(
		HRoot self,
		const _string typeName);

	INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_typename2(
		HRoot self,
		const _string typeName,
		const _string instanceName);

	INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_type(
		HRoot self,
		_uint type);

	INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_type2(
		HRoot self,
		_uint type,
		const _string instanceName);

	/** NEW */
	INV_EXPORT void INV_CALL root_destroy_scenemanager(
		HRoot self,
		HSceneManager sceneManager);

	/** NEW */
	INV_EXPORT HSceneManager INV_CALL root_get_scenemanager(
		HRoot self,
		const _string instanceName);

	/** NEW */
	INV_EXPORT _bool INV_CALL root_has_scenemanager(
		HRoot self,
		const _string instanceName);

	// TODO getSceneManagerIterator

	/** NEW */
	INV_EXPORT HTextureManager INV_CALL root_get_texturemanager(
		HRoot self);

	/** NEW */
	INV_EXPORT HMeshManager INV_CALL root_get_meshmanager(
		HRoot self);

	/** NEW */
	INV_EXPORT const _string INV_CALL root_get_error_description(
		HRoot self,
		Int64 errorNumber);

	INV_EXPORT void INV_CALL root_add_framelistener(
		HRoot self,
		HFrameListener listener);

	INV_EXPORT void INV_CALL root_remove_framelistener(
		HRoot self,
		HFrameListener listener);

	/** NEW */
	INV_EXPORT void INV_CALL root_queue_end_rendering(
		HRoot self);

	INV_EXPORT void INV_CALL root_start_rendering(
		HRoot self);

	/** NEW */
	INV_EXPORT _bool INV_CALL root_render_one_frame(
		HRoot self);

	/** NEW */
	INV_EXPORT _bool INV_CALL root_render_one_frame_with_time(
		HRoot self,
		_float timeSinceLastFrame);

	/** NEW */
	INV_EXPORT void INV_CALL root_shutdown(
		HRoot self);

	// TODO addResourceLocation
	// TODO removeResourceLocation
	// TODO createFileStream
	// TODO openFileStream
	// TODO convertColourValue
	
	INV_EXPORT HRenderWindow INV_CALL root_get_auto_created_window(
		HRoot self);

	INV_EXPORT HRenderWindow INV_CALL root_create_renderwindow(
		HRoot self,
		const _string name,
		_uint width, _uint height,
		_bool fullscreen);

	INV_EXPORT HRenderWindow INV_CALL root_create_renderwindow_with_params(
		HRoot self,
		const _string name,
		_uint width, _uint height,
		_bool fullscreen,
		HNameValuePairList pairList);

	// TODO createRenderWindows
	// TODO detachRenderTarget
	// TODO getRenderTarget

	INV_EXPORT void INV_CALL root_load_plugin(
		HRoot self,
		const char *pluginName);

	INV_EXPORT void INV_CALL root_unload_plugin(
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
	INV_EXPORT _ulong INV_CALL root_get_next_frame_number(
		HRoot self);

	/** NEW */
	INV_EXPORT HSceneManager root_get_current_scenemanager(
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
	INV_EXPORT void INV_CALL root_clear_event_times(
		HRoot self);

	/** NEW */
	INV_EXPORT void INV_CALL root_set_frame_smoothing_period(
		HRoot self,
		_float period);

	/** NEW */
	INV_EXPORT _float INV_CALL root_get_frame_smoothing_period(
		HRoot self);

	// TODO addMovableObjectFactory
	// TODO removeMovableObjectFactory

	/** NEW */
	INV_EXPORT _bool INV_CALL root_has_movable_object_factory(
		HRoot self,
		const _string typeName);

	// TODO getMovableObjectFactory
	// TODO _allocateNextMovableObjectTypeFlag
	// TODO getMovableObjectFactoryIterator

	/** NEW */
	INV_EXPORT _uint INV_CALL root_get_display_monitor_count(
		HRoot self);

	// TODO getWorkQueue
	// TODO setWorkQueue


	/*
	 * Static methods
	 */

	INV_EXPORT HRoot INV_CALL root_get_singleton();

}


#endif // OGREROOT_H

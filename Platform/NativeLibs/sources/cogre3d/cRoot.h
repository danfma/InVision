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

	__export HRoot __entry root_new(
		const _string pluginFilename,
		const _string configFilename);

	__export HRoot __entry root_new_with_log(
		const _string pluginFilename,
		const _string configFilename,
		const _string logFilename);

	__export void __entry root_delete(
		HRoot self);

	/*
	 * Methods
	 */

	__export void __entry root_save_config(
		HRoot self);

	__export _bool __entry root_restore_config(
		HRoot self);

	__export _bool __entry root_show_config_dialog(
		HRoot self);

	// TODO addRenderSystem

	__export HEnumerator __entry root_get_available_renderers(
		HRoot self);

	/** NEW */
	__export HRenderSystem __entry root_get_rendersystem_by_name(
		HRoot self,
		const _string name);

	__export HRenderWindow __entry root_initialise_with_title_and_cap(
		HRoot self,
		_bool autoCreateWindow,
		const _string title,
		const _string capabilitiesConfig);

	__export HRenderWindow __entry root_initialise_with_title(
		HRoot self,
		_bool autoCreateWindow,
		const _string title);

	__export HRenderWindow __entry root_initialise(
		HRoot self,
		_bool autoCreateWindow);

	__export _bool __entry root_is_initialised(
		HRoot self);

	// TODO useCustomRenderSystemCapabilities

	/** NEW */
	__export _bool __entry root_get_remove_render_queue_structures_on_clear(
		HRoot self);

	/** NEW */
	__export void __entry root_set_remove_render_queue_structures_on_clear(
		HRoot self,
		_bool value);

	// TODO addSceneManagerFactory
	// TODO removeSceneManagerFactory
	// TODO getSceneManagerMetaData
	// TODO getSceneManagerMetaDataIterator

	__export HSceneManager __entry root_create_scenemanager_by_typename(
		HRoot self,
		const _string typeName);

	__export HSceneManager __entry root_create_scenemanager_by_typename2(
		HRoot self,
		const _string typeName,
		const _string instanceName);

	__export HSceneManager __entry root_create_scenemanager_by_type(
		HRoot self,
		_uint type);

	__export HSceneManager __entry root_create_scenemanager_by_type2(
		HRoot self,
		_uint type,
		const _string instanceName);

	/** NEW */
	__export void __entry root_destroy_scenemanager(
		HRoot self,
		HSceneManager sceneManager);

	/** NEW */
	__export HSceneManager __entry root_get_scenemanager(
		HRoot self,
		const _string instanceName);

	/** NEW */
	__export _bool __entry root_has_scenemanager(
		HRoot self,
		const _string instanceName);

	// TODO getSceneManagerIterator

	/** NEW */
	__export HTextureManager __entry root_get_texturemanager(
		HRoot self);

	/** NEW */
	__export HMeshManager __entry root_get_meshmanager(
		HRoot self);

	/** NEW */
	__export const _string __entry root_get_error_description(
		HRoot self,
		Int64 errorNumber);

	__export void __entry root_add_framelistener(
		HRoot self,
		HFrameListener listener);

	__export void __entry root_remove_framelistener(
		HRoot self,
		HFrameListener listener);

	/** NEW */
	__export void __entry root_queue_end_rendering(
		HRoot self);

	__export void __entry root_start_rendering(
		HRoot self);

	/** NEW */
	__export _bool __entry root_render_one_frame(
		HRoot self);

	/** NEW */
	__export _bool __entry root_render_one_frame_with_time(
		HRoot self,
		_float timeSinceLastFrame);

	/** NEW */
	__export void __entry root_shutdown(
		HRoot self);

	// TODO addResourceLocation
	// TODO removeResourceLocation
	// TODO createFileStream
	// TODO openFileStream
	// TODO convertColourValue
	
	__export HRenderWindow __entry root_get_auto_created_window(
		HRoot self);

	__export HRenderWindow __entry root_create_renderwindow(
		HRoot self,
		const _string name,
		_uint width, _uint height,
		_bool fullscreen);

	__export HRenderWindow __entry root_create_renderwindow_with_params(
		HRoot self,
		const _string name,
		_uint width, _uint height,
		_bool fullscreen,
		HNameValuePairList pairList);

	// TODO createRenderWindows
	// TODO detachRenderTarget
	// TODO getRenderTarget

	__export void __entry root_load_plugin(
		HRoot self,
		const char *pluginName);

	__export void __entry root_unload_plugin(
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
	__export _ulong __entry root_get_next_frame_number(
		HRoot self);

	/** NEW */
	__export HSceneManager root_get_current_scenemanager(
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
	__export void __entry root_clear_event_times(
		HRoot self);

	/** NEW */
	__export void __entry root_set_frame_smoothing_period(
		HRoot self,
		_float period);

	/** NEW */
	__export _float __entry root_get_frame_smoothing_period(
		HRoot self);

	// TODO addMovableObjectFactory
	// TODO removeMovableObjectFactory

	/** NEW */
	__export _bool __entry root_has_movable_object_factory(
		HRoot self,
		const _string typeName);

	// TODO getMovableObjectFactory
	// TODO _allocateNextMovableObjectTypeFlag
	// TODO getMovableObjectFactoryIterator

	/** NEW */
	__export _uint __entry root_get_display_monitor_count(
		HRoot self);

	// TODO getWorkQueue
	// TODO setWorkQueue


	/*
	 * Static methods
	 */

	__export HRoot __entry root_get_singleton();

}


#endif // OGREROOT_H

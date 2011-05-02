#include "Root.h"
#include "CustomFrameListener.h"
#include "RenderingEnumerators.h"
#include "TypeConvert.h"
#include <Ogre.h>

using namespace invision;

/*
 * Creation and destruction
 */

INV_EXPORT HRoot INV_CALL root_new(const _string pluginFilename, const _string configFilename)
{
	return new Ogre::Root(pluginFilename, configFilename);
}

INV_EXPORT HRoot INV_CALL root_new_with_log(const _string pluginFilename, const _string configFilename, const _string logFilename)
{
	return new Ogre::Root(pluginFilename, configFilename, logFilename);
}

INV_EXPORT void INV_CALL root_delete(HRoot self)
{
	delete asRoot(self);
}


/*
 * Methods
 */

INV_EXPORT void INV_CALL root_save_config(HRoot self)
{
	asRoot(self)->saveConfig();
}

INV_EXPORT _bool INV_CALL root_restore_config(HRoot self)
{
	return asRoot(self)->restoreConfig() ? TRUE : FALSE;
}

INV_EXPORT _bool INV_CALL root_show_config_dialog(HRoot self)
{
	return asRoot(self)->showConfigDialog() ? TRUE : FALSE;
}

INV_EXPORT HRenderSystem INV_CALL root_get_rendersystem_by_name(
	HRoot self,
	const _string name)
{
	return asRoot(self)->getRenderSystemByName(name);
}

INV_EXPORT HRenderWindow INV_CALL root_initialise_with_title_and_cap(
	HRoot self,
	_bool autoCreateWindow,
	const _string title,
	const _string capabilitiesConfig)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE, title, capabilitiesConfig);
}

INV_EXPORT HRenderWindow INV_CALL root_initialise_with_title(HRoot self, _bool autoCreateWindow, const _string title)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE, title);
}

INV_EXPORT HRenderWindow INV_CALL root_initialise(HRoot self, _bool autoCreateWindow)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE);
}

INV_EXPORT void INV_CALL root_destroy_scenemanager(
	HRoot self,
	HSceneManager sceneManager)
{
	asRoot(self)->destroySceneManager((Ogre::SceneManager*)sceneManager);
}

INV_EXPORT HSceneManager INV_CALL root_get_scenemanager(
	HRoot self,
	const _string instanceName)
{
	return asRoot(self)->getSceneManager(instanceName);
}

INV_EXPORT _bool INV_CALL root_has_scenemanager(
	HRoot self,
	const _string instanceName)
{
	return toBool(asRoot(self)->hasSceneManager(instanceName));
}

INV_EXPORT HTextureManager INV_CALL root_get_texturemanager(
	HRoot self)
{
	return asRoot(self)->getTextureManager();
}

INV_EXPORT HMeshManager INV_CALL root_get_meshmanager(
	HRoot self)
{
	return asRoot(self)->getMeshManager();
}

INV_EXPORT HRenderWindow INV_CALL root_get_auto_created_window(HRoot self)
{
	return asRoot(self)->getAutoCreatedWindow();
}

INV_EXPORT _bool INV_CALL root_is_initialised(HRoot self)
{
	return asRoot(self)->isInitialised();
}

INV_EXPORT void INV_CALL root_start_rendering(HRoot self)
{
	asRoot(self)->startRendering();
}

INV_EXPORT void INV_CALL root_add_framelistener(HRoot self, HFrameListener listener)
{
	asRoot(self)->addFrameListener(asCustomFrameListener(listener));
}

INV_EXPORT void INV_CALL root_remove_framelistener(HRoot self, HFrameListener listener)
{
	asRoot(self)->removeFrameListener(asCustomFrameListener(listener));
}

INV_EXPORT void INV_CALL root_load_plugin(HRoot self, const char *pluginName)
{
	asRoot(self)->loadPlugin(pluginName);
}

INV_EXPORT void INV_CALL root_unload_plugin(HRoot self, const char *pluginName)
{
	asRoot(self)->unloadPlugin(pluginName);
}

INV_EXPORT HEnumerator INV_CALL root_get_available_renderers(HRoot self)
{
	Ogre::RenderSystemList list = asRoot(self)->getAvailableRenderers();

	return new RenderSystemEnumerator(list);
}

/* NEW ********************************************************************************************/

INV_EXPORT _bool INV_CALL root_get_remove_render_queue_structures_on_clear(HRoot self)
{
	bool result = asRoot(self)->getRemoveRenderQueueStructuresOnClear();

	return toBool(result);
}

INV_EXPORT void INV_CALL root_set_remove_render_queue_structures_on_clear(HRoot self, _bool value)
{
	asRoot(self)->setRemoveRenderQueueStructuresOnClear(fromBool(value));
}

INV_EXPORT void INV_CALL root_shutdown(HRoot self)
{
	asRoot(self)->shutdown();
}

INV_EXPORT _bool INV_CALL root_render_one_frame(HRoot self)
{
	bool result = asRoot(self)->renderOneFrame();
	
	return toBool(result);
}
INV_EXPORT _bool INV_CALL root_render_one_frame_with_time(HRoot self, _float timeSinceLastFrame)
{
	bool result = asRoot(self)->renderOneFrame(timeSinceLastFrame);
	
	return toBool(result);
}

INV_EXPORT HRenderWindow INV_CALL root_create_renderwindow(
	HRoot self,
	const _string name,
	_uint width, _uint height,
	_bool fullscreen)
{
	return asRoot(self)->createRenderWindow(name, width, height, fromBool(fullscreen));
}

INV_EXPORT HRenderWindow INV_CALL root_create_renderwindow_with_params(
	HRoot self,
	const _string name,
	_uint width, _uint height,
	_bool fullscreen,
	HNameValuePairList pairList)
{
	return asRoot(self)->createRenderWindow(
		name, 
		width, height, 
		fromBool(fullscreen),
		asNameValuePairList(pairList));
}

INV_EXPORT _ulong INV_CALL root_get_next_frame_number(HRoot self)
{
	return asRoot(self)->getNextFrameNumber();
}

INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_typename(
	HRoot self, 
	const _string typeName)
{
	return asRoot(self)->createSceneManager(typeName);
}

INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_typename2(
	HRoot self, 
	const _string typeName, 
	const _string instanceName)
{
	return asRoot(self)->createSceneManager(typeName, instanceName);
}

INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_type(
	HRoot self, 
	_uint type)
{
	return asRoot(self)->createSceneManager(type);
}

INV_EXPORT HSceneManager INV_CALL root_create_scenemanager_by_type2(
	HRoot self, 
	_uint type, 
	const _string instanceName)
{
	return asRoot(self)->createSceneManager(type, instanceName);
}

INV_EXPORT const _string INV_CALL root_get_error_description(HRoot self, Int64 errorNumber)
{
	return asRoot(self)->getErrorDescription((long)errorNumber).c_str();
}

INV_EXPORT void INV_CALL root_queue_end_rendering(HRoot self)
{
	asRoot(self)->queueEndRendering();
}

INV_EXPORT void INV_CALL root_clear_event_times(HRoot self)
{
	asRoot(self)->clearEventTimes();
}

INV_EXPORT void INV_CALL root_set_frame_smoothing_period(HRoot self, _float period)
{
	asRoot(self)->setFrameSmoothingPeriod(period);
}

INV_EXPORT _float INV_CALL root_get_frame_smoothing_period(HRoot self)
{
	return asRoot(self)->getFrameSmoothingPeriod();
}

INV_EXPORT _bool INV_CALL root_has_movable_object_factory(HRoot self, const _string typeName)
{
	bool result = asRoot(self)->hasMovableObjectFactory(typeName);
	
	return toBool(result);
}

INV_EXPORT _uint INV_CALL root_get_display_monitor_count(HRoot self)
{
	return asRoot(self)->getDisplayMonitorCount();
}


/*
 * Static methods
 */

INV_EXPORT HRoot INV_CALL root_get_singleton()
{
	return Ogre::Root::getSingletonPtr();
}

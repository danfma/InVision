#include "Root.h"
#include "CustomFrameListener.h"
#include "RenderingEnumerators.h"
#include "TypeConvert.h"
#include <Ogre.h>

using namespace invision;

/*
 * Creation and destruction
 */

__export HRoot __entry root_new(const _string pluginFilename, const _string configFilename)
{
	return new Ogre::Root(pluginFilename, configFilename);
}

__export HRoot __entry root_new_with_log(const _string pluginFilename, const _string configFilename, const _string logFilename)
{
	return new Ogre::Root(pluginFilename, configFilename, logFilename);
}

__export void __entry root_delete(HRoot self)
{
	delete asRoot(self);
}


/*
 * Methods
 */

__export void __entry root_save_config(HRoot self)
{
	asRoot(self)->saveConfig();
}

__export _bool __entry root_restore_config(HRoot self)
{
	return asRoot(self)->restoreConfig() ? TRUE : FALSE;
}

__export _bool __entry root_show_config_dialog(HRoot self)
{
	return asRoot(self)->showConfigDialog() ? TRUE : FALSE;
}

__export HRenderSystem __entry root_get_rendersystem_by_name(
	HRoot self,
	const _string name)
{
	return asRoot(self)->getRenderSystemByName(name);
}

__export HRenderWindow __entry root_initialise_with_title_and_cap(
	HRoot self,
	_bool autoCreateWindow,
	const _string title,
	const _string capabilitiesConfig)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE, title, capabilitiesConfig);
}

__export HRenderWindow __entry root_initialise_with_title(HRoot self, _bool autoCreateWindow, const _string title)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE, title);
}

__export HRenderWindow __entry root_initialise(HRoot self, _bool autoCreateWindow)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE);
}

__export void __entry root_destroy_scenemanager(
	HRoot self,
	HSceneManager sceneManager)
{
	asRoot(self)->destroySceneManager((Ogre::SceneManager*)sceneManager);
}

__export HSceneManager __entry root_get_scenemanager(
	HRoot self,
	const _string instanceName)
{
	return asRoot(self)->getSceneManager(instanceName);
}

__export _bool __entry root_has_scenemanager(
	HRoot self,
	const _string instanceName)
{
	return toBool(asRoot(self)->hasSceneManager(instanceName));
}

__export HTextureManager __entry root_get_texturemanager(
	HRoot self)
{
	return asRoot(self)->getTextureManager();
}

__export HMeshManager __entry root_get_meshmanager(
	HRoot self)
{
	return asRoot(self)->getMeshManager();
}

__export HRenderWindow __entry root_get_auto_created_window(HRoot self)
{
	return asRoot(self)->getAutoCreatedWindow();
}

__export _bool __entry root_is_initialised(HRoot self)
{
	return asRoot(self)->isInitialised();
}

__export void __entry root_start_rendering(HRoot self)
{
	asRoot(self)->startRendering();
}

__export void __entry root_add_framelistener(HRoot self, HFrameListener listener)
{
	asRoot(self)->addFrameListener(asCustomFrameListener(listener));
}

__export void __entry root_remove_framelistener(HRoot self, HFrameListener listener)
{
	asRoot(self)->removeFrameListener(asCustomFrameListener(listener));
}

__export void __entry root_load_plugin(HRoot self, const char *pluginName)
{
	asRoot(self)->loadPlugin(pluginName);
}

__export void __entry root_unload_plugin(HRoot self, const char *pluginName)
{
	asRoot(self)->unloadPlugin(pluginName);
}

__export HEnumerator __entry root_get_available_renderers(HRoot self)
{
	Ogre::RenderSystemList list = asRoot(self)->getAvailableRenderers();

	return new RenderSystemEnumerator(list);
}

/* NEW ********************************************************************************************/

__export _bool __entry root_get_remove_render_queue_structures_on_clear(HRoot self)
{
	bool result = asRoot(self)->getRemoveRenderQueueStructuresOnClear();

	return toBool(result);
}

__export void __entry root_set_remove_render_queue_structures_on_clear(HRoot self, _bool value)
{
	asRoot(self)->setRemoveRenderQueueStructuresOnClear(fromBool(value));
}

__export void __entry root_shutdown(HRoot self)
{
	asRoot(self)->shutdown();
}

__export _bool __entry root_render_one_frame(HRoot self)
{
	bool result = asRoot(self)->renderOneFrame();
	
	return toBool(result);
}
__export _bool __entry root_render_one_frame_with_time(HRoot self, _float timeSinceLastFrame)
{
	bool result = asRoot(self)->renderOneFrame(timeSinceLastFrame);
	
	return toBool(result);
}

__export HRenderWindow __entry root_create_renderwindow(
	HRoot self,
	const _string name,
	_uint width, _uint height,
	_bool fullscreen)
{
	return asRoot(self)->createRenderWindow(name, width, height, fromBool(fullscreen));
}

__export HRenderWindow __entry root_create_renderwindow_with_params(
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

__export _ulong __entry root_get_next_frame_number(HRoot self)
{
	return asRoot(self)->getNextFrameNumber();
}

__export HSceneManager __entry root_create_scenemanager_by_typename(
	HRoot self, 
	const _string typeName)
{
	return asRoot(self)->createSceneManager(typeName);
}

__export HSceneManager __entry root_create_scenemanager_by_typename2(
	HRoot self, 
	const _string typeName, 
	const _string instanceName)
{
	return asRoot(self)->createSceneManager(typeName, instanceName);
}

__export HSceneManager __entry root_create_scenemanager_by_type(
	HRoot self, 
	_uint type)
{
	return asRoot(self)->createSceneManager(type);
}

__export HSceneManager __entry root_create_scenemanager_by_type2(
	HRoot self, 
	_uint type, 
	const _string instanceName)
{
	return asRoot(self)->createSceneManager(type, instanceName);
}

__export const _string __entry root_get_error_description(HRoot self, Int64 errorNumber)
{
	return asRoot(self)->getErrorDescription((long)errorNumber).c_str();
}

__export void __entry root_queue_end_rendering(HRoot self)
{
	asRoot(self)->queueEndRendering();
}

__export void __entry root_clear_event_times(HRoot self)
{
	asRoot(self)->clearEventTimes();
}

__export void __entry root_set_frame_smoothing_period(HRoot self, _float period)
{
	asRoot(self)->setFrameSmoothingPeriod(period);
}

__export _float __entry root_get_frame_smoothing_period(HRoot self)
{
	return asRoot(self)->getFrameSmoothingPeriod();
}

__export _bool __entry root_has_movable_object_factory(HRoot self, const _string typeName)
{
	bool result = asRoot(self)->hasMovableObjectFactory(typeName);
	
	return toBool(result);
}

__export _uint __entry root_get_display_monitor_count(HRoot self)
{
	return asRoot(self)->getDisplayMonitorCount();
}


/*
 * Static methods
 */

__export HRoot __entry root_get_singleton()
{
	return Ogre::Root::getSingletonPtr();
}

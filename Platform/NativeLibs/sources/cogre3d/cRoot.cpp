#include "cOgre.h"

/**
 * Method: Root::checkWindowMessages
 */
INV_EXPORT void
INV_CALL root_check_window_messages(InvHandle self)
{
	Ogre::WindowEventUtilities::messagePump();
}

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m1()
{
	Ogre::Root* root = new Ogre::Root();

	return createHandle<Ogre::Root>(root);
}

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m2(_string pluginFilename)
{
	return createHandle<Ogre::Root>(new Ogre::Root(pluginFilename));
}

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m3(_string pluginFilename, _string configFilename)
{
	return createHandle<Ogre::Root>(new Ogre::Root(pluginFilename, configFilename));
}

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m4(_string pluginFilename, _string configFilename, _string logFilename)
{
	return createHandle<Ogre::Root>(new Ogre::Root(pluginFilename, configFilename, logFilename));
}

/**
 * Method: Root::~Root
 */
INV_EXPORT void
INV_CALL delete_root(InvHandle self)
{
	destroyHandle(self);
}

/**
 * Method: Root::saveConfig
 */
INV_EXPORT void
INV_CALL root_save_config(InvHandle self)
{
	asRoot(self)->saveConfig();
}

/**
 * Method: Root::restoreConfig
 */
INV_EXPORT _bool
INV_CALL root_restore_config(InvHandle self)
{
	return fromBool(asRoot(self)->restoreConfig());
}

/**
 * Method: Root::showConfigDialog
 */
INV_EXPORT _bool
INV_CALL root_show_config_dialog(InvHandle self)
{
	return fromBool(asRoot(self)->showConfigDialog());
}

/**
 * Method: Root::addRenderSystem
 */
INV_EXPORT void
INV_CALL root_add_render_system(InvHandle self, InvHandle renderSystem)
{
	throws_not_implemented();
}

/**
 * Method: Root::getRenderSystemByName
 */
INV_EXPORT _any
INV_CALL root_get_render_system_by_name(InvHandle self, _string name)
{
	throws_not_implemented();
	return NULL;
}

/**
 * Method: Root::setRenderSystem
 */
INV_EXPORT void
INV_CALL root_set_render_system(InvHandle self, InvHandle renderSystem)
{
	throws_not_implemented();
}

/**
 * Method: Root::getRenderSystem
 */
INV_EXPORT InvHandle
INV_CALL root_get_render_system(InvHandle self)
{
	throws_not_implemented();
	return 0;
}

/**
 * Method: Root::initialize
 */
INV_EXPORT InvHandle
INV_CALL root_initialize_m1(InvHandle self, _bool autoCreateWindow)
{
	return getOrCreateReference<Ogre::RenderWindow>(
				asRoot(self)->initialise(
					fromBool(autoCreateWindow)));
}

/**
 * Method: Root::initialize
 */
INV_EXPORT InvHandle
INV_CALL root_initialize_m2(InvHandle self, _bool autoCreateWindow, _string windowTitle)
{
	return getOrCreateReference<Ogre::RenderWindow>(
				asRoot(self)->initialise(
					fromBool(autoCreateWindow),
					windowTitle));
}

/**
 * Method: Root::initialize
 */
INV_EXPORT InvHandle
INV_CALL root_initialize_m3(InvHandle self, _bool autoCreateWindow, _string windowTitle, _string customCapabilities)
{
	return getOrCreateReference<Ogre::RenderWindow>(
				asRoot(self)->initialise(
					fromBool(autoCreateWindow),
					windowTitle,
					customCapabilities));
}

/**
 * Method: Root::isInitialized
 */
INV_EXPORT _bool
INV_CALL root_is_initialized(InvHandle self)
{
	return toBool(asRoot(self)->isInitialised());
}

/**
 * Method: Root::useCustomRenderSystemCapabilities
 */
INV_EXPORT void
INV_CALL root_use_custom_render_system_capabilities(InvHandle self, InvHandle capabilities)
{
	throws_not_implemented();
}

/**
 * Method: Root::getRemoveRenderQueueStructuresOnClear
 */
INV_EXPORT _bool
INV_CALL root_get_remove_render_queue_structures_on_clear(InvHandle self)
{
	throws_not_implemented();
	return FALSE;
}

/**
 * Method: Root::setRemoveRenderQueueStructuresOnClear
 */
INV_EXPORT void
INV_CALL root_set_remove_render_queue_structures_on_clear(InvHandle self, _bool value)
{
	throws_not_implemented();
}

/**
 * Method: Root::addSceneManagerFactory
 */
INV_EXPORT void
INV_CALL root_add_scene_manager_factory(InvHandle self, InvHandle factory)
{
	throws_not_implemented();
}

/**
 * Method: Root::removeSceneManagerFactory
 */
INV_EXPORT void
INV_CALL root_remove_scene_manager_factory(InvHandle self, InvHandle factory)
{
	throws_not_implemented();
}

/**
 * Method: Root::createSceneManager
 */
INV_EXPORT InvHandle
INV_CALL root_create_scene_manager_m1(InvHandle self, SCENE_TYPE sceneType)
{
	return getOrCreateReference<Ogre::SceneManager>(
				asRoot(self)->createSceneManager(
					(Ogre::SceneTypeMask)sceneType));
}

/**
 * Method: Root::createSceneManager
 */
INV_EXPORT InvHandle
INV_CALL root_create_scene_manager_m2(InvHandle self, SCENE_TYPE sceneType, _string instanceName)
{
	return getOrCreateReference<Ogre::SceneManager>(
				asRoot(self)->createSceneManager(
					(Ogre::SceneTypeMask)sceneType,
					instanceName));
}

/**
 * Method: Root::createRenderWindow
 */
INV_EXPORT InvHandle
INV_CALL root_create_render_window_m1(InvHandle self, _string name, _uint width, _uint height, _bool fullscreen)
{
	return getOrCreateReference<Ogre::RenderWindow>(
				asRoot(self)->createRenderWindow(name, width, height, fromBool(fullscreen)));
}

/**
 * Method: Root::createRenderWindow
 */
INV_EXPORT InvHandle
INV_CALL root_create_render_window_m2(InvHandle self, _string name, _uint width, _uint height, _bool fullscreen, NameValuePairList list)
{
	Ogre::NameValuePairList parameters;

	for (_uint i = 0; i < list.count; i++) {
		NameValuePair pair = list.pairs[i];
		Ogre::NameValuePairList::value_type item(pair.name, pair.value);

		parameters.insert(item);
	}

	return getOrCreateReference<Ogre::RenderWindow>(
				asRoot(self)->createRenderWindow(name, width, height, fromBool(fullscreen), &parameters));
}

/**
 * Method: Root::loadPlugin
 */
INV_EXPORT void
INV_CALL root_load_plugin(InvHandle self, _string plugin)
{
	asRoot(self)->loadPlugin(plugin);
}

/**
 * Method: Root::unloadPlugin
 */
INV_EXPORT void
INV_CALL root_unload_plugin(InvHandle self, _string plugin)
{
	asRoot(self)->unloadPlugin(plugin);
}

/**
 * Method: Root::renderOneFrame
 */
INV_EXPORT _bool
INV_CALL root_render_one_frame(InvHandle self, _bool clearWindowMessages)
{
	if (clearWindowMessages == TRUE)
		Ogre::WindowEventUtilities::messagePump();

	return toBool(asRoot(self)->renderOneFrame());
}

INV_EXPORT void
INV_CALL root_add_frame_listener(InvHandle self, InvHandle listener)
{
	asRoot(self)->addFrameListener(asFrameListener(listener));
}

INV_EXPORT void
INV_CALL root_remove_frame_listener(InvHandle self, InvHandle listener)
{
	asRoot(self)->removeFrameListener(asFrameListener(listener));
}

/**
 * Method: Root::getSingleton
 */
INV_EXPORT InvHandle
INV_CALL root_get_singleton()
{
	Ogre::Root* root = Ogre::Root::getSingletonPtr();

	return getOrCreateReference<Ogre::Root>(root);
}

INV_EXPORT void
INV_CALL root_start_rendering(InvHandle self)
{
	asRoot(self)->startRendering();
}

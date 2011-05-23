#include "cOgre.h"

using namespace Ogre;

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m1()
{
	Root* root = new Root();

	return createHandle<Root>(root);
}

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m2(_string pluginFilename)
{
	return createHandle<Root>(new Root(pluginFilename));
}

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m3(_string pluginFilename, _string configFilename)
{
	return createHandle<Root>(new Root(pluginFilename, configFilename));
}

/**
 * Method: Root::Root
 */
INV_EXPORT InvHandle
INV_CALL new_root_m4(_string pluginFilename, _string configFilename, _string logFilename)
{
	return createHandle<Root>(new Root(pluginFilename, configFilename, logFilename));
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
	return getOrCreateReference<RenderWindow>(asRoot(self)->initialise(toBool(autoCreateWindow)));
}

/**
 * Method: Root::initialize
 */
INV_EXPORT InvHandle
INV_CALL root_initialize_m2(InvHandle self, _bool autoCreateWindow, _string windowTitle)
{
	return getOrCreateReference<RenderWindow>(
				asRoot(self)->initialise(toBool(autoCreateWindow),
										 windowTitle));
}

/**
 * Method: Root::initialize
 */
INV_EXPORT InvHandle
INV_CALL root_initialize_m3(InvHandle self, _bool autoCreateWindow, _string windowTitle, _string customCapabilities)
{
	return getOrCreateReference<RenderWindow>(
				asRoot(self)->initialise(toBool(autoCreateWindow),
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
	return getOrCreateReference(
				asRoot(self)->createSceneManager(
					(SceneTypeMask)sceneType));
}

/**
 * Method: Root::createSceneManager
 */
INV_EXPORT InvHandle
INV_CALL root_create_scene_manager_m2(InvHandle self, SCENE_TYPE sceneType, _string instanceName)
{
	return getOrCreateReference(
				asRoot(self)->createSceneManager(
					(SceneTypeMask)sceneType,
					instanceName));
}

/**
 * Method: Root::getSingleton
 */
INV_EXPORT InvHandle
INV_CALL root_get_singleton()
{
	Root* root = Root::getSingletonPtr();

	return getOrCreateReference<Root>(root);
}

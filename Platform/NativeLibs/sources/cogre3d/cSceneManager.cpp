#include "cOgre.h"

using namespace Ogre;

/**
 * Method: SceneManager::clearScene
 */
INV_EXPORT void
INV_CALL scenemanager_clear_scene(InvHandle self)
{
	asSceneManager(self)->clearScene();
}

/**
 * Method: SceneManager::setAmbientLight
 */
INV_EXPORT void
INV_CALL scenemanager_set_ambient_light(InvHandle self, Color color)
{
	asSceneManager(self)->setAmbientLight(color_convert_to_ogre(color));
}

/**
 * Method: SceneManager::getAmbientLight
 */
INV_EXPORT Color
INV_CALL scenemanager_get_ambient_light(InvHandle self)
{
	ColourValue result = asSceneManager(self)->getAmbientLight();

	return color_convert_from_ogre(result);
}

/**
 * Method: SceneManager::createCamera
 */
INV_EXPORT InvHandle
INV_CALL scenemanager_create_camera(InvHandle self, _string name)
{
	return createReference<Camera>(
				asSceneManager(self)->createCamera(name));
}

/**
 * Method: SceneManager::createEntity
 */
INV_EXPORT InvHandle
INV_CALL scenemanager_create_entity_m1(InvHandle self, _string meshName)
{
	return createReference<Entity>(
				asSceneManager(self)->createEntity(meshName));
}

INV_EXPORT InvHandle
INV_CALL scenemanager_create_entity_m2(InvHandle self, _string entityName, _string meshName)
{
	return createReference<Entity>(
				asSceneManager(self)->createEntity(entityName, meshName));
}

/**
 * Method: SceneManager::getRootSceneNode
 */
INV_EXPORT InvHandle
INV_CALL scenemanager_get_root_scene_node(InvHandle self)
{
	return createReference<SceneNode>(
				asSceneManager(self)->getRootSceneNode());
}

/**
 * Method: SceneManager::createLight
 */
INV_EXPORT InvHandle
INV_CALL scenemanager_create_light_m1(InvHandle self)
{
	return createReference<Ogre::Light>(
				asSceneManager(self)->createLight());
}

/**
 * Method: SceneManager::createLight
 */
INV_EXPORT InvHandle
INV_CALL scenemanager_create_light_m2(InvHandle self, _string name)
{
	return createReference<Ogre::Light>(
				asSceneManager(self)->createLight(name));
}

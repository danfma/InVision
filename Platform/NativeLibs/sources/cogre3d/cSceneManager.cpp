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

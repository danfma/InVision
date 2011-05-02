#include "SceneManager.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT void INV_CALL scenemanager_delete(HSceneManager self)
{
	if (self == NULL)
		return;

	delete asSceneManager(self);
}

INV_EXPORT HCamera INV_CALL scenemanager_create_camera(HSceneManager self, const _string name)
{
	return asSceneManager(self)->createCamera(name);
}

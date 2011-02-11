#include "invision/rendering/SceneManager.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT void __ENTRY scenemanager_delete(HSceneManager self)
{
	if (self == NULL)
		return;

	delete asSceneManager(self);
}

__EXPORT HCamera __ENTRY scenemanager_create_camera(HSceneManager self, const char* name)
{
	return asSceneManager(self)->createCamera(name);
}

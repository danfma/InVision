#include "SceneManager.h"
#include "TypeConvert.h"

using namespace invision;

__export void __entry scenemanager_delete(HSceneManager self)
{
	if (self == NULL)
		return;

	delete asSceneManager(self);
}

__export HCamera __entry scenemanager_create_camera(HSceneManager self, const char* name)
{
	return asSceneManager(self)->createCamera(name);
}

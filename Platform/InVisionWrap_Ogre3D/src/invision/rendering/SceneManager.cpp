#include "invision/rendering/SceneManager.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT void __ENTRY ScnMngrDelete(HSceneManager self)
{
	if (self == NULL)
		return;

	delete asSceneManager(self);
}

__EXPORT HCamera __ENTRY ScnMngrCreateCamera(HSceneManager self, const char* name)
{
	return asSceneManager(self)->createCamera(name);
}

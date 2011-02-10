#include "invision/rendering/RenderSystem.h"
#include "invision/Util.h"

using namespace invision;

typedef Deleter<char*> CharArrayDeleter;

__EXPORT const char* __ENTRY RndrSysGetName(HRenderSystem self)
{
	const Ogre::String& name = asRenderSystem(self)->getName();

	return name.c_str();
}


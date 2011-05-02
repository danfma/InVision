#include "RenderSystem.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT const _string INV_CALL rendersystem_get_name(HRenderSystem self)
{
	const Ogre::String& name = asRenderSystem(self)->getName();

	return name.c_str();
}


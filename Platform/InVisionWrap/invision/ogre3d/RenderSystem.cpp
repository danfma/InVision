#include "RenderSystem.h"
#include "TypeConvert.h"

using namespace invision;

__export const char* __entry rendersystem_get_name(HRenderSystem self)
{
	const Ogre::String& name = asRenderSystem(self)->getName();

	return name.c_str();
}

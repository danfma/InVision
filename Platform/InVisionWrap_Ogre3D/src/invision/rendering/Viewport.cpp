#include "Viewport.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT ColorValue __ENTRY viewport_get_bgcolor(HViewport self)
{
	Ogre::ColourValue color = asViewport(self)->getBackgroundColour();

	return toColorValue(color);
}

__EXPORT void __ENTRY viewport_set_bgcolor(HViewport self, ColorValue color)
{
	asViewport(self)->setBackgroundColour(fromColorValue(color));
}

__EXPORT Int32 __ENTRY viewport_get_actual_width(HViewport self)
{
	return asViewport(self)->getActualWidth();
}

__EXPORT Int32 __ENTRY viewport_get_actual_height(HViewport self)
{
	return asViewport(self)->getActualHeight();
}

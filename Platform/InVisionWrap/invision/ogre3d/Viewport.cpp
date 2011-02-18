#include "Viewport.h"
#include "TypeConvert.h"

using namespace invision;

__export ColorValue __entry viewport_get_bgcolor(HViewport self)
{
	Ogre::ColourValue color = asViewport(self)->getBackgroundColour();

	return toColorValue(color);
}

__export void __entry viewport_set_bgcolor(HViewport self, ColorValue color)
{
	asViewport(self)->setBackgroundColour(fromColorValue(color));
}

__export Int32 __entry viewport_get_actual_width(HViewport self)
{
	return asViewport(self)->getActualWidth();
}

__export Int32 __entry viewport_get_actual_height(HViewport self)
{
	return asViewport(self)->getActualHeight();
}

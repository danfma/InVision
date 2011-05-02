#include "Viewport.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT ColorValue INV_CALL viewport_get_bgcolor(HViewport self)
{
	Ogre::ColourValue color = asViewport(self)->getBackgroundColour();

	return toColorValue(color);
}

INV_EXPORT void INV_CALL viewport_set_bgcolor(HViewport self, ColorValue color)
{
	Ogre::ColourValue c = fromColorValue(color);

	asViewport(self)->setBackgroundColour(c);
}

INV_EXPORT _int INV_CALL viewport_get_actual_width(HViewport self)
{
	return asViewport(self)->getActualWidth();
}

INV_EXPORT _int INV_CALL viewport_get_actual_height(HViewport self)
{
	return asViewport(self)->getActualHeight();
}

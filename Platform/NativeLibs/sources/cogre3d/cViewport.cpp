#include "cOgre.h"

/**
 * Method: Viewport::setBackgroundColor
 */
INV_EXPORT void
INV_CALL viewport_set_background_color(InvHandle self, Color color)
{
	asViewport(self)->setBackgroundColour(color_convert_to_ogre(color));
}

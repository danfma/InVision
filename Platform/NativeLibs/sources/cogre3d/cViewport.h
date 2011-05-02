#ifndef VIEWPORT_H
#define VIEWPORT_H

#include "cOgre.h"

extern "C"
{
	INV_EXPORT ColorValue INV_CALL viewport_get_bgcolor(HViewport self);
	INV_EXPORT void INV_CALL viewport_set_bgcolor(HViewport self, ColorValue color);

	INV_EXPORT _int INV_CALL viewport_get_actual_width(HViewport self);
	INV_EXPORT _int INV_CALL viewport_get_actual_height(HViewport self);
}

#endif // VIEWPORT_H

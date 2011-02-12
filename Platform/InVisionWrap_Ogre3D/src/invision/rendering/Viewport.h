#ifndef VIEWPORT_H
#define VIEWPORT_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT ColorValue __ENTRY viewport_get_bgcolor(HViewport self);
	__EXPORT void __ENTRY viewport_set_bgcolor(HViewport self, ColorValue color);

	__EXPORT Int32 __ENTRY viewport_get_actual_width(HViewport self);
	__EXPORT Int32 __ENTRY viewport_get_actual_height(HViewport self);
}

#endif // VIEWPORT_H

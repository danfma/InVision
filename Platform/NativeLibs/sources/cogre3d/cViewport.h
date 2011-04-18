#ifndef VIEWPORT_H
#define VIEWPORT_H

#include "cOgre.h"

extern "C"
{
	__export ColorValue __entry viewport_get_bgcolor(HViewport self);
	__export void __entry viewport_set_bgcolor(HViewport self, ColorValue color);

	__export _int __entry viewport_get_actual_width(HViewport self);
	__export _int __entry viewport_get_actual_height(HViewport self);
}

#endif // VIEWPORT_H

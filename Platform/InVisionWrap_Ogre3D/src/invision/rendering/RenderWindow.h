#ifndef RENDERWINDOW_H
#define RENDERWINDOW_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT UInt32 __ENTRY renderwindow_get_width(HRenderWindow self);
	__EXPORT UInt32 __ENTRY renderwindow_get_height(HRenderWindow self);

	__EXPORT HViewport __ENTRY renderwindow_add_viewport(
		HRenderWindow self,
		HCamera camera,
		int zOrder,
		float left,
		float top,
		float width,
		float height);
}

#endif // RENDERWINDOW_H

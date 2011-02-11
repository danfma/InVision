#ifndef RENDERWINDOW_H
#define RENDERWINDOW_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT UInt32 __ENTRY renderwindow_get_width(HRenderWindow self);
	__EXPORT UInt32 __ENTRY renderwindow_get_height(HRenderWindow self);
}

#endif // RENDERWINDOW_H

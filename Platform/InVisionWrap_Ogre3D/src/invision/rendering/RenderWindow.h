#ifndef RENDERWINDOW_H
#define RENDERWINDOW_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT UInt32 __ENTRY RndrWinGetWidth(HRenderWindow self);
	__EXPORT UInt32 __ENTRY RndrWinGetHeight(HRenderWindow self);
}

#endif // RENDERWINDOW_H

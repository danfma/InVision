#include "RenderWindow.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT UInt32 __ENTRY renderwindow_get_width(HRenderWindow self)
{
	return asRenderWindow(self)->getWidth();
}

__EXPORT UInt32 __ENTRY renderwindow_get_height(HRenderWindow self)
{
	return asRenderWindow(self)->getHeight();
}

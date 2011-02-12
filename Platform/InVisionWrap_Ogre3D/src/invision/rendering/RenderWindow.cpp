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

__EXPORT HViewport __ENTRY renderwindow_add_viewport(
	HRenderWindow self,
	HCamera camera,
	int zOrder,
	float left,
	float top,
	float width,
	float height)
{
	return asRenderWindow(self)->addViewport(
				asCamera(camera),
				zOrder,
				left, top,
				width, height);
}

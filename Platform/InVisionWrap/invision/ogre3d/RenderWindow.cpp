#include "RenderWindow.h"
#include "TypeConvert.h"

using namespace invision;

__export UInt32 __entry renderwindow_get_width(HRenderWindow self)
{
	return asRenderWindow(self)->getWidth();
}

__export UInt32 __entry renderwindow_get_height(HRenderWindow self)
{
	return asRenderWindow(self)->getHeight();
}

__export HViewport __entry renderwindow_add_viewport(
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

__export String __entry renderwindow_write_contents_to_timestamped_file(
	HRenderWindow self,
	ConstString prefix,
	ConstString suffix)
{
	Ogre::String s = asRenderWindow(self)->writeContentsToTimestampedFile(prefix, suffix);

	return copyString(s);
}

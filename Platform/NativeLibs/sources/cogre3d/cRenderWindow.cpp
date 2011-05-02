#include "RenderWindow.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT _uint INV_CALL ogre_renderwindow_get_width(HRenderWindow self)
{
	return asRenderWindow(self)->getWidth();
}

INV_EXPORT _uint INV_CALL ogre_renderwindow_get_height(HRenderWindow self)
{
	return asRenderWindow(self)->getHeight();
}

INV_EXPORT HViewport INV_CALL ogre_renderwindow_add_viewport(
	HRenderWindow self,
	HCamera camera,
	_int zOrder,
	_float left,
	_float top,
	_float width,
	_float height)
{
	return asRenderWindow(self)->addViewport(
				asCamera(camera),
				zOrder,
				left, top,
				width, height);
}

INV_EXPORT String INV_CALL ogre_renderwindow_write_contents_to_timestamped_file(
	HRenderWindow self,
	ConstString prefix,
	ConstString suffix)
{
	Ogre::String s = asRenderWindow(self)->writeContentsToTimestampedFile(prefix, suffix);

	return copyString(s);
}

INV_EXPORT void INV_CALL ogre_renderwindow_get_custom_attrib(
		HRenderWindow self,
		ConstString name,
		_any data)
{
	asRenderWindow(self)->getCustomAttribute(name, data);
}

INV_EXPORT FrameStats* INV_CALL ogre_get_statistics(HRenderWindow self)
{
	Ogre::RenderTarget::FrameStats f = asRenderWindow(self)->getStatistics();

	return new FrameStats(f);
}

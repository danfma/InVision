#ifndef RENDERWINDOW_H
#define RENDERWINDOW_H

#include "OgreCommon.h"

extern "C"
{
	INV_EXPORT _uint INV_CALL ogre_renderwindow_get_width(HRenderWindow self);
	INV_EXPORT _uint INV_CALL ogre_renderwindow_get_height(HRenderWindow self);

	INV_EXPORT HViewport INV_CALL ogre_renderwindow_add_viewport(
		HRenderWindow self,
		HCamera camera,
		_int zOrder,
		_float left,
		_float top,
		_float width,
		_float height);

	INV_EXPORT String INV_CALL ogre_renderwindow_write_contents_to_timestamped_file(
		HRenderWindow self,
		ConstString prefix,
		ConstString suffix);
	
	INV_EXPORT void INV_CALL ogre_renderwindow_get_custom_attrib(
		HRenderWindow self,
		ConstString name,
		_any data);

	INV_EXPORT FrameStats* INV_CALL ogre_renderwindow_get_statistics(HRenderWindow self);
}

#endif // RENDERWINDOW_H

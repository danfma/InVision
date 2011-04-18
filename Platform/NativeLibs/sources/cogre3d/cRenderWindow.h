#ifndef RENDERWINDOW_H
#define RENDERWINDOW_H

#include "OgreCommon.h"

extern "C"
{
	__export _uint __entry ogre_renderwindow_get_width(HRenderWindow self);
	__export _uint __entry ogre_renderwindow_get_height(HRenderWindow self);

	__export HViewport __entry ogre_renderwindow_add_viewport(
		HRenderWindow self,
		HCamera camera,
		_int zOrder,
		_float left,
		_float top,
		_float width,
		_float height);

	__export String __entry ogre_renderwindow_write_contents_to_timestamped_file(
		HRenderWindow self,
		ConstString prefix,
		ConstString suffix);
	
	__export void __entry ogre_renderwindow_get_custom_attrib(
		HRenderWindow self,
		ConstString name,
		_any data);

	__export FrameStats* __entry ogre_renderwindow_get_statistics(HRenderWindow self);
}

#endif // RENDERWINDOW_H

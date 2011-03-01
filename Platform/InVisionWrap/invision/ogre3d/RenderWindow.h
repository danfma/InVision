#ifndef RENDERWINDOW_H
#define RENDERWINDOW_H

#include "OgreCommon.h"

extern "C"
{
	__export UInt32 __entry ogre_renderwindow_get_width(HRenderWindow self);
	__export UInt32 __entry ogre_renderwindow_get_height(HRenderWindow self);

	__export HViewport __entry ogre_renderwindow_add_viewport(
		HRenderWindow self,
		HCamera camera,
		int zOrder,
		float left,
		float top,
		float width,
		float height);

	__export String __entry ogre_renderwindow_write_contents_to_timestamped_file(
		HRenderWindow self,
		ConstString prefix,
		ConstString suffix);
	
	__export void __entry ogre_renderwindow_get_custom_attrib(
		HRenderWindow self,
		ConstString name,
		Any data);

	__export FrameStats* __entry ogre_renderwindow_get_statistics(HRenderWindow self);
}

#endif // RENDERWINDOW_H

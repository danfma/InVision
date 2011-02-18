#ifndef RENDERWINDOW_H
#define RENDERWINDOW_H

#include "invision/Common.h"

extern "C"
{
	__export UInt32 __entry renderwindow_get_width(HRenderWindow self);
	__export UInt32 __entry renderwindow_get_height(HRenderWindow self);

	__export HViewport __entry renderwindow_add_viewport(
		HRenderWindow self,
		HCamera camera,
		int zOrder,
		float left,
		float top,
		float width,
		float height);

	__export String __entry renderwindow_write_contents_to_timestamped_file(
		HRenderWindow self,
		ConstString prefix,
		ConstString suffix);
}

#endif // RENDERWINDOW_H

#ifndef MOUSESTATE_H
#define MOUSESTATE_H

#include "invision/Common.h"
#include "Common.h"

extern "C"
{
	__export Int32 __entry ois_mousestate_get_width(HMouseState self);
	__export void __entry ois_mousestate_set_width(HMouseState self, Int32 value);

	__export Int32 __entry ois_mousestate_get_height(HMouseState self);
	__export void __entry ois_mousestate_set_height(HMouseState self, Int32 value);

	__export Int32 __entry ois_mousestate_get_buttons(HMouseState self);

	__export HInputAxis __entry ois_mousestate_get_axis_x(HMouseState self);
	__export HInputAxis __entry ois_mousestate_get_axis_y(HMouseState self);
	__export HInputAxis __entry ois_mousestate_get_axis_z(HMouseState self);

	__export Bool __entry ois_mousestate_is_button_down(HMouseState self, Int32 button);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::MouseState* asMouseState(HMouseState self)
		{
			return (OIS::MouseState*)self;
		}
	}
}

#endif

#endif // MOUSESTATE_H

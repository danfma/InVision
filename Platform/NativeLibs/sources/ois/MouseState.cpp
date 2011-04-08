#include "MouseState.h"

using namespace invision::ois;

__export Int32 __entry ois_mousestate_get_width(HMouseState self)
{
	return asMouseState(self)->width;
}

__export void __entry ois_mousestate_set_width(HMouseState self, Int32 value)
{
	asMouseState(self)->width = value;
}

__export Int32 __entry ois_mousestate_get_height(HMouseState self)
{
	return asMouseState(self)->height;
}

__export void __entry ois_mousestate_set_height(HMouseState self, Int32 value)
{
	asMouseState(self)->height = value;
}

__export Int32 __entry ois_mousestate_get_buttons(HMouseState self)
{
	return asMouseState(self)->buttons;
}

__export HInputAxis __entry ois_mousestate_get_axis_x(HMouseState self)
{
	return &(asMouseState(self)->X);
}

__export HInputAxis __entry ois_mousestate_get_axis_y(HMouseState self)
{
	return &(asMouseState(self)->Y);
}

__export HInputAxis __entry ois_mousestate_get_axis_z(HMouseState self)
{
	return &(asMouseState(self)->Z);
}

__export Bool __entry ois_mousestate_is_button_down(HMouseState self, Int32 button)
{
	return toBool(asMouseState(self)->buttonDown((OIS::MouseButtonID)button));
}

#include "cMouseState.h"

__export MouseStateExtended __entry ois_mousestate_new_from(HMouseState self)
{
	OIS::MouseState* state = asMouseState(self);

	MouseStateExtended ex;
	ex.handle = state;
	ex.buttons = (_int*) &state->buttons;
	ex.width = (_int*) &state->width;
	ex.height = (_int*) &state->height;
	ex.x = ois_axis_new_from(&state->X);
	ex.y = ois_axis_new_from(&state->Y);
	ex.z = ois_axis_new_from(&state->Z);

	return ex;
}

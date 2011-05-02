#include "cMouseState.h"

INV_EXPORT MouseStateDescriptor
INV_CALL ois_descriptor_of_mousestate(_any self, OIS::MouseState* state)
{
	MouseStateDescriptor descriptor;
	descriptor.handle = self;
	descriptor.buttons = &state->buttons;
	descriptor.width = &state->width;
	descriptor.height = &state->height;
	descriptor.x = ois_descriptor_of_axis(&state->X, &state->X);
	descriptor.y = ois_descriptor_of_axis(&state->Y, &state->Y);
	descriptor.z = ois_descriptor_of_axis(&state->Z, &state->Z);

	return descriptor;
}

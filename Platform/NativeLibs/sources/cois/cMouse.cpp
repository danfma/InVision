#include "cMouse.h"

INV_EXPORT MouseDescriptor
INV_CALL ois_descriptor_of_mouse(_any self, OIS::Mouse* mouse)
{
	OIS::MouseState* mouseState = const_cast<OIS::MouseState*>(&mouse->getMouseState());

	MouseDescriptor descriptor;
	descriptor.self = self;
	descriptor.mouseState = ois_descriptor_of_mousestate(mouseState, mouseState);

	return descriptor;
}

INV_EXPORT void
INV_CALL ois_mouse_set_event_callback(OIS::Mouse* self, CustomMouseListener* listener)
{
	self->setEventCallback(listener);
}

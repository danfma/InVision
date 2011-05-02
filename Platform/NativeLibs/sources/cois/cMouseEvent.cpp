#include "cMouseEvent.h"

INV_EXPORT MouseEventDescriptor
INV_CALL ois_descriptor_of_mouseevent(_any self, OIS::MouseEvent* event)
{
	OIS::MouseState* mouseState = const_cast<OIS::MouseState*>(&event->state);

	MouseEventDescriptor ex;
	ex.base = ois_descriptor_of_eventarg(self, event);
	ex.state = ois_descriptor_of_mousestate(mouseState, mouseState);

	return ex;
}

#include "cOIS.h"

MouseEventDescriptor descriptor_of_mouseevent(InvHandle handle)
{
	OIS::MouseEvent* mouseEvent = asMouseEvent(handle);

	MouseEventDescriptor descriptor;
	descriptor.base = descriptor_of_eventarg(handle);
	descriptor.mouseState = descriptor_of_mousestate(
				createReference<OIS::MouseState>(
					const_cast<OIS::MouseState*>(&mouseEvent->state)));

	return descriptor;
}

/**
 * Method: MouseEvent::MouseEvent
 */
INV_EXPORT InvHandle
INV_CALL new_mouseevent(MouseEventDescriptor* descriptor, InvHandle obj, InvHandle mouseState)
{
	OIS::Object* convertedObj = asObject(obj);
	OIS::MouseState* convertedMouseState = asMouseState(mouseState);

	OIS::MouseEvent* mouseEvent = new OIS::MouseEvent(convertedObj, *convertedMouseState);
	InvHandle handle = createHandle<OIS::MouseEvent>(mouseEvent);

	*descriptor = descriptor_of_mouseevent(handle);

	return handle;
}

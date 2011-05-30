#include "cOIS.h"

/**
 * Method: Mouse::setEventCallback
 */
INV_EXPORT void
INV_CALL mouse_set_event_callback(InvHandle self, InvHandle mouseListener)
{
	asMouse(self)->setEventCallback(asMouseListener(mouseListener));
}

/**
 * Method: Mouse::getEventCallback
 */
INV_EXPORT InvHandle
INV_CALL mouse_get_event_callback(InvHandle self)
{
	OIS::MouseListener* mouseListener = asMouse(self)->getEventCallback();

	return createReference<OIS::MouseListener>(mouseListener);
}

/**
 * Method: Mouse::getMouseState
 */
INV_EXPORT InvHandle
INV_CALL mouse_get_mouse_state(InvHandle self)
{
	OIS::MouseState& mouseState = const_cast<OIS::MouseState&>(asMouse(self)->getMouseState());

	return createReference<OIS::MouseState>(&mouseState);
}

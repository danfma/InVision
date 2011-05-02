#include "cCustomKeyEventListener.h"

INV_EXPORT CustomKeyListener*
INV_CALL ois_new_customkeylistener(
	KeyEventHandler pressedHandler,
	KeyEventHandler releasedHandler)
{
	CustomKeyListener* listener = new CustomKeyListener();
	listener->keyPressedHandler = pressedHandler;
	listener->keyReleasedHandler = releasedHandler;

	return listener;
}

INV_EXPORT void
INV_CALL ois_delete_customkeylistener(CustomKeyListener* self)
{
	if (self != NULL)
		return;

	delete self;
}

#include "cCustomMouseListener.h"

INV_EXPORT CustomMouseListener*
INV_CALL ois_new_custommouselistener(
	MouseMovedHandler movedHandler,
	MouseClickHandler pressHandler,
	MouseClickHandler releaseHandler)
{
	CustomMouseListener* listener = new CustomMouseListener();
	listener->movedHandler = movedHandler;
	listener->mousePressedHandler = pressHandler;
	listener->mouseReleasedHandler = releaseHandler;

	return listener;
}

INV_EXPORT void
INV_CALL ois_delete_customouselistener(CustomMouseListener* self)
{
	if (self == NULL)
		return;

	delete self;
}

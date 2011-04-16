#include "cCustomMouseListener.h"

__export HMouseListener __entry ois_custommouselistener_new(MouseMovedHandler movedHandler, MouseClickHandler pressHandler, MouseClickHandler releaseHandler)
{
	CustomMouseListener* listener = new CustomMouseListener();
	listener->movedHandler = movedHandler;
	listener->mousePressedHandler = pressHandler;
	listener->mouseReleasedHandler = releaseHandler;

	return listener;
}

__export void __entry ois_customouselistener_delete(HMouseListener self)
{
	if (self == NULL)
		return;

	delete (OIS::MouseListener*)self;
}

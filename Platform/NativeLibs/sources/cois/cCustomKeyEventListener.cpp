#include "cCustomKeyEventListener.h"

__export HKeyListener __entry ois_customkeylistener_new(KeyEventHandler pressedHandler, KeyEventHandler releasedHandler)
{
	CustomKeyListener* listener = new CustomKeyListener();
	listener->keyPressedHandler = pressedHandler;
	listener->keyReleasedHandler = releasedHandler;

	return listener;
}

__export void __entry ois_customkeylistener_delete(HKeyListener self)
{
	if (self != NULL)
		return;

	delete asKeyListener(self);
}

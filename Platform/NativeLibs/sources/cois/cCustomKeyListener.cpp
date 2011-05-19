#include "cOIS.h"
#include "cCustomKeyEventListener.h"

/**
 * Method: KeyListener::CustomKeyListener
 */
INV_EXPORT InvHandle
INV_CALL new_customkeylistener(KeyEventHandler keyPressed, KeyEventHandler keyReleased)
{
	CustomKeyListener* keyListener = new CustomKeyListener(keyPressed, keyReleased);

	return createHandle<CustomKeyListener>(keyListener);
}

/**
 * Method: KeyListener::~CustomKeyListener
 */
INV_EXPORT void
INV_CALL delete_customkeylistener(InvHandle self)
{
	destroyHandle(self);
}

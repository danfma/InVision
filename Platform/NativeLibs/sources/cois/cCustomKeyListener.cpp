#include "cOIS.h"
#include "cCustomKeyListener.h"

/**
 * Method: KeyListener::~KeyListener (OK)
 */
INV_EXPORT void
INV_CALL delete_keylistener(InvHandle self)
{
	destroyHandle(self);
}

/**
 * Method: KeyListener::CustomKeyListener
 */
INV_EXPORT InvHandle
INV_CALL new_customkeylistener(KeyEventHandler keyPressed, KeyEventHandler keyReleased)
{
	CustomKeyListener* keyListener = new CustomKeyListener(keyPressed, keyReleased);

	return createHandle<CustomKeyListener>(keyListener);
}

#ifndef CUSTOMKEYEVENTLISTENER_H
#define CUSTOMKEYEVENTLISTENER_H

#include "cOIS.h"

typedef bool (INV_CALL *KeyEventHandler)(InvHandle e);

class CustomKeyListener : public OIS::KeyListener
{
public:
	KeyEventHandler keyPressedHandler;
	KeyEventHandler keyReleasedHandler;

	bool keyPressed(const OIS::KeyEvent &arg)
	{
		bool result = true;

		if (keyPressedHandler != NULL) {
			OIS::KeyEvent* keyEvent = const_cast<OIS::KeyEvent*>(&arg);
			InvHandle keyHandle = createHandle<OIS::KeyEvent>(keyEvent);

			result = keyPressedHandler(keyHandle);
			removeHandle(keyHandle);
		}

		return result;
	}

	bool keyReleased(const OIS::KeyEvent &arg)
	{
		bool result = true;

		if (keyReleasedHandler != NULL) {
			OIS::KeyEvent* keyEvent = const_cast<OIS::KeyEvent*>(&arg);
			InvHandle keyHandle = createHandle<OIS::KeyEvent>(keyEvent);

			result = keyReleasedHandler(keyHandle);
			removeHandle(keyHandle);
		}

		return result;
	}
};

extern "C"
{
	INV_EXPORT CustomKeyListener*
	INV_CALL ois_new_customkeylistener(
		KeyEventHandler pressedHandler,
		KeyEventHandler releasedHandler);

	INV_EXPORT void
	INV_CALL ois_delete_customkeylistener(CustomKeyListener* self);

}

#endif // CUSTOMKEYEVENTLISTENER_H

#ifndef CUSTOMKEYEVENTLISTENER_H
#define CUSTOMKEYEVENTLISTENER_H

#include "cOIS.h"
#include "cKeyEvent.h"

typedef bool (INV_CALL *KeyEventHandler)(KeyEventDescriptor e);

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
			KeyEventDescriptor e = ois_descriptor_of_keyevent(keyEvent, keyEvent);

			result = keyPressedHandler(e);
		}

		return result;
	}

	bool keyReleased(const OIS::KeyEvent &arg)
	{
		bool result = true;

		if (keyReleasedHandler != NULL) {
			OIS::KeyEvent* keyEvent = const_cast<OIS::KeyEvent*>(&arg);
			KeyEventDescriptor e = ois_descriptor_of_keyevent(keyEvent, keyEvent);

			result = keyReleasedHandler(e);
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

#ifndef CUSTOMKEYEVENTLISTENER_H
#define CUSTOMKEYEVENTLISTENER_H

#include "cOIS.h"

using namespace invision;

class CustomKeyListener : public OIS::KeyListener
{
private:
	KeyEventHandler keyPressedHandler;
	KeyEventHandler keyReleasedHandler;

public:
	CustomKeyListener(KeyEventHandler keyPressed, KeyEventHandler keyReleased)
		: keyPressedHandler(keyPressed), keyReleasedHandler(keyReleased)
	{ }


	bool keyPressed(const OIS::KeyEvent &arg)
	{
		bool result = true;

		if (keyPressedHandler != NULL) {
			OIS::KeyEvent* keyEvent = const_cast<OIS::KeyEvent*>(&arg);
			InvHandle keyHandle = createReference<OIS::KeyEvent>(keyEvent);
			KeyEventDescriptor descriptor = descriptor_of_keyevent(keyHandle);

			result = fromBool(keyPressedHandler(descriptor));
			destroyHandle(keyHandle);
		}

		return result;
	}

	bool keyReleased(const OIS::KeyEvent &arg)
	{
		bool result = true;

		if (keyReleasedHandler != NULL) {
			OIS::KeyEvent* keyEvent = const_cast<OIS::KeyEvent*>(&arg);
			InvHandle keyHandle = createReference<OIS::KeyEvent>(keyEvent);
			KeyEventDescriptor descriptor = descriptor_of_keyevent(keyHandle);

			result = fromBool(keyReleasedHandler(descriptor));
			destroyHandle(keyHandle);
		}

		return result;
	}
};

#endif // CUSTOMKEYEVENTLISTENER_H

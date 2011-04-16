#ifndef CUSTOMKEYEVENTLISTENER_H
#define CUSTOMKEYEVENTLISTENER_H

#include "cOIS.h"
#include "cKeyEvent.h"

extern "C"
{

typedef _bool (*KeyEventHandler)(KeyEventExtended e);

__export HKeyListener __entry ois_customkeylistener_new(KeyEventHandler pressedHandler, KeyEventHandler releasedHandler);
__export void __entry ois_customkeylistener_delete(HKeyListener self);

}

#ifdef __cplusplus

inline OIS::KeyListener* asKeyListener(HKeyListener handle)
{
	return (OIS::KeyListener*) handle;
}

class CustomKeyListener : OIS::KeyListener
{
public:
	KeyEventHandler keyPressedHandler;
	KeyEventHandler keyReleasedHandler;

	bool keyPressed(const OIS::KeyEvent &arg)
	{
		HKeyEvent keyEvent = (HKeyEvent)&arg;
		KeyEventExtended e = ois_keyevent_new_from(keyEvent);
		bool result = true;

		if (keyPressedHandler != NULL)
			result = fromBool(keyPressedHandler(e));

		return result;
	}

	bool keyReleased(const OIS::KeyEvent &arg)
	{
		HKeyEvent keyEvent = (HKeyEvent)&arg;
		KeyEventExtended e = ois_keyevent_new_from(keyEvent);
		bool result = true;

		if (keyReleasedHandler != NULL)
			result = fromBool(keyReleasedHandler(e));

		return result;
	}
};

#endif

#endif // CUSTOMKEYEVENTLISTENER_H

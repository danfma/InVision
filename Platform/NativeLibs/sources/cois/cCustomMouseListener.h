#ifndef CUSTOMMOUSELISTENER_H
#define CUSTOMMOUSELISTENER_H

#include "cOIS.h"
#include "cMouseEvent.h"

typedef bool (INV_CALL *MouseMovedHandler)(MouseEventDescriptor e);
typedef bool (INV_CALL *MouseClickHandler)(MouseEventDescriptor e, OIS::MouseButtonID mouseButton);

class CustomMouseListener : public OIS::MouseListener
{
public:
	MouseMovedHandler movedHandler;
	MouseClickHandler mousePressedHandler;
	MouseClickHandler mouseReleasedHandler;

	CustomMouseListener()
	{
		movedHandler = NULL;
		mousePressedHandler = NULL;
		mouseReleasedHandler = NULL;
	}

	bool mouseMoved(const OIS::MouseEvent &arg)
	{
		if (movedHandler != NULL) {
			OIS::MouseEvent* e = const_cast<OIS::MouseEvent*>(&arg);
			MouseEventDescriptor ex = ois_descriptor_of_mouseevent(e, e);

			return movedHandler(ex);
		}

		return true;
	}

	bool mousePressed(const OIS::MouseEvent &arg, OIS::MouseButtonID id)
	{
		bool result = true;

		if (mousePressedHandler != NULL) {
			OIS::MouseEvent* e = const_cast<OIS::MouseEvent*>(&arg);
			MouseEventDescriptor ex = ois_descriptor_of_mouseevent(e, e);

			result = mousePressedHandler(ex, id);
		}

		return result;
	}

	bool mouseReleased(const OIS::MouseEvent &arg, OIS::MouseButtonID id)
	{
		bool result = true;

		if (mouseReleasedHandler != NULL) {
			OIS::MouseEvent* e = const_cast<OIS::MouseEvent*>(&arg);
			MouseEventDescriptor ex = ois_descriptor_of_mouseevent(e, e);

			result = mouseReleasedHandler(ex, id);
		}

		return result;
	}
};

extern "C"
{
	INV_EXPORT CustomMouseListener*
	INV_CALL ois_new_custommouselistener(
		MouseMovedHandler movedHandler,
		MouseClickHandler pressHandler,
		MouseClickHandler releaseHandler);

	INV_EXPORT void
	INV_CALL ois_delete_customouselistener(CustomMouseListener* self);
}

#endif // CUSTOMMOUSELISTENER_H

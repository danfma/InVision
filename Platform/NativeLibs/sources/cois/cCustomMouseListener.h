#ifndef CUSTOMMOUSELISTENER_H
#define CUSTOMMOUSELISTENER_H

#include "cOIS.h"

class CustomMouseListener : public OIS::MouseListener
{
public:
	MouseMovedHandler movedHandler;
	MouseClickHandler mousePressedHandler;
	MouseClickHandler mouseReleasedHandler;

	CustomMouseListener(
		MouseMovedHandler moved = NULL,
		MouseClickHandler mousePressed = NULL,
		MouseClickHandler mouseReleased = NULL)
		: movedHandler(moved), mousePressedHandler(mousePressed), mouseReleasedHandler(mouseReleased)
	{ }

	bool mouseMoved(const OIS::MouseEvent &arg)
	{
		bool result = true;

		if (movedHandler != NULL) {
			OIS::MouseEvent* e = const_cast<OIS::MouseEvent*>(&arg);
			InvHandle eventHandle = createReference<OIS::MouseEvent>(e);
			MouseEventDescriptor descriptor = descriptor_of_mouseevent(eventHandle);

			result = fromBool( movedHandler(descriptor) ) ;
			destroyHandle(eventHandle);
		}

		return result;
	}

	bool mousePressed(const OIS::MouseEvent &arg, OIS::MouseButtonID id)
	{
		bool result = true;

		if (mousePressedHandler != NULL) {
			OIS::MouseEvent* e = const_cast<OIS::MouseEvent*>(&arg);
			InvHandle eventHandle = createReference<OIS::MouseEvent>(e);
			MouseEventDescriptor descriptor = descriptor_of_mouseevent(eventHandle);

			result = fromBool( mousePressedHandler(descriptor, id) );
			destroyHandle(eventHandle);
		}

		return result;
	}

	bool mouseReleased(const OIS::MouseEvent &arg, OIS::MouseButtonID id)
	{
		bool result = true;

		if (mouseReleasedHandler != NULL) {
			OIS::MouseEvent* e = const_cast<OIS::MouseEvent*>(&arg);
			InvHandle eventHandle = createReference<OIS::MouseEvent>(e);
			MouseEventDescriptor descriptor = descriptor_of_mouseevent(eventHandle);

			result = fromBool( mouseReleasedHandler(descriptor, id) );
			destroyHandle(eventHandle);
		}

		return result;
	}
};

#endif // CUSTOMMOUSELISTENER_H

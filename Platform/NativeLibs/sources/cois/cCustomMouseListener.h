#ifndef CUSTOMMOUSELISTENER_H
#define CUSTOMMOUSELISTENER_H

#include "cOIS.h"
#include "cMouseEvent.h"

extern "C"
{
	typedef _bool (*MouseMovedHandler)(MouseEventExtended e);
	typedef _bool (*MouseClickHandler)(MouseEventExtended e, _int mouseButton);

	__export HMouseListener __entry ois_custommouselistener_new(MouseMovedHandler movedHandler, MouseClickHandler pressHandler, MouseClickHandler releaseHandler);
	__export void __entry ois_customouselistener_delete(HMouseListener self);
}

#ifdef __cplusplus

	inline OIS::MouseListener* asMouseListener(HMouseListener handle)
	{
		return (OIS::MouseListener*)handle;
	}


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
			HMouseEvent e = (HMouseEvent)&arg;
			MouseEventExtended ex = ois_mouseevent_new_from(e);

			if (movedHandler != NULL)
				return fromBool(movedHandler(ex));

			return true;
		}

		bool mousePressed(const OIS::MouseEvent &arg, OIS::MouseButtonID id)
		{
			HMouseEvent e = (HMouseEvent)&arg;
			MouseEventExtended ex = ois_mouseevent_new_from(e);
			bool result = true;

			if (mousePressedHandler != NULL)
				result = fromBool(mousePressedHandler(ex, (_int)id));

			return result;
		}

		bool mouseReleased(const OIS::MouseEvent &arg, OIS::MouseButtonID id)
		{
			HMouseEvent e = (HMouseEvent)&arg;
			MouseEventExtended ex = ois_mouseevent_new_from(e);
			bool result = true;

			if (mouseReleasedHandler != NULL)
				result = fromBool(mouseReleasedHandler(ex, (_int)id));

			return result;
		}
	};

#endif // __cplusplus

#endif // CUSTOMMOUSELISTENER_H

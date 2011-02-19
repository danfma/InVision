#ifndef CUSTOMMOUSELISTENER_H
#define CUSTOMMOUSELISTENER_H

#include "invision/Common.h"
#include "Common.h"

extern "C"
{
	typedef Bool (*MouseMoveEventHandler)(MouseEventArgs e);
	typedef Bool (*MouseClickEventHandler)(MouseEventArgs e, Int32 button);

	__export HCustomMouseListener __entry ois_custommouselistener_new(
		MouseMoveEventHandler mouseMove,
		MouseClickEventHandler mousePressed,
		MouseClickEventHandler mouseReleased);

	__export void __entry ois_custommouselistener_delete(HCustomMouseListener self);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		class CustomMouseListener : OIS::MouseListener
		{
		private:
			MouseMoveEventHandler mouseMoveHandler;
			MouseClickEventHandler mousePressedHandler;
			MouseClickEventHandler mouseReleasedHandler;

		public:
			CustomMouseListener(
				MouseMoveEventHandler mouseMoveHandler,
				MouseClickEventHandler mousePressedHandler,
				MouseClickEventHandler mouseReleasedHandler)
			{
				this->mouseMoveHandler = mouseMoveHandler;
				this->mousePressedHandler = mousePressedHandler;
				this->mouseReleasedHandler = mouseReleasedHandler;
			}

			bool mouseMoved(const OIS::MouseEvent &e)
			{
				bool result = true;

				if (mouseMoveHandler != NULL) {
					OIS::MouseEvent cp = e;
					MouseEventArgs event = MouseEventArgs(cp);
					
					result = toBool(mouseMoveHandler(event));
				}

				return result;
			}

			bool mousePressed(const OIS::MouseEvent &e, OIS::MouseButtonID id)
			{
				bool result = true;

				if (mousePressedHandler != NULL) {
					OIS::MouseEvent cp = e;
					MouseEventArgs event = MouseEventArgs(cp);
					
					result = toBool(mousePressedHandler(event, id));
				}

				return result;
			}

			bool mouseReleased(const OIS::MouseEvent &e, OIS::MouseButtonID id)
			{
				bool result = true;

				if (mouseReleasedHandler != NULL) {
					OIS::MouseEvent cp = e;
					MouseEventArgs event = MouseEventArgs(cp);
					
					result = toBool(mouseReleasedHandler(event, id));
				}

				return result;
			}
		};

		CustomMouseListener* asCustomMouseListener(HCustomMouseListener handle)
		{
			return (CustomMouseListener*)handle;
		}
	}
}

#endif

#endif // CUSTOMMOUSELISTENER_H

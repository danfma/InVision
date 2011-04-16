#include "cMouseEvent.h"

__export MouseEventExtended __entry ois_mouseevent_new_from(HMouseEvent self)
{
	const OIS::MouseEvent* e = (OIS::MouseEvent*)self;

	MouseEventExtended ex;
	ex.base = ois_eventarg_new_from(&e);
	ex.state = ois_mousestate_new_from((HMouseState)&e->state);

	return ex;
}

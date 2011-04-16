#ifndef MOUSEEVENT_H
#define MOUSEEVENT_H

#include "cOIS.h"
#include "cEventArgs.h"
#include "cMouseState.h"

extern "C"
{
	struct MouseEventExtended
	{
		EventArgExtended base;
		MouseStateExtended state;
	};

	__export MouseEventExtended __entry ois_mouseevent_new_from(HMouseEvent self);
}

#endif // MOUSEEVENT_H

#ifndef MOUSEEVENT_H
#define MOUSEEVENT_H

#include "cOIS.h"
#include "cEventArgs.h"
#include "cMouseState.h"

extern "C"
{
	struct MouseEventDescriptor
	{
		EventArgDescriptor base;
		MouseStateDescriptor state;
	};

	INV_EXPORT MouseEventDescriptor
	INV_CALL ois_descriptor_of_mouseevent(_any self, OIS::MouseEvent* event);
}

#endif // MOUSEEVENT_H

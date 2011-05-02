#ifndef CMOUSE_H
#define CMOUSE_H

#include "cOIS.h"
#include "cObject.h"
#include "cMouseState.h"
#include "cCustomMouseListener.h"

extern "C"
{
	struct MouseDescriptor
	{
		_any self;
		MouseStateDescriptor mouseState;
	};

	INV_EXPORT MouseDescriptor
	INV_CALL ois_descriptor_of_mouse(_any self, OIS::Mouse* mouse);

	INV_EXPORT void
	INV_CALL ois_mouse_set_event_callback(OIS::Mouse* self, CustomMouseListener* listener);

}

#endif // CMOUSE_H

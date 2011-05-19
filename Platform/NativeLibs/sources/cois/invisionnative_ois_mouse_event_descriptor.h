#ifndef __INVISIONNATIVE_OIS_MOUSE_EVENT_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_MOUSE_EVENT_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois_event_arg_descriptor.h"
#include "invisionnative_ois_mouse_state_descriptor.h"
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type MouseEventDescriptor
	 */
	struct MouseEventDescriptor
	{
		EventArgDescriptor base;
		MouseStateDescriptor mouseState;
	};
	
	MouseEventDescriptor descriptor_of_mouseevent(InvHandle handle);
	
}

#endif // __INVISIONNATIVE_OIS_MOUSE_EVENT_DESCRIPTOR_H__


#ifndef __INVISIONNATIVE_OIS_KEY_EVENT_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_KEY_EVENT_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois_event_arg_descriptor.h"
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type KeyEventDescriptor
	 */
	struct KeyEventDescriptor
	{
		EventArgDescriptor base;
		KEY_CODE* key;
		_uint* text;
	};
	
	KeyEventDescriptor descriptor_of_keyevent(InvHandle handle);
	
}

#endif // __INVISIONNATIVE_OIS_KEY_EVENT_DESCRIPTOR_H__


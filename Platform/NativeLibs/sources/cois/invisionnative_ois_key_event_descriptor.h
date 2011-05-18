#ifndef __INVISIONNATIVE_OIS_KEY_EVENT_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_KEY_EVENT_DESCRIPTOR_H__

#include <InvisionHandle.h>
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
}

#endif // __INVISIONNATIVE_OIS_KEY_EVENT_DESCRIPTOR_H__


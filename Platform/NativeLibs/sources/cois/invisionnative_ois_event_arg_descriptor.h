#ifndef __INVISIONNATIVE_OIS_EVENT_ARG_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_EVENT_ARG_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type EventArgDescriptor
	 */
	struct EventArgDescriptor
	{
		InvHandle self;
	};
	
	EventArgDescriptor descriptor_of_eventarg(InvHandle handle);
	
}

#endif // __INVISIONNATIVE_OIS_EVENT_ARG_DESCRIPTOR_H__


#ifndef __INVISIONNATIVE_OIS_COMPONENT_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_COMPONENT_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type ComponentDescriptor
	 */
	struct ComponentDescriptor
	{
		InvHandle self;
		COMPONENT_TYPE* ctype;
	};
	
	ComponentDescriptor descriptor_of_component(InvHandle handle);
	
}

#endif // __INVISIONNATIVE_OIS_COMPONENT_DESCRIPTOR_H__


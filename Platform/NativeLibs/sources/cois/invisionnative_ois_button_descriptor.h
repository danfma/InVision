#ifndef __INVISIONNATIVE_OIS_BUTTON_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_BUTTON_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois_component_descriptor.h"
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type ButtonDescriptor
	 */
	struct ButtonDescriptor
	{
		ComponentDescriptor base;
		_bool* pushed;
	};
	
	ButtonDescriptor descriptor_of_button(InvHandle handle);
	
}

#endif // __INVISIONNATIVE_OIS_BUTTON_DESCRIPTOR_H__


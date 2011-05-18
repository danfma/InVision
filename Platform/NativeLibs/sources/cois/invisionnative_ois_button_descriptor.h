#ifndef __INVISIONNATIVE_OIS_BUTTON_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_BUTTON_DESCRIPTOR_H__

#include <InvisionHandle.h>
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
}

#endif // __INVISIONNATIVE_OIS_BUTTON_DESCRIPTOR_H__


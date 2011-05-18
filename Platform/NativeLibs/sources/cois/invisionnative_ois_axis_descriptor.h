#ifndef __INVISIONNATIVE_OIS_AXIS_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_AXIS_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type AxisDescriptor
	 */
	struct AxisDescriptor
	{
		ComponentDescriptor base;
		_int* abs;
		_int* rel;
		_bool* absOnly;
		_byte* padding;
	};
}

#endif // __INVISIONNATIVE_OIS_AXIS_DESCRIPTOR_H__


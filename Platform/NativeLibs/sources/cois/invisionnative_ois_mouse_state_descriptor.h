#ifndef __INVISIONNATIVE_OIS_MOUSE_STATE_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_MOUSE_STATE_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois_axis_descriptor.h"
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type MouseStateDescriptor
	 */
	struct MouseStateDescriptor
	{
		InvHandle self;
		_int* width;
		_int* height;
		_int* buttons;
		AxisDescriptor x;
		AxisDescriptor y;
		AxisDescriptor z;
	};
}

#endif // __INVISIONNATIVE_OIS_MOUSE_STATE_DESCRIPTOR_H__


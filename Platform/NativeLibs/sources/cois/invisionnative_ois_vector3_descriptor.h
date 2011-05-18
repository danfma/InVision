#ifndef __INVISIONNATIVE_OIS_VECTOR3_DESCRIPTOR_H__
#define __INVISIONNATIVE_OIS_VECTOR3_DESCRIPTOR_H__

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type Vector3Descriptor
	 */
	struct Vector3Descriptor
	{
		ComponentDescriptor base;
		_float* z;
		_float* y;
		_float* x;
	};
}

#endif // __INVISIONNATIVE_OIS_VECTOR3_DESCRIPTOR_H__


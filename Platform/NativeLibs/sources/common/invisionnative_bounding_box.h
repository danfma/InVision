#ifndef __INVISIONNATIVE_BOUNDING_BOX_H__
#define __INVISIONNATIVE_BOUNDING_BOX_H__

#include <InvisionHandle.h>
#include "invisionnative.h"

extern "C"
{
	/**
	 * Type BoundingBox
	 */
	struct BoundingBox
	{
		Vector3 max;
		Vector3 min;
	};
	
}

#endif // __INVISIONNATIVE_BOUNDING_BOX_H__


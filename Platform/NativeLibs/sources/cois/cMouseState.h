#ifndef MOUSESTATE_H
#define MOUSESTATE_H

#include "cOIS.h"
#include "cAxis.h"

extern "C"
{
	struct MouseStateDescriptor
	{
		Handle handle;				// handle	4 bytes
		int* width;					// mutable	8
		int* height;				// mutable	12
		int* buttons;				//			16
		AxisDescriptor x, y, z;		//			76
	};

	INV_EXPORT MouseStateDescriptor
	INV_CALL ois_descriptor_of_mousestate(_any self, OIS::MouseState* state);
}

#endif // MOUSESTATE_H

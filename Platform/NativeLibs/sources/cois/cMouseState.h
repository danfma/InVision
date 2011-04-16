#ifndef MOUSESTATE_H
#define MOUSESTATE_H

#include "cOIS.h"
#include "cAxis.h"

extern "C"
{
	struct MouseStateExtended
	{
		HMouseState handle;
		_int* width;		// mutable
		_int* height;		// mutable
		AxisExtended x, y, z;
		_int* buttons;
	};

	__export MouseStateExtended __entry ois_mousestate_new_from(HMouseState self);
}

#ifdef __cplusplus

	inline OIS::MouseState* asMouseState(HMouseState self)
	{
		return (OIS::MouseState*) self;
	}

#endif

#endif // MOUSESTATE_H

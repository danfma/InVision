#ifndef OIS_H
#define OIS_H

#include "cWrapper.h"
#include "cAxis.h"

#ifdef __cplusplus
#	include <string>
#	include <OIS.h>
#endif

extern "C"
{
	/*
	 * OIS::Type
	 */
	extern _int OIS_TYPE_UNKNONW;
	extern _int OIS_TYPE_KEYBOARD;
	extern _int OIS_TYPE_MOUSE;
	extern _int OIS_TYPE_JOYSTICK;
	extern _int OIS_TYPE_TABLET;
	
	/*
	 * OIS::ComponentType
	 */
	extern _int OIS_COMPONENT_TYPE_UNKNOWN;
	extern _int OIS_COMPONENT_TYPE_BUTTON;
	extern _int OIS_COMPONENT_TYPE_AXIS;
	extern _int OIS_COMPONENT_TYPE_SLIDER;
	extern _int OIS_COMPONENT_TYPE_POV;
	extern _int OIS_COMPONENT_TYPE_VECTOR3;
}

#ifdef __cplusplus

namespace invision
{
	inline bool ensureNotNull(_handle handle)
	{
		bool isNull = handle == NULL;
		
		if (isNull)
			raiseException("Parameter is null");
		
		return !isNull;
	}
}

#endif

#endif // OIS_H

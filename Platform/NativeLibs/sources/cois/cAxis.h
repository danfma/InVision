#ifndef AXIS_H
#define AXIS_H

#include "cOIS.h"
#include "cComponent.h"

extern "C"
{
	/*
	 * OIS::Axis
	 */
	struct OISAxis
	{
		OISComponent base;
		_int abs;
		_int rel;
		_bool absOnly;
	};
	
	__export OISAxis* __entry newOISAxis();
	__export void __entry deleteOISAxis(OISAxis* self);
	__export void __entry refreshOISAxis(OISAxis* self);
}

#endif // AXIS_H

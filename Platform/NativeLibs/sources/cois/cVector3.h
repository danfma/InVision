#ifndef VECTOR3_H
#define VECTOR3_H

#include "cOIS.h"

extern "C"
{
	/*
	 * OIS::Vector3
	 */
	struct OISVector3
	{
		OISComponent base;
		_float x;
		_float y;
		_float z;
	};
	
	__export OISVector3* __entry newOISVector();
	__export void __entry deleteOISVector(OISVector3* self);
	__export void __entry refreshOISVector(OISVector3* self);
}

#endif // VECTOR3_H

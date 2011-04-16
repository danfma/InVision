#ifndef VECTOR3_H
#define VECTOR3_H

#include "cOIS.h"
#include "cComponent.h"

extern "C"
{
	struct Vector3Extended {
		ComponentExtended base;
		_float* x;
		_float* y;
		_float* z;
	};

	/*
	 * OIS::Button
	 */
	__export Vector3Extended __entry ois_vector3_new(float x, float y, float z);
	__export void __entry ois_vector3_delete(HVector3 self);
}


#endif // VECTOR3_H

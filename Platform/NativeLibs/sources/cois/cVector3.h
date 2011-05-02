#ifndef VECTOR3_H
#define VECTOR3_H

#include "cOIS.h"
#include "cComponent.h"

// definição da informação
struct Vector3Descriptor
{
	ComponentDescriptor base;	// 8 bytes

	// fields
	float* x;					// 12
	float* y;					// 16
	float* z;					// 20
};


extern "C"
{
	Vector3Descriptor
	ois_descriptor_of_vector3(_any self, OIS::Vector3* data);

	/*
	 * OIS::Button
	 */
	INV_EXPORT Vector3Descriptor
	INV_CALL ois_new_vector3(float x, float y, float z);

	INV_EXPORT void
	INV_CALL ois_delete_vector3(OIS::Vector3* self);
}

#endif // VECTOR3_H

#include "cOIS.h"

using namespace invision;


Vector3Descriptor
descriptor_of_vector3(InvHandle handle)
{
	OIS::Vector3* data = castHandle<OIS::Vector3>(handle);
	
	Vector3Descriptor descriptor;
	descriptor.base = descriptor_of_component(handle);
	descriptor.x = &data->x;
	descriptor.y = &data->y;
	descriptor.z = &data->z;

	return descriptor;
}

/**
 * Method: Vector3::Vector3
 */
INV_EXPORT InvHandle
INV_CALL new_vector3_by_descriptor(Vector3Descriptor* descriptor)
{
	OIS::Vector3* obj = new OIS::Vector3();

	InvHandle self = createHandle< OIS::Vector3 >(obj);
	*descriptor = descriptor_of_vector3(self);

	return self;
}

/**
 * Method: Vector3::Vector3
 */
INV_EXPORT InvHandle
INV_CALL new_vector3_by_descriptor_x_y_z(Vector3Descriptor* descriptor, _float x, _float y, _float z)
{
	OIS::Vector3* obj = new OIS::Vector3(x, y, z);

	InvHandle self = createHandle< OIS::Vector3 >(obj);
	*descriptor = descriptor_of_vector3(self);

	return self;
}

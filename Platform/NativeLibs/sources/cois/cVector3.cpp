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

INV_EXPORT Vector3Descriptor
INV_CALL new_vector3()
{
	InvHandle self = newHandleOf<OIS::Vector3>();
	
	return descriptor_of_vector3(self);
}

INV_EXPORT Vector3Descriptor
INV_CALL new_vector3_by_x_y_z(_float x, _float y, _float z)
{
	InvHandle self = newHandleOf<OIS::Vector3, float, float, float>(x, y, z);
	
	return descriptor_of_vector3(self);
}

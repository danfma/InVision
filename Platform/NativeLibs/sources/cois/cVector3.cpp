#include "cVector3.h"


Vector3Descriptor
ois_descriptor_of_vector3(_any self, OIS::Vector3* data)
{
	Vector3Descriptor descriptor;
	descriptor.base = ois_descriptor_of_component(self, data);
	descriptor.x = &data->x;
	descriptor.y = &data->y;
	descriptor.z = &data->z;

	return descriptor;
}

INV_EXPORT Vector3Descriptor
INV_CALL ois_new_vector3(float x, float y, float z)
{
	OIS::Vector3* vector = new OIS::Vector3(x, y, z);

	return ois_descriptor_of_vector3(vector, vector);
}

INV_EXPORT void
INV_CALL ois_delete_vector3(OIS::Vector3* self)
{
	if (self == NULL)
		return;

	delete self;
}


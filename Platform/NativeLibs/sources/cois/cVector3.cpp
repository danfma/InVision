#include "cVector3.h"

__export Vector3Extended __entry ois_vector3_new(float x, float y, float z)
{
	OIS::Vector3* vector = new OIS::Vector3(x, y, z);

	Vector3Extended vectorInfo;
	vectorInfo.base.handle = vector;
	vectorInfo.base.componentType = (_int*) &vector->cType;
	vectorInfo.x = (_float*) &vector->x;
	vectorInfo.y = (_float*) &vector->y;
	vectorInfo.z = (_float*) &vector->z;

	return vectorInfo;
}

__export void __entry ois_vector3_delete(HVector3 self)
{
	if (self == NULL)
		return;

	delete (OIS::Vector3*)self;
}

__export Vector3ProxyInfo __entry ois_new_vector3(float x, float y, float z)
{
	return Vector3Proxy::createInfo(new Vector3Proxy(x, y, z));
}


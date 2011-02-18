#include "Vector3.h"

using namespace invision::ois;

__export HInputVector3 __entry ois_vector3_new()
{
	return new OIS::Vector3();
}

__export void __entry ois_vector3_delete(HInputVector3 vector)
{
	delete asVector3(vector);
}

__export float __entry ois_vector3_get_x(HInputVector3 vector)
{
	return asVector3(vector)->x;
}

__export void __entry ois_vector3_set_x(HInputVector3 vector, float value)
{
	asVector3(vector)->x = value;
}

__export float __entry ois_vector3_get_y(HInputVector3 vector)
{
	return asVector3(vector)->y;
}

__export void __entry ois_vector3_set_y(HInputVector3 vector, float value)
{
	asVector3(vector)->y = value;
}

__export float __entry ois_vector3_get_z(HInputVector3 vector)
{
	return asVector3(vector)->z;
}

__export void __entry ois_vector3_set_z(HInputVector3 vector, float value)
{
	asVector3(vector)->z = value;
}

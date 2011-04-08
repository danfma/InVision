#ifndef VECTOR3_H
#define VECTOR3_H

#include "cOIS.h"

extern "C"
{
	__export HInputVector3 __entry ois_vector3_new();
	__export void __entry ois_vector3_delete(HInputVector3 vector);

	__export float __entry ois_vector3_get_x(HInputVector3 vector);
	__export void __entry ois_vector3_set_x(HInputVector3 vector, float value);

	__export float __entry ois_vector3_get_y(HInputVector3 vector);
	__export void __entry ois_vector3_set_y(HInputVector3 vector, float value);

	__export float __entry ois_vector3_get_z(HInputVector3 vector);
	__export void __entry ois_vector3_set_z(HInputVector3 vector, float value);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::Vector3* asVector3(HInputVector3 handle)
		{
			return (OIS::Vector3*)handle;
		}
	}
}

#endif

#endif // VECTOR3_H

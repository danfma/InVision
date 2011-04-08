#ifndef AXIS_H
#define AXIS_H

#include "cOIS.h"

extern "C"
{
	__export HInputAxis __entry ois_axis_new();
	__export void __entry ois_axis_delete(HInputAxis axis);

	__export _int __entry ois_axis_get_absolute(HInputAxis axis);
	__export void __entry ois_axis_set_absolute(HInputAxis axis, _int value);

	__export _int __entry ois_axis_get_relative(HInputAxis axis);
	__export void __entry ois_axis_set_relative(HInputAxis axis, _int value);

	__export _bool __entry ois_axis_get_absolute_only(HInputAxis axis);
	__export void __entry ois_axis_set_absolute_only(HInputAxis axis, _bool value);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::Axis* asAxis(HInputAxis handle)
		{
			return (OIS::Axis*)handle;
		}
	}
}

#endif

#endif // AXIS_H

#ifndef AXIS_H
#define AXIS_H

#include "invision/Common.h"
#include "Common.h"

extern "C"
{
	__export HInputAxis __entry ois_axis_new();
	__export void __entry ois_axis_delete(HInputAxis axis);

	__export Int32 __entry ois_axis_get_absolute(HInputAxis axis);
	__export void __entry ois_axis_set_absolute(HInputAxis axis, Int32 value);

	__export Int32 __entry ois_axis_get_relative(HInputAxis axis);
	__export void __entry ois_axis_set_relative(HInputAxis axis, Int32 value);

	__export Bool __entry ois_axis_get_absolute_only(HInputAxis axis);
	__export void __entry ois_axis_set_absolute_only(HInputAxis axis, Bool value);
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

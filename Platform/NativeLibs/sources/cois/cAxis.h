#ifndef CAXIS_H
#define CAXIS_H

#include "cOIS.h"
#include "cComponent.h"

extern "C"
{
	struct AxisExtended {
		ComponentExtended base;
		_int* abs;
		_int* rel;
		_bool* absOnly;
	};

	/*
	 * OIS::Button
	 */
	__export AxisExtended __entry ois_axis_new();
	__export AxisExtended __entry ois_axis_new_from(HAxis self);
	__export void __entry ois_axis_delete(HAxis self);
}

#ifdef __cplusplus

	inline OIS::Axis* asAxis(HAxis handle)
	{
		return (OIS::Axis*)handle;
	}

#endif // __cplusplus

#endif // CAXIS_H

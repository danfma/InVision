#ifndef INVISION_MATH_H
#define INVISION_MATH_H

#include "cOgre.h"

extern "C"
{
	typedef _uint AngleUnit;

	extern const AngleUnit AngleUnitDegree;
	extern const AngleUnit AngleUnitRadians;

	__export AngleUnit __entry math_get_angle_unit();
	__export void __entry math_set_angle_unit(AngleUnit unit);

	__export _float __entry math_radian_to_angle_unit(_float radians);
	__export _float __entry math_degree_to_angle_unit(_float degrees);
}

#endif // INVISION_MATH_H

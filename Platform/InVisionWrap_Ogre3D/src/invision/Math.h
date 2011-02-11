#ifndef INVISION_MATH_H
#define INVISION_MATH_H

#include "invision/Common.h"

extern "C"
{
	typedef UInt32 AngleUnit;

	extern const AngleUnit AngleUnitDegree;
	extern const AngleUnit AngleUnitRadians;

	__EXPORT AngleUnit __ENTRY math_get_angle_unit();
	__EXPORT void __ENTRY math_set_angle_unit(AngleUnit unit);

	__EXPORT float __ENTRY math_radian_to_angle_unit(float radians);
	__EXPORT float __ENTRY math_degree_to_angle_unit(float degrees);
}

#endif // INVISION_MATH_H

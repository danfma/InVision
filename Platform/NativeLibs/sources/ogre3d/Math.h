#ifndef INVISION_MATH_H
#define INVISION_MATH_H

#include "invision/Common.h"

extern "C"
{
	typedef UInt32 AngleUnit;

	extern const AngleUnit AngleUnitDegree;
	extern const AngleUnit AngleUnitRadians;

	__export AngleUnit __entry math_get_angle_unit();
	__export void __entry math_set_angle_unit(AngleUnit unit);

	__export float __entry math_radian_to_angle_unit(float radians);
	__export float __entry math_degree_to_angle_unit(float degrees);
}

#endif // INVISION_MATH_H

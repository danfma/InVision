#ifndef INVISION_MATH_H
#define INVISION_MATH_H

#include "cOgre.h"

extern "C"
{
	typedef _uint AngleUnit;

	extern const AngleUnit AngleUnitDegree;
	extern const AngleUnit AngleUnitRadians;

	INV_EXPORT AngleUnit INV_CALL math_get_angle_unit();
	INV_EXPORT void INV_CALL math_set_angle_unit(AngleUnit unit);

	INV_EXPORT _float INV_CALL math_radian_to_angle_unit(_float radians);
	INV_EXPORT _float INV_CALL math_degree_to_angle_unit(_float degrees);
}

#endif // INVISION_MATH_H

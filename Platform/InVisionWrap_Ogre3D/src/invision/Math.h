#ifndef INVISION_MATH_H
#define INVISION_MATH_H

#include "invision/Common.h"

extern "C"
{
	typedef UInt32 AngleUnit;

	extern const AngleUnit AngleUnitDegree;
	extern const AngleUnit AngleUnitRadians;

	__EXPORT AngleUnit __ENTRY MathGetAngleUnit();
	__EXPORT void __ENTRY MathSetAngleUnit(AngleUnit unit);

	__EXPORT float __ENTRY MathRadianToAngleUnit(float radians);
	__EXPORT float __ENTRY MathDegreeToAngleUnit(float degrees);
}

#endif // INVISION_MATH_H

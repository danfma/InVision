#include "Math.h"
#include <OgreMath.h>

const AngleUnit AngleUnitDegree = Ogre::Math::AU_DEGREE;
const AngleUnit AngleUnitRadians = Ogre::Math::AU_RADIAN;

__export AngleUnit __entry math_get_angle_unit()
{
	return Ogre::Math::getAngleUnit();
}

__export void __entry math_set_angle_unit(AngleUnit unit)
{
	Ogre::Math::setAngleUnit((Ogre::Math::AngleUnit)unit);
}

__export float __entry math_radian_to_angle_unit(float radians)
{
	return Ogre::Math::RadiansToAngleUnits(radians);
}

__export float __entry math_degree_to_angle_unit(float degrees)
{
	return Ogre::Math::DegreesToAngleUnits(degrees);
}

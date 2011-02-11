#include "invision/Math.h"
#include "OgreMath.h"

const AngleUnit AngleUnitDegree = Ogre::Math::AU_DEGREE;
const AngleUnit AngleUnitRadians = Ogre::Math::AU_RADIAN;

__EXPORT AngleUnit __ENTRY math_get_angle_unit()
{
	return Ogre::Math::getAngleUnit();
}

__EXPORT void __ENTRY math_set_angle_unit(AngleUnit unit)
{
	Ogre::Math::setAngleUnit((Ogre::Math::AngleUnit)unit);
}

__EXPORT float __ENTRY math_radian_to_angle_unit(float radians)
{
	return Ogre::Math::RadiansToAngleUnits(radians);
}

__EXPORT float __ENTRY math_degree_to_angle_unit(float degrees)
{
	return Ogre::Math::DegreesToAngleUnits(degrees);
}

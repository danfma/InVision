#include "Math.h"
#include <OgreMath.h>

const AngleUnit AngleUnitDegree = Ogre::Math::AU_DEGREE;
const AngleUnit AngleUnitRadians = Ogre::Math::AU_RADIAN;

INV_EXPORT AngleUnit INV_CALL math_get_angle_unit()
{
	return Ogre::Math::getAngleUnit();
}

INV_EXPORT void INV_CALL math_set_angle_unit(AngleUnit unit)
{
	Ogre::Math::setAngleUnit((Ogre::Math::AngleUnit)unit);
}

INV_EXPORT _float INV_CALL math_radian_to_angle_unit(_float radians)
{
	return Ogre::Math::RadiansToAngleUnits(radians);
}

INV_EXPORT _float INV_CALL math_degree_to_angle_unit(_float degrees)
{
	return Ogre::Math::DegreesToAngleUnits(degrees);
}

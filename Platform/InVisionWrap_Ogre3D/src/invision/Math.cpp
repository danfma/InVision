#include "invision/Math.h"
#include "OgreMath.h"

const AngleUnit AngleUnitDegree = Ogre::Math::AU_DEGREE;
const AngleUnit AngleUnitRadians = Ogre::Math::AU_RADIAN;

__EXPORT AngleUnit __ENTRY MathGetAngleUnit()
{
	return Ogre::Math::getAngleUnit();
}

__EXPORT void __ENTRY MathSetAngleUnit(AngleUnit unit)
{
	Ogre::Math::setAngleUnit((Ogre::Math::AngleUnit)unit);
}

__EXPORT float __ENTRY MathRadianToAngleUnit(float radians)
{
	return Ogre::Math::RadiansToAngleUnits(radians);
}

__EXPORT float __ENTRY MathDegreeToAngleUnit(float degrees)
{
	return Ogre::Math::DegreesToAngleUnits(degrees);
}

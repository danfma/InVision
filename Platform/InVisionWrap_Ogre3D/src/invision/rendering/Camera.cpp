#include "Camera.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT void __ENTRY CamDelete(HCamera camera)
{
	delete asCamera(camera);
}

__EXPORT float __ENTRY CamGetAspectRatio(HCamera camera)
{
	return asCamera(camera)->getAspectRatio();
}

__EXPORT void __ENTRY CamSetAspectRatio(HCamera camera, float aspectRatio)
{
	asCamera(camera)->setAspectRatio(aspectRatio);
}

__EXPORT float __ENTRY CamGetFOVy(HCamera camera)
{
	return asCamera(camera)->getFOVy().valueRadians();
}

__EXPORT void __ENTRY CamSetFOVy(HCamera camera, float radians)
{
	asCamera(camera)->setFOVy(Ogre::Radian(radians));
}

__EXPORT float __ENTRY CamGetNearClipDistance(HCamera camera)
{
	return asCamera(camera)->getNearClipDistance();
}

__EXPORT void __ENTRY CamSetNearClipDistance(HCamera camera, float distance)
{
	asCamera(camera)->setNearClipDistance(distance);
}

__EXPORT float __ENTRY CamGetFarClipDistance(HCamera camera)
{
	return asCamera(camera)->getFarClipDistance();
}

__EXPORT void __ENTRY CamSetFarClipDistance(HCamera camera, float distance)
{
	asCamera(camera)->setFarClipDistance(distance);
}

__EXPORT PolygonModeEnum __ENTRY CamGetPolygonMode(HCamera camera)
{
	return (PolygonModeEnum)asCamera(camera)->getPolygonMode();
}

__EXPORT void __ENTRY CamSetPolygonMode(HCamera camera, PolygonModeEnum polygonMode)
{
	asCamera(camera)->setPolygonMode((Ogre::PolygonMode)polygonMode);
}

__EXPORT Vector3f __ENTRY CamGetPosition(HCamera camera)
{
	Ogre::Vector3 v = asCamera(camera)->getPosition();

	return toVector3f(v);
}

__EXPORT void __ENTRY CamSetPosition(HCamera camera, Vector3f position)
{
	Ogre::Vector3 v = fromVector3f(position);

	asCamera(camera)->setPosition(v);
}

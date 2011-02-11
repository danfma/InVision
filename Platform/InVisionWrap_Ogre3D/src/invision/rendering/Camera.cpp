#include "Camera.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT void __ENTRY camera_delete(HCamera camera)
{
	delete asCamera(camera);
}

__EXPORT float __ENTRY camera_get_aspect_ratio(HCamera camera)
{
	return asCamera(camera)->getAspectRatio();
}

__EXPORT void __ENTRY camera_set_aspect_ratio(HCamera camera, float aspectRatio)
{
	asCamera(camera)->setAspectRatio(aspectRatio);
}

__EXPORT float __ENTRY camera_get_fovy(HCamera camera)
{
	return asCamera(camera)->getFOVy().valueRadians();
}

__EXPORT void __ENTRY camera_set_fovy(HCamera camera, float radians)
{
	asCamera(camera)->setFOVy(Ogre::Radian(radians));
}

__EXPORT float __ENTRY camera_get_near_clip_distance(HCamera camera)
{
	return asCamera(camera)->getNearClipDistance();
}

__EXPORT void __ENTRY camera_set_near_clip_distance(HCamera camera, float distance)
{
	asCamera(camera)->setNearClipDistance(distance);
}

__EXPORT float __ENTRY camera_get_far_clip_distance(HCamera camera)
{
	return asCamera(camera)->getFarClipDistance();
}

__EXPORT void __ENTRY camera_set_far_clip_distance(HCamera camera, float distance)
{
	asCamera(camera)->setFarClipDistance(distance);
}

__EXPORT PolygonModeEnum __ENTRY camera_get_polygon_mode(HCamera camera)
{
	return (PolygonModeEnum)asCamera(camera)->getPolygonMode();
}

__EXPORT void __ENTRY camera_set_polygon_mode(HCamera camera, PolygonModeEnum polygonMode)
{
	asCamera(camera)->setPolygonMode((Ogre::PolygonMode)polygonMode);
}

__EXPORT Vector3f __ENTRY camera_get_position(HCamera camera)
{
	Ogre::Vector3 v = asCamera(camera)->getPosition();

	return toVector3f(v);
}

__EXPORT void __ENTRY camera_set_position(HCamera camera, Vector3f position)
{
	Ogre::Vector3 v = fromVector3f(position);

	asCamera(camera)->setPosition(v);
}

__EXPORT void __ENTRY camera_move(HCamera camera, Vector3f position)
{
	asCamera(camera)->move(fromVector3f(position));
}

__EXPORT void __ENTRY camera_move_relative(HCamera camera, Vector3f position)
{
	asCamera(camera)->moveRelative(fromVector3f(position));
}

__EXPORT void __ENTRY camera_set_auto_aspect_ratio(HCamera camera, Bool autoRatio)
{
	asCamera(camera)->setAutoAspectRatio(fromBool(autoRatio));
}

__EXPORT Vector3f __ENTRY camera_get_direction(HCamera camera)
{
	Ogre::Vector3 direction = asCamera(camera)->getDirection();

	return toVector3f(direction);
}

__EXPORT void __ENTRY camera_set_direction(HCamera camera, Vector3f position)
{
	asCamera(camera)->setDirection(fromVector3f(position));
}

__EXPORT Vector3f __ENTRY camera_get_up(HCamera camera)
{
	Ogre::Vector3 up = asCamera(camera)->getUp();

	return toVector3f(up);
}

__EXPORT Vector3f __ENTRY camera_get_right(HCamera camera)
{
	Ogre::Vector3 right = asCamera(camera)->getRight();

	return toVector3f(right);
}

__EXPORT void __ENTRY camera_look_at(HCamera camera, Vector3f targetPoint)
{
	asCamera(camera)->lookAt(fromVector3f(targetPoint));
}

__EXPORT void __ENTRY camera_look_at_3f(HCamera camera, float x, float y, float z)
{
	asCamera(camera)->lookAt(x, y, z);
}

__EXPORT void __ENTRY camera_roll(HCamera camera, float radians)
{
	asCamera(camera)->roll(Ogre::Radian(radians));
}

__EXPORT void __ENTRY camera_yaw(HCamera camera, float radians)
{
	asCamera(camera)->yaw(Ogre::Radian(radians));
}

__EXPORT void __ENTRY camera_pitch(HCamera camera, float radians)
{
	asCamera(camera)->pitch(Ogre::Radian(radians));
}

__EXPORT void __ENTRY camera_rotate(HCamera camera, Vector3f axis, float radians)
{
	asCamera(camera)->rotate(fromVector3f(axis), Ogre::Radian(radians));
}

__EXPORT void __ENTRY camera_rotate_by_quaternion(HCamera camera, Quaternion q)
{
	asCamera(camera)->rotate(fromQuaternion(q));
}

__EXPORT void __ENTRY camera_set_fixed_yaw_axis2(HCamera camera, Bool useFixed)
{
	asCamera(camera)->setFixedYawAxis(fromBool(useFixed));
}

__EXPORT void __ENTRY camera_set_fixed_yaw_axis(HCamera camera, Bool useFixed, Vector3f fixedAxis)
{
	asCamera(camera)->setFixedYawAxis(fromBool(useFixed), fromVector3f(fixedAxis));
}

__EXPORT Quaternion __ENTRY camera_get_orientation(HCamera camera)
{
	Ogre::Quaternion q = asCamera(camera)->getOrientation();

	return toQuaternion(q);
}

__EXPORT void __ENTRY camera_set_orientation(HCamera camera, Quaternion orientation)
{
	asCamera(camera)->setOrientation(fromQuaternion(orientation));
}

__EXPORT void __ENTRY camera_set_auto_tracking3(HCamera camera, Bool enabled)
{
	asCamera(camera)->setAutoTracking(fromBool(enabled));
}

__EXPORT void __ENTRY camera_set_auto_tracking2(HCamera camera, Bool enabled, HSceneNode target)
{
	asCamera(camera)->setAutoTracking(
				fromBool(enabled),
				asSceneNode(target));
}

__EXPORT void __ENTRY camera_set_auto_tracking(HCamera camera, Bool enabled, HSceneNode target, Vector3f offset)
{
	asCamera(camera)->setAutoTracking(
				fromBool(enabled),
				asSceneNode(target),
				fromVector3f(offset));
}

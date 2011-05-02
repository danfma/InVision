#include "cCamera.h"
#include "cTypeConvert.h"

using namespace invision;

INV_EXPORT void INV_CALL camera_delete(HCamera camera)
{
	delete asCamera(camera);
}

INV_EXPORT _float INV_CALL camera_get_aspect_ratio(HCamera camera)
{
	return asCamera(camera)->getAspectRatio();
}

INV_EXPORT void INV_CALL camera_set_aspect_ratio(HCamera camera, _float aspectRatio)
{
	asCamera(camera)->setAspectRatio(aspectRatio);
}

INV_EXPORT _float INV_CALL camera_get_fovy(HCamera camera)
{
	return asCamera(camera)->getFOVy().valueRadians();
}

INV_EXPORT void INV_CALL camera_set_fovy(HCamera camera, _float radians)
{
	asCamera(camera)->setFOVy(Ogre::Radian(radians));
}

INV_EXPORT _float INV_CALL camera_get_near_clip_distance(HCamera camera)
{
	return asCamera(camera)->getNearClipDistance();
}

INV_EXPORT void INV_CALL camera_set_near_clip_distance(HCamera camera, _float distance)
{
	asCamera(camera)->setNearClipDistance(distance);
}

INV_EXPORT _float INV_CALL camera_get_far_clip_distance(HCamera camera)
{
	return asCamera(camera)->getFarClipDistance();
}

INV_EXPORT void INV_CALL camera_set_far_clip_distance(HCamera camera, _float distance)
{
	asCamera(camera)->setFarClipDistance(distance);
}

INV_EXPORT PolygonModeEnum INV_CALL camera_get_polygon_mode(HCamera camera)
{
	return (PolygonModeEnum)asCamera(camera)->getPolygonMode();
}

INV_EXPORT void INV_CALL camera_set_polygon_mode(HCamera camera, PolygonModeEnum polygonMode)
{
	asCamera(camera)->setPolygonMode((Ogre::PolygonMode)polygonMode);
}

INV_EXPORT Vector3 INV_CALL camera_get_position(HCamera camera)
{
	Ogre::Vector3 v = asCamera(camera)->getPosition();

	return toVector3(v);
}

INV_EXPORT void INV_CALL camera_set_position(HCamera camera, Vector3 position)
{
	Ogre::Vector3 v = fromVector3(position);

	asCamera(camera)->setPosition(v);
}

INV_EXPORT void INV_CALL camera_move(HCamera camera, Vector3 position)
{
	asCamera(camera)->move(fromVector3(position));
}

INV_EXPORT void INV_CALL camera_move_relative(HCamera camera, Vector3 position)
{
	asCamera(camera)->moveRelative(fromVector3(position));
}

INV_EXPORT void INV_CALL camera_set_auto_aspect_ratio(HCamera camera, _bool autoRatio)
{
	asCamera(camera)->setAutoAspectRatio(fromBool(autoRatio));
}

INV_EXPORT Vector3 INV_CALL camera_get_direction(HCamera camera)
{
	Ogre::Vector3 direction = asCamera(camera)->getDirection();

	return toVector3(direction);
}

INV_EXPORT void INV_CALL camera_set_direction(HCamera camera, Vector3 position)
{
	asCamera(camera)->setDirection(fromVector3(position));
}

INV_EXPORT Vector3 INV_CALL camera_get_up(HCamera camera)
{
	Ogre::Vector3 up = asCamera(camera)->getUp();

	return toVector3(up);
}

INV_EXPORT Vector3 INV_CALL camera_get_right(HCamera camera)
{
	Ogre::Vector3 right = asCamera(camera)->getRight();

	return toVector3(right);
}

INV_EXPORT void INV_CALL camera_look_at(HCamera camera, Vector3 targetPoint)
{
	asCamera(camera)->lookAt(fromVector3(targetPoint));
}

INV_EXPORT void INV_CALL camera_look_at_3f(HCamera camera, _float x, _float y, _float z)
{
	asCamera(camera)->lookAt(x, y, z);
}

INV_EXPORT void INV_CALL camera_roll(HCamera camera, _float radians)
{
	asCamera(camera)->roll(Ogre::Radian(radians));
}

INV_EXPORT void INV_CALL camera_yaw(HCamera camera, _float radians)
{
	asCamera(camera)->yaw(Ogre::Radian(radians));
}

INV_EXPORT void INV_CALL camera_pitch(HCamera camera, _float radians)
{
	asCamera(camera)->pitch(Ogre::Radian(radians));
}

INV_EXPORT void INV_CALL camera_rotate(HCamera camera, Vector3 axis, _float radians)
{
	asCamera(camera)->rotate(fromVector3(axis), Ogre::Radian(radians));
}

INV_EXPORT void INV_CALL camera_rotate_by_quaternion(HCamera camera, Quaternion q)
{
	asCamera(camera)->rotate(fromQuaternion(q));
}

INV_EXPORT void INV_CALL camera_set_fixed_yaw_axis2(HCamera camera, _bool useFixed)
{
	asCamera(camera)->setFixedYawAxis(fromBool(useFixed));
}

INV_EXPORT void INV_CALL camera_set_fixed_yaw_axis(HCamera camera, _bool useFixed, Vector3 fixedAxis)
{
	asCamera(camera)->setFixedYawAxis(fromBool(useFixed), fromVector3(fixedAxis));
}

INV_EXPORT Quaternion INV_CALL camera_get_orientation(HCamera camera)
{
	Ogre::Quaternion q = asCamera(camera)->getOrientation();

	return toQuaternion(q);
}

INV_EXPORT void INV_CALL camera_set_orientation(HCamera camera, Quaternion orientation)
{
	asCamera(camera)->setOrientation(fromQuaternion(orientation));
}

INV_EXPORT void INV_CALL camera_set_auto_tracking3(HCamera camera, _bool enabled)
{
	asCamera(camera)->setAutoTracking(fromBool(enabled));
}

INV_EXPORT void INV_CALL camera_set_auto_tracking2(HCamera camera, _bool enabled, HSceneNode target)
{
	asCamera(camera)->setAutoTracking(
				fromBool(enabled),
				asSceneNode(target));
}

INV_EXPORT void INV_CALL camera_set_auto_tracking(HCamera camera, _bool enabled, HSceneNode target, Vector3 offset)
{
	asCamera(camera)->setAutoTracking(
				fromBool(enabled),
				asSceneNode(target),
				fromVector3(offset));
}

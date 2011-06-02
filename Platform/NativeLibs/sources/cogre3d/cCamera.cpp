#include "cOgre.h"

INV_EXPORT Vector3
INV_CALL camera_get_position(InvHandle self)
{
	const Ogre::Vector3& result = asCamera(self)->getPosition();

	return create_vector3f(result.x, result.y, result.z);
}

/**
 * Method: Camera::setPosition
 */
INV_EXPORT void
INV_CALL camera_set_position(InvHandle self, Vector3 pos)
{
	asCamera(self)->setPosition(pos.x, pos.y, pos.z);
}

/**
 * Method: Camera::lookAt
 */
INV_EXPORT void
INV_CALL camera_look_at(InvHandle self, Vector3 direction)
{
	asCamera(self)->lookAt(direction.x, direction.y, direction.z);
}

INV_EXPORT _float
INV_CALL camera_get_near_clip_distance(InvHandle self)
{
	return asCamera(self)->getNearClipDistance();
}

/**
 * Method: Camera::setNearClipDistance
 */
INV_EXPORT void
INV_CALL camera_set_near_clip_distance(InvHandle self, _float distance)
{
	asCamera(self)->setNearClipDistance(distance);
}

INV_EXPORT _float
INV_CALL camera_get_aspect_ratio(InvHandle self)
{
	return asCamera(self)->getAspectRatio();
}

/**
 * Method: Camera::setAspectRatio
 */
INV_EXPORT void
INV_CALL camera_set_aspect_ratio(InvHandle self, _float aspectRatio)
{
	asCamera(self)->setAspectRatio(aspectRatio);
}

INV_EXPORT _float
INV_CALL camera_get_far_clip_distance(InvHandle self)
{
	return asCamera(self)->getFarClipDistance();
}

INV_EXPORT void
INV_CALL camera_set_far_clip_distance(InvHandle self, _float value)
{
	asCamera(self)->setFarClipDistance(value);
}

INV_EXPORT void
INV_CALL camera_set_auto_aspect_ratio(InvHandle self, _bool value)
{
	asCamera(self)->setAutoAspectRatio(fromBool(value));
}

INV_EXPORT POLYGON_MODE
INV_CALL camera_get_polygon_mode(InvHandle self)
{
	return asCamera(self)->getPolygonMode();
}

INV_EXPORT void
INV_CALL camera_set_polygon_mode(InvHandle self, POLYGON_MODE value)
{
	asCamera(self)->setPolygonMode((Ogre::PolygonMode)value);
}

INV_EXPORT Vector3
INV_CALL camera_get_direction(InvHandle self)
{
	return vector3_convert_from_ogre(asCamera(self)->getDirection());
}

INV_EXPORT Vector3
INV_CALL camera_get_right(InvHandle self)
{
	return vector3_convert_from_ogre(asCamera(self)->getRight());
}

INV_EXPORT Vector3
INV_CALL camera_get_up(InvHandle self)
{
	return vector3_convert_from_ogre(asCamera(self)->getUp());
}

INV_EXPORT void
INV_CALL camera_move(InvHandle self, Vector3 distance)
{
	asCamera(self)->move(vector3_convert_to_ogre(distance));
}

INV_EXPORT void
INV_CALL camera_yaw(InvHandle self, _float valueRadians)
{
	asCamera(self)->yaw(Ogre::Radian(valueRadians));
}

INV_EXPORT void
INV_CALL camera_pitch(InvHandle self, _float valueRadians)
{
	asCamera(self)->pitch(Ogre::Radian(valueRadians));
}

INV_EXPORT _float
INV_CALL camera_get_fov_y(InvHandle self)
{
	return asCamera(self)->getFOVy().valueRadians();
}

INV_EXPORT void
INV_CALL camera_set_fov_y(InvHandle self, _float value)
{
	asCamera(self)->setFOVy(Ogre::Radian(value));
}

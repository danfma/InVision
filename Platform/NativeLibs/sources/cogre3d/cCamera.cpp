#include "cOgre.h"

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

/**
 * Method: Camera::setNearClipDistance
 */
INV_EXPORT void
INV_CALL camera_set_near_clip_distance(InvHandle self, _float distance)
{
	asCamera(self)->setNearClipDistance(distance);
}

/**
 * Method: Camera::setAspectRatio
 */
INV_EXPORT void
INV_CALL camera_set_aspect_ratio(InvHandle self, _float aspectRatio)
{
	asCamera(self)->setAspectRatio(aspectRatio);
}

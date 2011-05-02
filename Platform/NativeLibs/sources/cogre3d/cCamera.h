#ifndef CAMERA_H
#define CAMERA_H

#include "cOgre.h"

extern "C"
{
	INV_EXPORT void INV_CALL camera_delete(HCamera camera);

	INV_EXPORT _float INV_CALL camera_get_aspect_ratio(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_aspect_ratio(HCamera camera, _float aspectRatio);

	INV_EXPORT _float INV_CALL camera_get_fovy(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_fovy(HCamera camera, _float radians);

	INV_EXPORT _float INV_CALL camera_get_near_clip_distance(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_near_clip_distance(HCamera camera, _float distance);

	INV_EXPORT _float INV_CALL camera_get_far_clip_distance(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_far_clip_distance(HCamera camera, _float distance);

	INV_EXPORT PolygonModeEnum INV_CALL camera_get_polygon_mode(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_polygon_mode(HCamera camera, PolygonModeEnum polygonMode);

	INV_EXPORT Vector3 INV_CALL camera_get_position(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_position(HCamera camera, Vector3 position);

	INV_EXPORT void INV_CALL camera_move(HCamera camera, Vector3 position);
	INV_EXPORT void INV_CALL camera_move_relative(HCamera camera, Vector3 position);

	INV_EXPORT void INV_CALL camera_set_auto_aspect_ratio(HCamera camera, _bool autoRatio);

	INV_EXPORT Vector3 INV_CALL camera_get_direction(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_direction(HCamera camera, Vector3 position);

	INV_EXPORT Vector3 INV_CALL camera_get_up(HCamera camera);
	INV_EXPORT Vector3 INV_CALL camera_get_right(HCamera camera);

	INV_EXPORT void INV_CALL camera_look_at(HCamera camera, Vector3 targetPoint);
	INV_EXPORT void INV_CALL camera_look_at_3f(HCamera camera, _float x, _float y, _float z);

	INV_EXPORT void INV_CALL camera_roll(HCamera camera, _float radians);
	INV_EXPORT void INV_CALL camera_yaw(HCamera camera, _float radians);
	INV_EXPORT void INV_CALL camera_pitch(HCamera camera, _float radians);

	INV_EXPORT void INV_CALL camera_rotate(HCamera camera, Vector3 axis, _float radians);
	INV_EXPORT void INV_CALL camera_rotate_by_quaternion(HCamera camera, Quaternion q);

	INV_EXPORT void INV_CALL camera_set_fixed_yaw_axis2(HCamera camera, _bool useFixed);
	INV_EXPORT void INV_CALL camera_set_fixed_yaw_axis(HCamera camera, _bool useFixed, Vector3 fixedAxis);

	INV_EXPORT Quaternion INV_CALL camera_get_orientation(HCamera camera);
	INV_EXPORT void INV_CALL camera_set_orientation(HCamera camera, Quaternion orientation);

	INV_EXPORT void INV_CALL camera_set_auto_tracking3(HCamera camera, _bool enabled);
	INV_EXPORT void INV_CALL camera_set_auto_tracking2(HCamera camera, _bool enabled, HSceneNode target);
	INV_EXPORT void INV_CALL camera_set_auto_tracking(HCamera camera, _bool enabled, HSceneNode target, Vector3 offset);
}

#endif // CAMERA_H

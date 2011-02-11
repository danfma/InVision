#ifndef CAMERA_H
#define CAMERA_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT void __ENTRY camera_delete(HCamera camera);

	__EXPORT float __ENTRY camera_get_aspect_ratio(HCamera camera);
	__EXPORT void __ENTRY camera_set_aspect_ratio(HCamera camera, float aspectRatio);

	__EXPORT float __ENTRY camera_get_fovy(HCamera camera);
	__EXPORT void __ENTRY camera_set_fovy(HCamera camera, float radians);

	__EXPORT float __ENTRY camera_get_near_clip_distance(HCamera camera);
	__EXPORT void __ENTRY camera_set_near_clip_distance(HCamera camera, float distance);

	__EXPORT float __ENTRY camera_get_far_clip_distance(HCamera camera);
	__EXPORT void __ENTRY camera_set_far_clip_distance(HCamera camera, float distance);

	__EXPORT PolygonModeEnum __ENTRY camera_get_polygon_mode(HCamera camera);
	__EXPORT void __ENTRY camera_set_polygon_mode(HCamera camera, PolygonModeEnum polygonMode);

	__EXPORT Vector3f __ENTRY camera_get_position(HCamera camera);
	__EXPORT void __ENTRY camera_set_position(HCamera camera, Vector3f position);

	__EXPORT void __ENTRY camera_move(HCamera camera, Vector3f position);
	__EXPORT void __ENTRY camera_move_relative(HCamera camera, Vector3f position);

	/* NEW BELOW */
	__EXPORT void __ENTRY camera_set_auto_aspect_ratio(HCamera camera, Bool autoRatio);

	__EXPORT Vector3f __ENTRY camera_get_direction(HCamera camera);
	__EXPORT void __ENTRY camera_set_direction(HCamera camera, Vector3f position);

	__EXPORT Vector3f __ENTRY camera_get_up(HCamera camera);
	__EXPORT Vector3f __ENTRY camera_get_right(HCamera camera);

	__EXPORT void __ENTRY camera_look_at(HCamera camera, Vector3f targetPoint);
	__EXPORT void __ENTRY camera_look_at_3f(HCamera camera, float x, float y, float z);

	__EXPORT void __ENTRY camera_roll(HCamera camera, float radians);
	__EXPORT void __ENTRY camera_yaw(HCamera camera, float radians);
	__EXPORT void __ENTRY camera_pitch(HCamera camera, float radians);

	__EXPORT void __ENTRY camera_rotate(HCamera camera, Vector3f axis, float radians);
	__EXPORT void __ENTRY camera_rotate_by_quaternion(HCamera camera, Quaternion q);

	__EXPORT void __ENTRY camera_set_fixed_yaw_axis2(HCamera camera, Bool useFixed);
	__EXPORT void __ENTRY camera_set_fixed_yaw_axis(HCamera camera, Bool useFixed, Vector3f fixedAxis);

	__EXPORT Quaternion __ENTRY camera_get_orientation(HCamera camera);
	__EXPORT void __ENTRY camera_set_orientation(HCamera camera, Quaternion orientation);

	__EXPORT void __ENTRY camera_set_auto_tracking3(HCamera camera, Bool enabled);
	__EXPORT void __ENTRY camera_set_auto_tracking2(HCamera camera, Bool enabled, HSceneNode target);
	__EXPORT void __ENTRY camera_set_auto_tracking(HCamera camera, Bool enabled, HSceneNode target, Vector3f offset);
}

#endif // CAMERA_H

#ifndef CAMERA_H
#define CAMERA_H

#include "invision/Common.h"

extern "C"
{
	__export void __entry camera_delete(HCamera camera);

	__export float __entry camera_get_aspect_ratio(HCamera camera);
	__export void __entry camera_set_aspect_ratio(HCamera camera, float aspectRatio);

	__export float __entry camera_get_fovy(HCamera camera);
	__export void __entry camera_set_fovy(HCamera camera, float radians);

	__export float __entry camera_get_near_clip_distance(HCamera camera);
	__export void __entry camera_set_near_clip_distance(HCamera camera, float distance);

	__export float __entry camera_get_far_clip_distance(HCamera camera);
	__export void __entry camera_set_far_clip_distance(HCamera camera, float distance);

	__export PolygonModeEnum __entry camera_get_polygon_mode(HCamera camera);
	__export void __entry camera_set_polygon_mode(HCamera camera, PolygonModeEnum polygonMode);

	__export Vector3 __entry camera_get_position(HCamera camera);
	__export void __entry camera_set_position(HCamera camera, Vector3 position);

	__export void __entry camera_move(HCamera camera, Vector3 position);
	__export void __entry camera_move_relative(HCamera camera, Vector3 position);

	__export void __entry camera_set_auto_aspect_ratio(HCamera camera, Bool autoRatio);

	__export Vector3 __entry camera_get_direction(HCamera camera);
	__export void __entry camera_set_direction(HCamera camera, Vector3 position);

	__export Vector3 __entry camera_get_up(HCamera camera);
	__export Vector3 __entry camera_get_right(HCamera camera);

	__export void __entry camera_look_at(HCamera camera, Vector3 targetPoint);
	__export void __entry camera_look_at_3f(HCamera camera, float x, float y, float z);

	__export void __entry camera_roll(HCamera camera, float radians);
	__export void __entry camera_yaw(HCamera camera, float radians);
	__export void __entry camera_pitch(HCamera camera, float radians);

	__export void __entry camera_rotate(HCamera camera, Vector3 axis, float radians);
	__export void __entry camera_rotate_by_quaternion(HCamera camera, Quaternion q);

	__export void __entry camera_set_fixed_yaw_axis2(HCamera camera, Bool useFixed);
	__export void __entry camera_set_fixed_yaw_axis(HCamera camera, Bool useFixed, Vector3 fixedAxis);

	__export Quaternion __entry camera_get_orientation(HCamera camera);
	__export void __entry camera_set_orientation(HCamera camera, Quaternion orientation);

	__export void __entry camera_set_auto_tracking3(HCamera camera, Bool enabled);
	__export void __entry camera_set_auto_tracking2(HCamera camera, Bool enabled, HSceneNode target);
	__export void __entry camera_set_auto_tracking(HCamera camera, Bool enabled, HSceneNode target, Vector3 offset);
}

#endif // CAMERA_H

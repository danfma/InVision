#ifndef CAMERA_H
#define CAMERA_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT void __ENTRY CamDelete(HCamera camera);

	__EXPORT float __ENTRY CamGetAspectRatio(HCamera camera);
	__EXPORT void __ENTRY CamSetAspectRatio(HCamera camera, float aspectRatio);

	__EXPORT float __ENTRY CamGetFOVy(HCamera camera);
	__EXPORT void __ENTRY CamSetFOVy(HCamera camera, float radians);

	__EXPORT float __ENTRY CamGetNearClipDistance(HCamera camera);
	__EXPORT void __ENTRY CamSetNearClipDistance(HCamera camera, float distance);

	__EXPORT float __ENTRY CamGetFarClipDistance(HCamera camera);
	__EXPORT void __ENTRY CamSetFarClipDistance(HCamera camera, float distance);

	__EXPORT PolygonModeEnum __ENTRY CamGetPolygonMode(HCamera camera);
	__EXPORT void __ENTRY CamSetPolygonMode(HCamera camera, PolygonModeEnum polygonMode);

	__EXPORT Vector3f __ENTRY CamGetPosition(HCamera camera);
	__EXPORT void __ENTRY CamSetPosition(HCamera camera, Vector3f position);
}

#endif // CAMERA_H

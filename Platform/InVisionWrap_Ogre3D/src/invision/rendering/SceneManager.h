#ifndef SCENEMANAGER_H
#define SCENEMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT void __ENTRY scenemanager_delete(HSceneManager self);
	__EXPORT HCamera __ENTRY scenemanager_create_camera(HSceneManager self, const char* name);
}

#endif // SCENEMANAGER_H

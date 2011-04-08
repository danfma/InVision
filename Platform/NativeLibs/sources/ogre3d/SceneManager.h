#ifndef SCENEMANAGER_H
#define SCENEMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__export void __entry scenemanager_delete(HSceneManager self);
	__export HCamera __entry scenemanager_create_camera(HSceneManager self, const char* name);
}

#endif // SCENEMANAGER_H

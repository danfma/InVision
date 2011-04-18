#ifndef SCENEMANAGER_H
#define SCENEMANAGER_H

#include "cOgre.h"

extern "C"
{
	__export void __entry scenemanager_delete(HSceneManager self);
	__export HCamera __entry scenemanager_create_camera(HSceneManager self, const _string name);
}

#endif // SCENEMANAGER_H

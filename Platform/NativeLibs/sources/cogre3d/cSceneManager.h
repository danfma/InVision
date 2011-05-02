#ifndef SCENEMANAGER_H
#define SCENEMANAGER_H

#include "cOgre.h"

extern "C"
{
	INV_EXPORT void INV_CALL scenemanager_delete(HSceneManager self);
	INV_EXPORT HCamera INV_CALL scenemanager_create_camera(HSceneManager self, const _string name);
}

#endif // SCENEMANAGER_H

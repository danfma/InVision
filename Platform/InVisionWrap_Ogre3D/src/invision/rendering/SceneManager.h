#ifndef SCENEMANAGER_H
#define SCENEMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT void __ENTRY ScnMngrDelete(HSceneManager self);
	__EXPORT HCamera __ENTRY ScnMngrCreateCamera(HSceneManager self, const char* name);
}

#endif // SCENEMANAGER_H

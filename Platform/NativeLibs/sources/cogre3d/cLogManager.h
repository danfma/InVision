#ifndef LOGMANAGER_H
#define LOGMANAGER_H

#include "OgreCommon.h"

extern "C"
{
	__export HLogManager __entry ogre_logmanager_get_singleton();
	
	__export void __entry ogre_logmanager_log_message(
		HLogManager self,
		ConstString message,
		_int messageLevel,
		_bool maskDebug);
};

#ifdef __cplusplus
#include <Ogre.h>

namespace invision
{
	Ogre::LogManager* asLogManager(HLogManager handle)
	{
		return (Ogre::LogManager*)handle;
	}
}

#endif

#endif // LOGMANAGER_H

#include "LogManager.h"

using namespace invision;

INV_EXPORT HLogManager INV_CALL ogre_logmanager_get_singleton()
{
	return Ogre::LogManager::getSingletonPtr();
}

INV_EXPORT void INV_CALL ogre_logmanager_log_message(
		HLogManager self,
		ConstString message,
		_int messageLevel,
		_bool maskDebug)
{
	asLogManager(self)->logMessage(message, (Ogre::LogMessageLevel)messageLevel, fromBool(maskDebug));
}

#include "cOgre.h"

using namespace Ogre;

/**
 * Method: LogManager::LogManager
 */
INV_EXPORT InvHandle
INV_CALL new_logmanager()
{
	return createHandle<LogManager>(new LogManager());
}

/**
 * Method: LogManager::~LogManager
 */
INV_EXPORT void
INV_CALL delete_logmanager(InvHandle self)
{
	destroyHandle(self);
}

/**
 * Method: LogManager::createLog
 */
INV_EXPORT InvHandle
INV_CALL logmanager_create_log(InvHandle self, _string name, _bool defaultLog, _bool debuggerOutput, _bool suppressFileOutput)
{
	return createReference<Log>(
				asLogManager(self)->createLog(
					name,
					fromBool(defaultLog),
					fromBool(debuggerOutput),
					fromBool(suppressFileOutput)));
}

/**
 * Method: LogManager::getLog
 */
INV_EXPORT InvHandle
INV_CALL logmanager_get_log(InvHandle self, _string name)
{
	return getOrCreateReference<Log>(
				asLogManager(self)->getLog(name));
}

/**
 * Method: LogManager::getDefaultLog
 */
INV_EXPORT InvHandle
INV_CALL logmanager_get_default_log(InvHandle self)
{
	return getOrCreateReference<Log>(
				asLogManager(self)->getDefaultLog());
}

/**
 * Method: LogManager::destroyLog
 */
INV_EXPORT void
INV_CALL logmanager_destroy_log_m1(InvHandle self, _string name)
{
	Log* log = asLogManager(self)->getLog(name);

	destroyHandle(getOrCreateReference<Log>(log));
	asLogManager(self)->destroyLog(name);
}

/**
 * Method: LogManager::destroyLog
 */
INV_EXPORT void
INV_CALL logmanager_destroy_log_m2(InvHandle self, InvHandle log)
{
	Log* logInstance = asLog(log);

	destroyHandle(getOrCreateReference<Log>(logInstance));
	asLogManager(self)->destroyLog(logInstance);
}

/**
 * Method: LogManager::setDefaultLog
 */
INV_EXPORT InvHandle
INV_CALL logmanager_set_default_log(InvHandle self, InvHandle log)
{
	return getOrCreateReference<Log>(
				asLogManager(self)->setDefaultLog(
					asLog(log)));
}

/**
 * Method: LogManager::logMessage
 */
INV_EXPORT void
INV_CALL logmanager_log_message(InvHandle self, _string message, LOG_MESSAGE_LEVEL logLevel, _bool maskDebug)
{
	asLogManager(self)->logMessage(
				message,
				(Ogre::LogMessageLevel)logLevel,
				fromBool(maskDebug));
}

/**
 * Method: LogManager::setLogDetail
 */
INV_EXPORT void
INV_CALL logmanager_set_log_detail(InvHandle self, LOGGING_LEVEL level)
{
	asLogManager(self)->setLogDetail((LoggingLevel)level);
}

/**
 * Method: LogManager::getSingleton
 */
INV_EXPORT InvHandle
INV_CALL logmanager_get_singleton()
{
	return getOrCreateReference<LogManager>(LogManager::getSingletonPtr());
}

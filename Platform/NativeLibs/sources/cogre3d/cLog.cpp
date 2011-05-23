#include "cOgre.h"

/**
 * Method: Log::addListener
 */
INV_EXPORT void
INV_CALL log_add_listener(InvHandle self, InvHandle listener)
{
	asLog(self)->addListener(asCustomLogListener(listener));
}

/**
 * Method: Log::removeListener
 */
INV_EXPORT void
INV_CALL log_remove_listener(InvHandle self, InvHandle listener)
{
	asLog(self)->removeListener(asCustomLogListener(listener));
}

/**
 * Method: Log::getName
 */
INV_EXPORT _string
INV_CALL log_get_name(InvHandle self)
{
	return copyString(asLog(self)->getName());
}

/**
 * Method: Log::isDebugOutputEnabled
 */
INV_EXPORT _bool
INV_CALL log_is_debug_output_enabled(InvHandle self)
{
	return toBool(
				asLog(self)->isDebugOutputEnabled());
}

/**
 * Method: Log::isFileOutputSuppressed
 */
INV_EXPORT _bool
INV_CALL log_is_file_output_suppressed(InvHandle self)
{
	return toBool(
				asLog(self)->isFileOutputSuppressed());
}

/**
 * Method: Log::isTimeStampEnabled
 */
INV_EXPORT _bool
INV_CALL log_is_time_stamp_enabled(InvHandle self)
{
	return toBool(
				asLog(self)->isTimeStampEnabled());
}

/**
 * Method: Log::logMessage
 */
INV_EXPORT void
INV_CALL log_log_message(InvHandle self, _string message, LOG_MESSAGE_LEVEL level, _bool maskDebug)
{
	asLog(self)->logMessage(message, (Ogre::LogMessageLevel)level, fromBool(maskDebug));
}

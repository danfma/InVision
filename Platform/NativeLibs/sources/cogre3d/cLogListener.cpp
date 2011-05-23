#include "cOgre.h"
#include "cCustomLogListener.h"

/**
 * Method: CustomLogListener::CustomLogListener
 */
INV_EXPORT InvHandle
INV_CALL new_customloglistener(LogListenerMessageLoggedHandler messageLoggedHandler)
{
	return createHandle<CustomLogListener>(
				new CustomLogListener(
					messageLoggedHandler));
}


/**
 * Method: CustomLogListener::~CustomLogListener
 */
INV_EXPORT void
INV_CALL delete_customloglistener(InvHandle self)
{
	destroyHandle(self);
}

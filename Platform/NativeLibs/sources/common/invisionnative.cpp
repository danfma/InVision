#include "invisionnative.h"

/**
 * Method: HandleManager::registerHandleDestroyed
 */
INV_EXPORT void
INV_CALL handlemanager_register_handle_destroyed(HandleListenerHandleDestroyedHandler handleDestroyed)
{
	HandleManager::getInstance()->setHandleDestroyedListener(handleDestroyed);
}


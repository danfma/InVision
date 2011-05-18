#include "cOIS.h"

/**
 * Method: Interface::~Interface
 */
INV_EXPORT void
INV_CALL delete_interface(InvHandle self) {
	destroyHandle(self);
}

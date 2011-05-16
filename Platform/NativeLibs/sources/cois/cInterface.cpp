#include "cOIS.h"

/**
 * Method: Interface::~Interface
 */
INV_EXPORT void
INV_CALL delete_deviceinterface(InvHandle self)
{
	invision::destroyHandle(self);
}

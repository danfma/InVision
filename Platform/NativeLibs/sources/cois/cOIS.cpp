#include "cOIS.h"
#include <OIS.h>

/*
 * GLOBALS
 */
OISStartUp startup;

INV_EXPORT RegisteredTypeItem*
INV_CALL register_ois_types(int* count)
{
	return startup.getRegisteredTypes(count);
}


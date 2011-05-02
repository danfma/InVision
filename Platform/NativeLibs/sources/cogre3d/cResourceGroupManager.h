#ifndef RESOURCEGROUPMANAGER_H
#define RESOURCEGROUPMANAGER_H

#include "cOgre.h"

extern "C"
{
	INV_EXPORT HResourceGroupManager INV_CALL resgroupmng_get_singleton();

	INV_EXPORT void INV_CALL resgroupmng_initialise_all_resource_groups(HResourceGroupManager pSelf);

	INV_EXPORT void INV_CALL resgroupmng_add_resource_location(
		HResourceGroupManager pSelf,
		ConstString name,
		ConstString locationType,
		ConstString resourceGroup,
		_bool recursive);
}

#endif // RESOURCEGROUPMANAGER_H

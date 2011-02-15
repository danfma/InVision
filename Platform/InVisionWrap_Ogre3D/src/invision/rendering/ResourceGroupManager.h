#ifndef RESOURCEGROUPMANAGER_H
#define RESOURCEGROUPMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT HResourceGroupManager __ENTRY resgroupmng_get_singleton();

	__EXPORT void __ENTRY resgroupmng_initialise_all_resource_groups(HResourceGroupManager pSelf);

	__EXPORT void __ENTRY resgroupmng_add_resource_location(
		HResourceGroupManager pSelf,
		ConstString name,
		ConstString locationType,
		ConstString resourceGroup,
		Bool recursive);
}

#endif // RESOURCEGROUPMANAGER_H

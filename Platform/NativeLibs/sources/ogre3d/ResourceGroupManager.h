#ifndef RESOURCEGROUPMANAGER_H
#define RESOURCEGROUPMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__export HResourceGroupManager __entry resgroupmng_get_singleton();

	__export void __entry resgroupmng_initialise_all_resource_groups(HResourceGroupManager pSelf);

	__export void __entry resgroupmng_add_resource_location(
		HResourceGroupManager pSelf,
		ConstString name,
		ConstString locationType,
		ConstString resourceGroup,
		Bool recursive);
}

#endif // RESOURCEGROUPMANAGER_H

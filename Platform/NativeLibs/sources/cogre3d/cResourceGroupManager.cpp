#include "ResourceGroupManager.h"
#include "TypeConvert.h"
#include <Ogre.h>

using namespace invision;

__export HResourceGroupManager __entry resgroupmng_get_singleton()
{
	return Ogre::ResourceGroupManager::getSingletonPtr();
}

__export void __entry resgroupmng_initialise_all_resource_groups(HResourceGroupManager pSelf)
{
	asResGroupManager(pSelf)->initialiseAllResourceGroups();
}

__export void __entry resgroupmng_add_resource_location(
	HResourceGroupManager pSelf,
	ConstString name,
	ConstString locationType,
	ConstString resourceGroup,
	_bool recursive)
{
	asResGroupManager(pSelf)->addResourceLocation(
				name,
				locationType,
				resourceGroup,
				fromBool(recursive));
}

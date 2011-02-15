#include "ResourceGroupManager.h"
#include "invision/Util.h"
#include <Ogre.h>

using namespace invision;

__EXPORT HResourceGroupManager __ENTRY resgroupmng_get_singleton()
{
	return Ogre::ResourceGroupManager::getSingletonPtr();
}

__EXPORT void __ENTRY resgroupmng_initialise_all_resource_groups(HResourceGroupManager pSelf)
{
	asResGroupManager(pSelf)->initialiseAllResourceGroups();
}

__EXPORT void __ENTRY resgroupmng_add_resource_location(
	HResourceGroupManager pSelf,
	ConstString name,
	ConstString locationType,
	ConstString resourceGroup,
	Bool recursive)
{
	asResGroupManager(pSelf)->addResourceLocation(
				name,
				locationType,
				resourceGroup,
				fromBool(recursive));
}

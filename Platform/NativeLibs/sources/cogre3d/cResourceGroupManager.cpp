#include "ResourceGroupManager.h"
#include "TypeConvert.h"
#include <Ogre.h>

using namespace invision;

INV_EXPORT HResourceGroupManager INV_CALL resgroupmng_get_singleton()
{
	return Ogre::ResourceGroupManager::getSingletonPtr();
}

INV_EXPORT void INV_CALL resgroupmng_initialise_all_resource_groups(HResourceGroupManager pSelf)
{
	asResGroupManager(pSelf)->initialiseAllResourceGroups();
}

INV_EXPORT void INV_CALL resgroupmng_add_resource_location(
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

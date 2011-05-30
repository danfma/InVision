#include "cOgre.h"

INV_EXPORT void
INV_CALL resourcegroupmanager_add_resource_location_m1(InvHandle self, _string name, _string locType)
{
	asResourceGroupManager(self)->addResourceLocation(name, locType);
}

INV_EXPORT void
INV_CALL resourcegroupmanager_add_resource_location_m2(InvHandle self, _string name, _string locType, _string resGroup)
{
	asResourceGroupManager(self)->addResourceLocation(name, locType, resGroup);
}

INV_EXPORT void
INV_CALL resourcegroupmanager_add_resource_location_m3(InvHandle self, _string name, _string locType, _string resGroup, _bool recursive)
{
	asResourceGroupManager(self)->addResourceLocation(name, locType, resGroup, fromBool(recursive));
}

INV_EXPORT void
INV_CALL resourcegroupmanager_initialize_all_resource_groups(InvHandle self)
{
	asResourceGroupManager(self)->initialiseAllResourceGroups();
}

INV_EXPORT InvHandle
INV_CALL resourcegroupmanager_get_singleton()
{
	return getOrCreateReference<Ogre::ResourceGroupManager>(
				Ogre::ResourceGroupManager::getSingletonPtr());
}

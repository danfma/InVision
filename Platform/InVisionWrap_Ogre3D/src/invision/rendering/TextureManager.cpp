#include "TextureManager.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT HTextureManager __ENTRY texmanager_get_instance()
{
	return Ogre::TextureManager::getSingletonPtr();
}

__EXPORT Int32 __ENTRY texmanager_get_default_num_mipmaps(HTextureManager self)
{
	return asTextureManager(self)->getDefaultNumMipmaps();
}

__EXPORT void __ENTRY texmanager_set_default_num_mipmaps(HTextureManager self, Int32 numMipmaps)
{
	asTextureManager(self)->setDefaultNumMipmaps(numMipmaps);
}

__EXPORT void __ENTRY texmanager_reload_all(HTextureManager self, Bool reloadableOnly)
{
	asTextureManager(self)->reloadAll(fromBool(reloadableOnly));
}

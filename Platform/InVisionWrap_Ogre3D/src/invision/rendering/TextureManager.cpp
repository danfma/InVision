#include "TextureManager.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT HTextureManager __ENTRY texmanager_get_instance()
{
	return Ogre::TextureManager::getSingletonPtr();
}

__EXPORT Int32 __ENTRY texmanager_get_default_num_mipmaps(HTextureManager texmanager)
{
	return asTextureManager(texmanager)->getDefaultNumMipmaps();
}

__EXPORT void __ENTRY texmanager_set_default_num_mipmaps(HTextureManager texmanager, Int32 numMipmaps)
{
	asTextureManager(texmanager)->setDefaultNumMipmaps(numMipmaps);
}

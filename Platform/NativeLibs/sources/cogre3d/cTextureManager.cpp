#include "TextureManager.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT HTextureManager INV_CALL texmanager_get_instance()
{
	return Ogre::TextureManager::getSingletonPtr();
}

INV_EXPORT _int INV_CALL texmanager_get_default_num_mipmaps(HTextureManager self)
{
	return asTextureManager(self)->getDefaultNumMipmaps();
}

INV_EXPORT void INV_CALL texmanager_set_default_num_mipmaps(HTextureManager self, _int numMipmaps)
{
	asTextureManager(self)->setDefaultNumMipmaps(numMipmaps);
}

INV_EXPORT void INV_CALL texmanager_reload_all(HTextureManager self, _bool reloadableOnly)
{
	asTextureManager(self)->reloadAll(fromBool(reloadableOnly));
}

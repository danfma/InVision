#include "TextureManager.h"
#include "TypeConvert.h"

using namespace invision;

__export HTextureManager __entry texmanager_get_instance()
{
	return Ogre::TextureManager::getSingletonPtr();
}

__export _int __entry texmanager_get_default_num_mipmaps(HTextureManager self)
{
	return asTextureManager(self)->getDefaultNumMipmaps();
}

__export void __entry texmanager_set_default_num_mipmaps(HTextureManager self, _int numMipmaps)
{
	asTextureManager(self)->setDefaultNumMipmaps(numMipmaps);
}

__export void __entry texmanager_reload_all(HTextureManager self, _bool reloadableOnly)
{
	asTextureManager(self)->reloadAll(fromBool(reloadableOnly));
}

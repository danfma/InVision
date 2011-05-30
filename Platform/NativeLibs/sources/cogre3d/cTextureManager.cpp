#include "cOgre.h"

INV_EXPORT void
INV_CALL texturemanager_set_default_num_mipmaps(InvHandle self, _int num)
{
	return asTextureManager(self)->setDefaultNumMipmaps(num);
}

INV_EXPORT _int
INV_CALL texturemanager_get_default_num_mipmaps(InvHandle self)
{
	return asTextureManager(self)->getDefaultNumMipmaps();
}

INV_EXPORT void
INV_CALL texturemanager_reload_all(InvHandle self, _bool reloadableOnly)
{
	asTextureManager(self)->reloadAll(fromBool(reloadableOnly));
}

INV_EXPORT InvHandle
INV_CALL texturemanager_get_singleton()
{
	return getOrCreateReference<Ogre::TextureManager>(
				Ogre::TextureManager::getSingletonPtr());
}

#include "cOgre.h"

INV_EXPORT void
INV_CALL materialmanager_set_default_texture_filtering(InvHandle self, TEXTURE_FILTER_OPTION option)
{
	asMaterialManager(self)->setDefaultTextureFiltering(
				(Ogre::TextureFilterOptions)option);
}

INV_EXPORT void
INV_CALL materialmanager_set_default_anisotropy(InvHandle self, _uint max)
{
	asMaterialManager(self)->setDefaultAnisotropy(max);
}

INV_EXPORT _uint
INV_CALL materialmanager_get_default_anisotropy(InvHandle self)
{
	return asMaterialManager(self)->getDefaultAnisotropy();
}

INV_EXPORT InvHandle
INV_CALL materialmanager_get_singleton()
{
	return getOrCreateReference<Ogre::MaterialManager>(
				Ogre::MaterialManager::getSingletonPtr());
}

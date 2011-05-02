#include "MaterialManager.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT HMaterialManager INV_CALL materialmng_get_singleton()
{
	return Ogre::MaterialManager::getSingletonPtr();
}

INV_EXPORT void INV_CALL materialmng_set_default_texture_filtering(HMaterialManager self, _uint option)
{
	asMaterialManager(self)->setDefaultTextureFiltering((Ogre::TextureFilterOptions)option);
}

INV_EXPORT _uint INV_CALL materialmng_get_default_anisotropy(HMaterialManager self)
{
	return asMaterialManager(self)->getDefaultAnisotropy();
}

INV_EXPORT void INV_CALL materialmng_set_default_anisotropy(HMaterialManager self, _uint value)
{
	asMaterialManager(self)->setDefaultAnisotropy(value);
}

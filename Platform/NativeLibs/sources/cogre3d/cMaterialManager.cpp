#include "MaterialManager.h"
#include "TypeConvert.h"

using namespace invision;

__export HMaterialManager __entry materialmng_get_singleton()
{
	return Ogre::MaterialManager::getSingletonPtr();
}

__export void __entry materialmng_set_default_texture_filtering(HMaterialManager self, _uint option)
{
	asMaterialManager(self)->setDefaultTextureFiltering((Ogre::TextureFilterOptions)option);
}

__export _uint __entry materialmng_get_default_anisotropy(HMaterialManager self)
{
	return asMaterialManager(self)->getDefaultAnisotropy();
}

__export void __entry materialmng_set_default_anisotropy(HMaterialManager self, _uint value)
{
	asMaterialManager(self)->setDefaultAnisotropy(value);
}

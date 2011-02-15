#include "MaterialManager.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT HMaterialManager __ENTRY materialmng_get_singleton()
{
	return Ogre::MaterialManager::getSingletonPtr();
}

__EXPORT void __ENTRY materialmng_set_default_texture_filtering(HMaterialManager self, UInt32 option)
{
	asMaterialManager(self)->setDefaultTextureFiltering((Ogre::TextureFilterOptions)option);
}

__EXPORT UInt32 __ENTRY materialmng_get_default_anisotropy(HMaterialManager self)
{
	return asMaterialManager(self)->getDefaultAnisotropy();
}

__EXPORT void __ENTRY materialmng_set_default_anisotropy(HMaterialManager self, UInt32 value)
{
	asMaterialManager(self)->setDefaultAnisotropy(value);
}

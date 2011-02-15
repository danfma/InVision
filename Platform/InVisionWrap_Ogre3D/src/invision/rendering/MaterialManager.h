#ifndef MATERIALMANAGER_H
#define MATERIALMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT HMaterialManager __ENTRY materialmng_get_singleton();

	__EXPORT void __ENTRY materialmng_set_default_texture_filtering(HMaterialManager self, UInt32 option);

	__EXPORT UInt32 __ENTRY materialmng_get_default_anisotropy(HMaterialManager self);
	__EXPORT void __ENTRY materialmng_set_default_anisotropy(HMaterialManager self, UInt32 value);
}

#endif // MATERIALMANAGER_H

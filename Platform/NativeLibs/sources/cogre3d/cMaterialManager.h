#ifndef MATERIALMANAGER_H
#define MATERIALMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__export HMaterialManager __entry materialmng_get_singleton();

	__export void __entry materialmng_set_default_texture_filtering(HMaterialManager self, UInt32 option);

	__export UInt32 __entry materialmng_get_default_anisotropy(HMaterialManager self);
	__export void __entry materialmng_set_default_anisotropy(HMaterialManager self, UInt32 value);
}

#endif // MATERIALMANAGER_H

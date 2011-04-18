#ifndef MATERIALMANAGER_H
#define MATERIALMANAGER_H

#include "cOgre.h"

extern "C"
{
	__export HMaterialManager __entry materialmng_get_singleton();

	__export void __entry materialmng_set_default_texture_filtering(HMaterialManager self, _uint option);

	__export _uint __entry materialmng_get_default_anisotropy(HMaterialManager self);
	__export void __entry materialmng_set_default_anisotropy(HMaterialManager self, _uint value);
}

#endif // MATERIALMANAGER_H

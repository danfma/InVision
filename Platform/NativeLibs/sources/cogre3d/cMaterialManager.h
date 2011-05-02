#ifndef MATERIALMANAGER_H
#define MATERIALMANAGER_H

#include "cOgre.h"

extern "C"
{
	INV_EXPORT HMaterialManager INV_CALL materialmng_get_singleton();

	INV_EXPORT void INV_CALL materialmng_set_default_texture_filtering(HMaterialManager self, _uint option);

	INV_EXPORT _uint INV_CALL materialmng_get_default_anisotropy(HMaterialManager self);
	INV_EXPORT void INV_CALL materialmng_set_default_anisotropy(HMaterialManager self, _uint value);
}

#endif // MATERIALMANAGER_H

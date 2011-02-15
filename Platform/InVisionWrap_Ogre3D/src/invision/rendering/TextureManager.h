#ifndef TEXTUREMANAGER_H
#define TEXTUREMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT HTextureManager __ENTRY texmanager_get_instance();

	__EXPORT Int32 __ENTRY texmanager_get_default_num_mipmaps(HTextureManager self);
	__EXPORT void __ENTRY texmanager_set_default_num_mipmaps(HTextureManager self, Int32 numMipmaps);

	__EXPORT void __ENTRY texmanager_reload_all(HTextureManager self, Bool reloadableOnly);
}

#endif // TEXTUREMANAGER_H

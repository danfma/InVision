#ifndef TEXTUREMANAGER_H
#define TEXTUREMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT HTextureManager __ENTRY texmanager_get_instance();

	__EXPORT Int32 __ENTRY texmanager_get_default_num_mipmaps(HTextureManager texmanager);
	__EXPORT void __ENTRY texmanager_set_default_num_mipmaps(HTextureManager texmanager, Int32 numMipmaps);
}

#endif // TEXTUREMANAGER_H

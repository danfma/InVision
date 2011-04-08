#ifndef TEXTUREMANAGER_H
#define TEXTUREMANAGER_H

#include "invision/Common.h"

extern "C"
{
	__export HTextureManager __entry texmanager_get_instance();

	__export Int32 __entry texmanager_get_default_num_mipmaps(HTextureManager self);
	__export void __entry texmanager_set_default_num_mipmaps(HTextureManager self, Int32 numMipmaps);

	__export void __entry texmanager_reload_all(HTextureManager self, Bool reloadableOnly);
}

#endif // TEXTUREMANAGER_H

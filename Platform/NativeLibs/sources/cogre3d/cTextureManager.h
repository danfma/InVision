#ifndef TEXTUREMANAGER_H
#define TEXTUREMANAGER_H

#include "cOgre.h"

extern "C"
{
	INV_EXPORT HTextureManager INV_CALL texmanager_get_instance();

	INV_EXPORT _int INV_CALL texmanager_get_default_num_mipmaps(HTextureManager self);
	INV_EXPORT void INV_CALL texmanager_set_default_num_mipmaps(HTextureManager self, _int numMipmaps);

	INV_EXPORT void INV_CALL texmanager_reload_all(HTextureManager self, _bool reloadableOnly);
}

#endif // TEXTUREMANAGER_H

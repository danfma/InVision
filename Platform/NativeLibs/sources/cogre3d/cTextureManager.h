#ifndef TEXTUREMANAGER_H
#define TEXTUREMANAGER_H

#include "cOgre.h"

extern "C"
{
	__export HTextureManager __entry texmanager_get_instance();

	__export _int __entry texmanager_get_default_num_mipmaps(HTextureManager self);
	__export void __entry texmanager_set_default_num_mipmaps(HTextureManager self, _int numMipmaps);

	__export void __entry texmanager_reload_all(HTextureManager self, _bool reloadableOnly);
}

#endif // TEXTUREMANAGER_H

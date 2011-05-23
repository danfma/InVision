#ifndef COGRE_H
#define COGRE_H

#include "cWrapper.h"
#ifdef __cplusplus
#	ifdef MACOSX
#		include <Ogre/Ogre.h>
#		include <Ogre/OgreUTFString.h>
#	else
#		include <Ogre.h>
#		include <OgreUTFString.h>
#	endif
#endif // __cplusplus

#include "invisionnative_ogre.h"


#ifdef __cplusplus

inline Color color_convert_from_ogre(Ogre::ColourValue& c)
{
	return create_color(c.r, c.g, c.b, c.a);
}

inline Ogre::ColourValue color_convert_to_ogre(Color& c)
{
	return Ogre::ColourValue(c.r, c.g, c.b, c.a);
}

#endif // __cplusplus


#endif // COGRE_H

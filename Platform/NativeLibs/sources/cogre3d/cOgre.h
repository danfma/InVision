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

inline Color color_convert_from_ogre(const Ogre::ColourValue& c)
{
	return create_color(c.r, c.g, c.b, c.a);
}

inline Ogre::ColourValue color_convert_to_ogre(Color& c)
{
	return Ogre::ColourValue(c.r, c.g, c.b, c.a);
}

inline Vector3 vector3_convert_from_ogre(Ogre::Vector3& v)
{
	return create_vector3f(v.x, v.y, v.z);
}

inline Vector3 vector3_convert_from_ogre(const Ogre::Vector3& v)
{
	return create_vector3f(v.x, v.y, v.z);
}

inline Ogre::Vector3 vector3_convert_to_ogre(Vector3& v)
{
	return Ogre::Vector3(v.x, v.y, v.z);
}

#endif // __cplusplus


#endif // COGRE_H

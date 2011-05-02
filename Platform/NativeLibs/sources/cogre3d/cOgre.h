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

extern "C"
{
// COLLECTIONS
typedef _any HNameValueCollection;
typedef _any HVectorList;

//
// OGRE
//
typedef _any HRoot;
typedef _any HRenderWindow;
typedef _any HFrameListener;
typedef _any HRenderSystem;
typedef _any HSceneManager;
typedef _any HTextureManager;
typedef _any HMeshManager;
typedef _any HCamera;
typedef _any HSceneNode;
typedef _any HNode;
typedef _any HViewport;
typedef _any HConfigFile;
typedef _any HStringEnumerator;
typedef const _any HNameValuePairEnumerator;
typedef _any HNameValuePairList;
typedef _any HSectionEnumerator;
typedef _any HSettingsEnumerator;
typedef _any HResourceGroupManager;
typedef _any HMaterialManager;

struct  FrameEvent
{
	_float timeSinceLastEvent;
	_float timeSinceLastFrame;
};

struct StringArray
{
	_int count;
	_string* strings;
};

struct NameValuePair
{
	_string key;
	_string value;
};

struct NameHandlePair
{
	const _string key;
	_any value;
};

struct NameValuePairList
{
	_int count;
	NameValuePair* pairs;
};

typedef StringArray* PStringArray;
typedef NameValuePair* PNameValuePair;
typedef NameHandlePair* PNameHandlePair;
typedef NameValuePairList* PNameValuePairList;

typedef _bool (*FrameEventHandler)(const FrameEvent*);

typedef _uint PolygonModeEnum;
extern const PolygonModeEnum PME_Points;
extern const PolygonModeEnum PME_Wireframe;
extern const PolygonModeEnum PME_Solid;


/**
  * Mono.Simd.Vector4f Structure
  */
struct Vector3
{
	_float x;
	_float y;
	_float z;
};

struct Vector4
{
	_float x;
	_float y;
	_float z;
	_float w;
};

typedef Vector4 Quaternion;

struct ColorValue
{
	_float red;
	_float green;
	_float blue;
	_float alpha;
};

struct VersionInfo
{
	_string name;
	_int major;
	_int minor;
	_int build;
	_int revision;
};

typedef _any HLogManager;
typedef _any HOverlayManager;
typedef _any HOverlay;
typedef _any HOverlayElement;


struct FrameStats
{
	_float lastFPS;
	_float avgFPS;
	_float bestFPS;
	_float worstFPS;
	_ulong bestFrameTime;
	_ulong worstFrameTime;
	_int triangleCount;
	_int batchCount;
};

INV_EXPORT void INV_CALL delete_framestats(FrameStats* data);

/*
  * Utilities
  */

INV_EXPORT void INV_CALL util_delete_namevaluepair(PNameValuePair data);
INV_EXPORT void INV_CALL util_delete_namehandlepair(PNameHandlePair data);

}

#ifdef __cplusplus
#	include <string>
#	include <string.h>
#	include <iostream>

/*
  * ColourValue
  */
inline Ogre::ColourValue fromColorValue(const ColorValue& c)
{
	return Ogre::ColourValue(c.red, c.green, c.blue, c.alpha);
}

inline ColorValue toColorValue(const Ogre::ColourValue& c)
{
	ColorValue color;
	color.red = c.r;
	color.green = c.g;
	color.blue = c.b;
	color.alpha = c.a;

	return color;
}

#endif // __cplusplus

#endif // COGRE_H

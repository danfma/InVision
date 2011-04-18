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
typedef _handle HNameValueCollection;
typedef _handle HVectorList;

//
// OGRE
//
typedef _handle HRoot;
typedef _handle HRenderWindow;
typedef _handle HFrameListener;
typedef _handle HRenderSystem;
typedef _handle HSceneManager;
typedef _handle HTextureManager;
typedef _handle HMeshManager;
typedef _handle HCamera;
typedef _handle HSceneNode;
typedef _handle HNode;
typedef _handle HViewport;
typedef _handle HConfigFile;
typedef _handle HStringEnumerator;
typedef const _handle HNameValuePairEnumerator;
typedef _handle HNameValuePairList;
typedef _handle HSectionEnumerator;
typedef _handle HSettingsEnumerator;
typedef _handle HResourceGroupManager;
typedef _handle HMaterialManager;

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
	_handle value;
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

typedef _handle HLogManager;
typedef _handle HOverlayManager;
typedef _handle HOverlay;
typedef _handle HOverlayElement;


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

__export void __entry delete_framestats(FrameStats* data);

/*
  * Utilities
  */

__export void __entry util_delete_namevaluepair(PNameValuePair data);
__export void __entry util_delete_namehandlepair(PNameHandlePair data);

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

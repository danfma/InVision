#ifndef INVISIONPLATFORM_COMMON_H
#define INVISIONPLATFORM_COMMON_H

#if defined(__WIN32__) || defined(WIN32)
#	define __entry __stdcall
#	define __export __declspec(dllexport)
#else
#	define __entry
#	define __export
#endif

#include <stdint.h>

#ifdef __cplusplus
#include <Ogre.h>
#include <OgreUTFString.h>
#endif

extern "C"
{
	typedef void* Any;
	typedef Any Handle;

	// COLLECTIONS
	typedef Handle HNameValueCollection;
	typedef Handle HVectorList;

	//
	// OGRE
	//
	typedef Handle HRoot;
	typedef Handle HRenderWindow;
	typedef Handle HFrameListener;
	typedef Handle HEnumerator;
	typedef Handle HRenderSystem;
	typedef Handle HSceneManager;
	typedef Handle HTextureManager;
	typedef Handle HMeshManager;
	typedef Handle HCamera;
	typedef Handle HSceneNode;
	typedef Handle HNode;
	typedef Handle HViewport;
	typedef Handle HConfigFile;
	typedef Handle HStringEnumerator;
	typedef const Handle HNameValuePairEnumerator;
	typedef Handle HNameValuePairList;
	typedef Handle HSectionEnumerator;
	typedef Handle HSettingsEnumerator;
	typedef Handle HResourceGroupManager;
	typedef Handle HMaterialManager;
	
	//
	// .NET DATA TYPES
	//
	typedef int32_t Bool;
#define TRUE 1
#define FALSE 0
	
	typedef uint16_t Char;
	typedef const char* ConstString;
	typedef char* String;
	
	typedef int8_t Byte;
	typedef uint8_t UByte;
	
	typedef int16_t Int16;
	typedef uint16_t UInt16;
	
	typedef int32_t Int32;
	typedef uint32_t UInt32;
	
	typedef int64_t Int64;	
	typedef uint64_t UInt64;

#ifdef OGRE_UNICODE_SUPPORT
	typedef const Char* ConstDisplayString;
#else
	typedef ConstString ConstDisplayString;
#endif

	struct  FrameEvent
	{
		float timeSinceLastEvent;
		float timeSinceLastFrame;
	};

	struct StringArray
	{
		int count;
		char** strings;
	};

	struct NameValuePair
	{
		const char* key;
		const char* value;
	};

	struct NameHandlePair
	{
		const char* key;
		Handle value;
	};

	struct NameValuePairList
	{
		int count;
		NameValuePair* pairs;
	};

	typedef StringArray* PStringArray;
	typedef NameValuePair* PNameValuePair;
	typedef NameHandlePair* PNameHandlePair;
	typedef NameValuePairList* PNameValuePairList;

	typedef void (*ExceptionHandler)(UInt32 errorCode);
	typedef Bool (*FrameEventHandler)(const FrameEvent*);

	typedef UInt32 PolygonModeEnum;
	extern const PolygonModeEnum PME_Points;
	extern const PolygonModeEnum PME_Wireframe;
	extern const PolygonModeEnum PME_Solid;


	/**
	 * Mono.Simd.Vector4f Structure
	 */
	struct Vector3
	{
		float x;
		float y;
		float z;
	};

	struct Vector4
	{
		float x;
		float y;
		float z;
		float w;
	};

	typedef Vector4 Quaternion;

	struct ColorValue
	{
		float red;
		float green;
		float blue;
		float alpha;
	};

	struct VersionInfo
	{
		ConstString name;
		int major;
		int minor;
		int build;
		int revision;
	};

	/*
	 * Utilities
	 */

	__export void __entry util_delete_string(const char* data);
	__export void __entry util_delete_stringarray(PStringArray strArray);

	__export void __entry util_delete_namevaluepair(PNameValuePair data);
	__export void __entry util_delete_namehandlepair(PNameHandlePair data);


	typedef void (*RaiseExceptionHandler)(ConstString message);

	__export void __entry register_exception_raise_handler(RaiseExceptionHandler handler);
}

#ifdef __cplusplus
#include <string>
#include <string.h>
#include <iostream>

	inline Bool toBool(bool value)
	{
		return value ? TRUE : FALSE;
	}

	inline bool fromBool(Bool value)
	{
		return value == TRUE;
	}

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

	/*
	 * Utilities
	 */
	inline char* copyString(const std::string* str)
	{
		int length = str->size();
		char* data = new char[length + 1];

		memcpy(data, str->c_str(), length);
		data[length] = NULL;

		return data;
	}

	inline char* copyString(std::string& str)
	{
		int length = str.size();
		char* data = new char[length + 1];

		memcpy(data, str.c_str(), length);
		data[length] = NULL;

		return data;
	}

	extern RaiseExceptionHandler exceptionHandler;

	inline void raiseException(ConstString message)
	{
		if (exceptionHandler != NULL)
			exceptionHandler(message);

		std::cerr << "Exception omitted: " << message << std::endl;
	}

#endif

#endif // INVISIONPLATFORM_COMMON_H

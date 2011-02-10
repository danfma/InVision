#ifndef INVISIONPLATFORM_COMMON_H
#define INVISIONPLATFORM_COMMON_H

#if defined(__WIN32__) || defined(WIN32)
#	define __ENTRY __stdcall
#	define __EXPORT __declspec(dllexport)
#else
#	define __ENTRY
#	define __EXPORT
#endif

#include <stdint.h>

extern "C"
{
	typedef void* Any;
	typedef Any Handle;

	typedef Handle HRoot;
	typedef Handle HRenderWindow;
	typedef Handle HFrameListener;
	typedef Handle HEnumerator;
	typedef Handle HRenderSystem;
	typedef Handle HSceneManager;
	typedef Handle HTextureManager;
	typedef Handle HMeshManager;
	typedef Handle HCamera;
	
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

	typedef struct {
		float timeSinceLastEvent;
		float timeSinceLastFrame;
	} FrameEvent;

	typedef void (*ExceptionHandler)(UInt32 errorCode);
	typedef Bool (*FrameEventHandler)(const FrameEvent*);

	typedef struct _NameValuePair
	{
		const char* key;
		const char* value;
	} NameValuePair, * PNameValuePair;

	typedef struct _NameValuePairList
	{
		int count;
		PNameValuePair pairs;
	} NameValuePairList, *PNameValuePairList;

	typedef Any HStringEnumerator;
	typedef Any HNameValuePairEnumerator;
	typedef Any HNameValuePairList;

	typedef UInt32 PolygonModeEnum;
	extern const PolygonModeEnum PME_Points;
	extern const PolygonModeEnum PME_Wireframe;
	extern const PolygonModeEnum PME_Solid;


	typedef struct
	{
		float x;
		float y;
		float z;
	} Vector3f;

	typedef Vector3f* NVector3f;
}

#endif // INVISIONPLATFORM_COMMON_H

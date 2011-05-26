#ifndef __CWRAPPER_H__
#define __CWRAPPER_H__

#if defined(__WIN32__) || defined(WIN32)
#	define INV_CALL __stdcall
#	define INV_EXPORT __declspec(dllexport)
#else
#	define INV_CALL
#	define INV_EXPORT
#endif

#include <stdlib.h>
#include <stdint.h>

#ifdef __cplusplus
#include <string>
#endif // __cplusplus

extern "C"
{
	typedef void* _any;

	// COLLECTIONS
	typedef _any HNameValueCollection;
	typedef _any HVectorList;
	typedef _any HEnumerator;
	
	//
	// .NET DATA TYPES
	//
	typedef int8_t _bool;
#define TRUE (_bool)1
#define FALSE (_bool)0
	
	typedef char _char;
	typedef unsigned char _uchar;
	typedef uint16_t _wchar;
	
	typedef _char* _string;
	typedef _wchar* _wstring;
	
	typedef int8_t _byte;
	typedef uint8_t _ubyte;
	
	typedef int16_t _short;
	typedef uint16_t _ushort;
	
	typedef int32_t _int;
	typedef uint32_t _uint;
	
	typedef int64_t _long;	
	typedef uint64_t _ulong;
	
	typedef float _float;
	typedef double _double;


	struct Vector2
	{
		float x;
		float y;
	};

#ifdef __cplusplus

	inline Vector2 create_vector2f(float x = 0, float y = 0)
	{
		Vector2 v;
		v.x = x;
		v.y = y;

		return v;
	}

#endif

	struct Vector4
	{
		float x;
		float y;
		float z;
		float w;
	};

#ifdef __cplusplus

	inline Vector4 create_vector4f(float x = 0, float y = 0, float z = 0, float w = 0)
	{
		Vector4 v;
		v.x = x;
		v.y = y;
		v.z = z;
		v.w = w;

		return v;
	}

#endif

	typedef Vector4 Vector3;

#ifdef __cplusplus

	inline Vector3 create_vector3f(float x = 0, float y = 0, float z = 0)
	{
		Vector3 v;
		v.x = x;
		v.y = y;
		v.z = z;

		return v;
	}

#endif

	struct Color
	{
		float r;
		float g;
		float b;
		float a;
	};

#ifdef __cplusplus

	inline Color create_color(float r = 1.0, float g = 1.0, float b = 1.0, float a = 1.0)
	{
		Color c;
		c.r = r;
		c.g = g;
		c.b = b;
		c.a = a;

		return c;
	}

#endif

	
	/*
	 * Utilities
	 */

	INV_EXPORT void
	INV_CALL util_string_delete(const _string data);

	/*
	 * Exception handler
	 */
#define ERROR					0
#define NULL_REFERENCE_ERROR	1
#define INVALID_CAST_ERROR		2
#define KEY_NOT_FOUND_ERROR		3
#define NOT_IMPLEMENTED			4
#define NOT_SINGLETON_ERROR		5


	typedef void (INV_CALL *ExceptionHandler)(const _string message, _int errorType);

	INV_EXPORT void
	INV_CALL register_exception_handler(ExceptionHandler handler);

#ifdef __cplusplus

	INV_EXPORT void
	INV_CALL raise_exception(std::string message, _int errorType = ERROR);

#endif
}

#ifdef __cplusplus
#include <string>
#include <string.h>
#include <iostream>

	inline void throws_not_implemented()
	{
		raise_exception("Not implemented", NOT_IMPLEMENTED);
	}

	inline void throws_null_reference(const char* file, int line)
	{
		std::string message = "Null pointer on ";
		message += file;
		message += " at line ";
		message += line;

		raise_exception(message, NULL_REFERENCE_ERROR);
	}

	inline void throws_key_not_found(std::string key)
	{
		std::string message = "Key not found: " + key;

		raise_exception(message, KEY_NOT_FOUND_ERROR);
	}

	inline void throws_invalid_cast(_ushort fromType, _ushort targetType)
	{
		std::string message = "Invalid cast from ";
		message += "" + fromType;
		message += " to ";
		message += "" + targetType;

		raise_exception(message, INVALID_CAST_ERROR);
	}

	inline _bool toBool(bool value)
	{
		return value ? TRUE : FALSE;
	}

	inline bool fromBool(_bool value)
	{
		return value == TRUE;
	}

	/*
	 * Utilities
	 */
	inline _string copyString(const std::string* str)
	{
		_int length = str->size();
		_char* data = new _char[length + 1];

		memcpy(data, str->c_str(), length);
		data[length] = '\0';

		return data;
	}

	inline _string copyString(std::string& str)
	{
		_int length = str.size();
		_char* data = new _char[length + 1];

		memcpy(data, str.c_str(), length);
		data[length] = '\0';

		return data;
	}

	inline _string copyString(const std::string& str)
	{
		_int length = str.size();
		_char* data = new _char[length + 1];

		memcpy(data, str.c_str(), length);
		data[length] = '\0';

		return data;
	}

#endif // __cplusplus

#endif // __CWRAPPER_H__

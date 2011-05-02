#ifndef INVISIONPLATFORM_CWRAPPER_H
#define INVISIONPLATFORM_CWRAPPER_H

#if defined(__WIN32__) || defined(WIN32)
#	define INV_CALL __stdcall
#	define INV_EXPORT __declspec(dllexport)
#else
#	define INV_CALL
#	define INV_EXPORT
#endif

#include <stdlib.h>
#include <stdint.h>

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
	typedef int32_t _bool;
#define TRUE 1
#define FALSE 0
	
	typedef char _char;
	typedef unsigned char _uchar;
	typedef uint16_t _wchar;
	
	typedef _char* _string;
	
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


	
	/*
	 * Utilities
	 */

	INV_EXPORT void
	INV_CALL util_string_delete(const _string data);

	/*
	 * Exception handler
	 */
	typedef void (INV_CALL *ExceptionHandler)(const _string message, const _string filename, _int line);

	INV_EXPORT void
	INV_CALL _register_exception_handler(ExceptionHandler handler);

	INV_EXPORT void
	INV_CALL _raise_exception(const _string message, const _string filename, _int line);
}

#ifdef __cplusplus
#include <string>
#include <string.h>
#include <iostream>

	inline _bool toBool(bool value)
	{
		return value ? TRUE : FALSE;
	}

	inline bool fromBool(_bool value)
	{
		return value == TRUE;
	}

	template<typename T>
	inline T* __new(size_t quantity = 1)
	{
		return (T*)malloc(sizeof(T) * quantity);
	}

	/*
	 * Utilities
	 */
	inline _string copyString(const std::string* str)
	{
		_int length = str->size();
		_char* data = __new<_char>(length + 1);

		memcpy(data, str->c_str(), length);
		data[length] = NULL;

		return data;
	}

	inline _string copyString(std::string& str)
	{
		_int length = str.size();
		_char* data = __new<_char>(length + 1);

		memcpy(data, str.c_str(), length);
		data[length] = NULL;

		return data;
	}

	inline _string copyString(const std::string& str)
	{
		_int length = str.size();
		_char* data = __new<_char>(length + 1);

		memcpy(data, str.c_str(), length);
		data[length] = NULL;

		return data;
	}

#endif

#endif

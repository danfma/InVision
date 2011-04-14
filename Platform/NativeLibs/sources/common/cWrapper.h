#ifndef INVISIONPLATFORM_COMMON_H
#define INVISIONPLATFORM_COMMON_H

#if defined(__WIN32__) || defined(WIN32)
#	define __entry __stdcall
#	define __export __declspec(dllexport)
#else
#	define __entry
#	define __export
#endif

#include <stdlib.h>
#include <stdint.h>

extern "C"
{
	typedef void* _any;
	typedef _any _handle;

	// COLLECTIONS
	typedef _handle HNameValueCollection;
	typedef _handle HVectorList;
	
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

	__export void __entry util_delete_string(const _byte* data);
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

	/*
	 * Utilities
	 */
	inline _char* copyString(const std::string* str)
	{
		int length = str->size();
		_char* data = new _char[length + 1];

		memcpy(data, str->c_str(), length);
		data[length] = NULL;

		return data;
	}

	inline _char* copyString(std::string& str)
	{
		int length = str.size();
		_char* data = new _char[length + 1];

		memcpy(data, str.c_str(), length);
		data[length] = NULL;

		return data;
	}

#endif

#endif

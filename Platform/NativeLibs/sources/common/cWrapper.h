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
#define TRUE 1
#define FALSE 0
	
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
		message += fromType;
		message += " to ";
		message += targetType;

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

#endif

#endif

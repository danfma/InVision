#include "cWrapper.h"
#include <iostream>

using namespace std;

INV_EXPORT void INV_CALL util_string_delete(const _string data)
{
	if (data == NULL)
		return;

	delete[] data;
}


/*
 * Exception handler
 */
ExceptionHandler exceptionHandler = NULL;

INV_EXPORT void INV_CALL _register_exception_handler(ExceptionHandler handler)
{
	exceptionHandler = handler;
}

INV_EXPORT void INV_CALL _raise_exception(const _string message, const _string filename, _int line)
{
	if (exceptionHandler == NULL)
		cerr << "Exception (file: " << filename << " line: " << line << "): " << message << endl;
	else
		exceptionHandler(message, filename, line);
}

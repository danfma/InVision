#include "cWrapper.h"
#include <iostream>

using namespace std;

__export void __entry util_string_delete(const _string data)
{
	if (data == NULL)
		return;

	delete[] data;
}


/*
 * Exception handler
 */
ExceptionHandler exceptionHandler = NULL;

__export void __entry _register_exception_handler(ExceptionHandler handler)
{
	exceptionHandler = handler;
}

__export void __entry _raise_exception(const _string message, const _string filename, _int line)
{
	if (exceptionHandler == NULL)
		cerr << "Exception (file: " << filename << " line: " << line << "): " << message << endl;
	else
		exceptionHandler(message, filename, line);
}

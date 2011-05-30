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
InvExceptionHandler exceptionHandler = NULL;

INV_EXPORT void INV_CALL register_exception_handler(InvExceptionHandler handler)
{
	exceptionHandler = handler;
}

INV_EXPORT void INV_CALL raise_exception(std::string message, _int errorType)
{
	if (exceptionHandler == NULL)
		cerr << "error: " << errorType << ": " <<  message << endl;
	else
		exceptionHandler(const_cast<_string>(message.c_str()), errorType);

	throw exception();
}

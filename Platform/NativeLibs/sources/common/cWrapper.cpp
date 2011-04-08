#include "cWrapper.h"

RaiseExceptionHandler exceptionHandler = NULL;

__export void __entry util_delete_string(const _byte* data)
{
	if (data == NULL)
		return;

	delete[] data;
}

__export void __entry register_exception_raise_handler(RaiseExceptionHandler handler)
{
	exceptionHandler = handler;
}


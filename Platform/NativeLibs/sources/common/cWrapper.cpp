#include "cWrapper.h"

__export void __entry util_delete_string(const _byte* data)
{
	if (data == NULL)
		return;

	delete[] data;
}


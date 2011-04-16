#ifndef EVENTARGS_H
#define EVENTARGS_H

#include "cOIS.h"

extern "C"
{
	struct EventArgExtended
	{
		HEventArg handle;
		HObject* device;
	};

	__export EventArgExtended __entry ois_eventarg_new_from(HEventArg self);
}

#endif // EVENTARGS_H

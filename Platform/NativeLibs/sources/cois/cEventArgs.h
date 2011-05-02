#ifndef EVENTARGS_H
#define EVENTARGS_H

#include "cOIS.h"

extern "C"
{
	struct EventArgDescriptor
	{
		Handle handle;
		OIS::Object** device;
	};

	INV_EXPORT EventArgDescriptor
	INV_CALL ois_descriptor_of_eventarg(Handle handle, OIS::EventArg* e);
}

#endif // EVENTARGS_H

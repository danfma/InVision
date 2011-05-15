#include "cOIS.h"

using namespace invision;


EventArgDescriptor
descriptor_of_eventarg(InvHandle handle)
{
	EventArgDescriptor ex;
	ex.self = handle;

	return ex;
}

INV_EXPORT EventArgDescriptor
INV_CALL new_eventarg_by_devicehandle(InvHandle deviceHandle)
{
	OIS::Object* obj = castHandle<OIS::Object>(deviceHandle);
	InvHandle handle = newHandleOf<OIS::EventArg, OIS::Object*>(obj);
	
	return descriptor_of_eventarg(handle);
}

INV_EXPORT void
INV_CALL delete_eventarg(InvHandle self)
{
	destroyHandle(self);
}

INV_EXPORT InvHandle
INV_CALL eventarg_get_device(InvHandle self)
{
	OIS::EventArg* e = castHandle<OIS::EventArg>(self);
		
	return getOrAddHandleByObject<OIS::Object>(e->device);
}

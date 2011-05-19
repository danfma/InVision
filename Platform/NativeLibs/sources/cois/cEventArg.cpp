#include "cOIS.h"

EventArgDescriptor descriptor_of_eventarg(InvHandle handle)
{
	EventArgDescriptor descriptor;
	descriptor.self = handle;

	return descriptor;
}

/**
 * Method: EventArg::EventArg
 */
INV_EXPORT InvHandle
INV_CALL new_eventarg(InvHandle device)
{
	OIS::Object* obj = castHandle<OIS::Object>(device);

	OIS::EventArg* eventArg = new EventArg(obj);

	return createHandle<OIS::EventArg>(eventArg);
}

/**
 * Method: EventArg::~EventArg
 */
INV_EXPORT void
INV_CALL delete_eventarg(InvHandle self)
{
	destroyHandle(self);
}

/**
 * Method: EventArg::getDevice
 */
INV_EXPORT InvHandle
INV_CALL eventarg_get_device(InvHandle self)
{
	OIS::Object* device = const_cast<OIS::Object*>(asEventArg(self)->device);

	return createReference<OIS::Object>(device);
}

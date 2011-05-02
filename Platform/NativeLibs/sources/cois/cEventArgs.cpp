#include "cEventArgs.h"

INV_EXPORT EventArgDescriptor
INV_CALL ois_descriptor_of_eventarg(Handle handle, OIS::EventArg* e)
{
	EventArgDescriptor ex;
	ex.handle = handle;
	ex.device = const_cast<OIS::Object**>(&e->device);

	return ex;
}

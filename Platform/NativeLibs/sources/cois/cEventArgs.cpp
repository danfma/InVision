#include "cEventArgs.h"

__export EventArgExtended __entry ois_eventarg_new_from(HEventArg self)
{
	OIS::EventArg* e = (OIS::EventArg*)self;

	EventArgExtended ex;
	ex.handle = e;
	ex.device = (HObject*) &e->device;

	return ex;
}

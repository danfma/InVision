#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"

extern "C"
{
	struct OISComponentHandleInfo {
		OISComponentHandle handle;
		_int* componentType;
	};

	/*
	 * OIS::Component
	 */
	__export OISComponentHandleInfo __entry ois_component_new(_int ctype);
	__export void __entry ois_component_delete(OISComponentHandle self);
}

#endif // CCOMPONENT_H

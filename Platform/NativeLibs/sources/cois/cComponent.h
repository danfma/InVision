#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"

extern "C"
{
	struct ComponentExtended {
		HComponent handle;
		_int* componentType;
	};

	/*
	 * OIS::Component
	 */
	__export ComponentExtended __entry ois_component_new(_int ctype);
	__export void __entry ois_component_delete(HComponent self);
}

#endif // CCOMPONENT_H

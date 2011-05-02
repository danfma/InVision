#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"

/* OIS::Component */

extern "C"
{
	struct ComponentDescriptor
	{
		// reference
		_any handle;

		// field
		OIS::ComponentType* ctype;
	};

	ComponentDescriptor
	ois_descriptor_of_component(_any self, OIS::Component* component);

	/*
	 * OIS::Component
	 */
	INV_EXPORT ComponentDescriptor
	INV_CALL ois_new_component(OIS::ComponentType ctype);

	INV_EXPORT void
	INV_CALL ois_delete_component(OIS::Component* self);
}

#endif // CCOMPONENT_H

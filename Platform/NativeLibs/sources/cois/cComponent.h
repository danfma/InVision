#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"
#include "InvisionHandle.h"

/* OIS::Component */

extern "C"
{
	typedef _int COMPONENT_TYPE;

	struct ComponentDescriptor
	{
		// reference
		InvHandle handle;

		// field
		COMPONENT_TYPE* ctype;
	};

	INV_EXPORT ComponentDescriptor
	INV_CALL descriptor_of_component(InvHandle handle);

	/*
	 * OIS::Component
	 */
	INV_EXPORT ComponentDescriptor
	INV_CALL new_component();

	INV_EXPORT ComponentDescriptor
	INV_CALL new_component_by_ctype(COMPONENT_TYPE ctype);

	INV_EXPORT void
	INV_CALL delete_component(InvHandle handle);
}

#endif // CCOMPONENT_H

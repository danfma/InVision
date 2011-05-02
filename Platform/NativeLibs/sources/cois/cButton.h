#ifndef BUTTON_H
#define BUTTON_H

#include "cOIS.h"
#include "cComponent.h"

extern "C"
{
	struct ButtonDescriptor
	{
		ComponentDescriptor base;
		bool* pushed;
	};

	ButtonDescriptor
	ois_descriptor_of_button(_any handle, OIS::Button* button);

	/*
	 * OIS::Button
	 */
	INV_EXPORT ButtonDescriptor
	INV_CALL ois_new_button(bool pushed);

	INV_EXPORT void
	INV_CALL ois_delete_button(OIS::Button* self);
}

#endif // BUTTON_H

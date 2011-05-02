#include "cButton.h"

ButtonDescriptor ois_descriptor_of_button(_any handle, OIS::Button* button)
{
	ButtonDescriptor descriptor;
	descriptor.base = ois_descriptor_of_component(handle, button);
	descriptor.pushed = &button->pushed;

	return descriptor;
}

INV_EXPORT ButtonDescriptor INV_CALL ois_new_button(bool pushed)
{
	OIS::Button* button = new OIS::Button(fromBool(pushed));

	return ois_descriptor_of_button(button, button);
}

INV_EXPORT void INV_CALL ois_delete_button(OIS::Button* self)
{
	if (self == NULL)
		return;

	delete self;
}

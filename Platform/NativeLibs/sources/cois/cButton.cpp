#include "cOIS.h"

using namespace invision;


ButtonDescriptor 
descriptor_of_button(InvHandle handle)
{
	OIS::Button* button = castHandle<OIS::Button>(handle);
	
	ButtonDescriptor descriptor;
	descriptor.base = descriptor_of_component(handle);
	descriptor.pushed = (_bool*)&button->pushed;

	return descriptor;
}

/**
 * Method: Button::Button
 */
INV_EXPORT InvHandle
INV_CALL new_button_m1(ButtonDescriptor* descriptor)
{
	OIS::Button* obj = new OIS::Button();
	InvHandle self = createHandle< OIS::Button >(obj);
	*descriptor = descriptor_of_button(self);

	return self;
}

/**
 * Method: Button::Button
 */
INV_EXPORT InvHandle
INV_CALL new_button_m2(ButtonDescriptor* descriptor, _bool pushed)
{
	OIS::Button* obj = new OIS::Button(pushed);
	InvHandle self = createHandle< OIS::Button >(obj);
	*descriptor = descriptor_of_button(self);

	return self;
}


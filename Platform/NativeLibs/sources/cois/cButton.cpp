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
INV_EXPORT ButtonDescriptor
INV_CALL new_button()
{
	InvHandle handle = newHandleOf<OIS::Button>();
	
	return descriptor_of_button(handle);
}

/**
 * Method: Button::Button
 */
INV_EXPORT ButtonDescriptor
INV_CALL new_button_by_pushed(_bool pushed)
{
	InvHandle handle = newHandleOf<OIS::Button, bool>(fromBool(pushed));
	
	return descriptor_of_button(handle);
}


#include "cOIS.h"

MouseStateDescriptor descriptor_of_mousestate(InvHandle self)
{
	MouseState* obj = castHandle<MouseState>(self);

	MouseStateDescriptor descriptor;
	descriptor.self = self;
	descriptor.buttons = &obj->buttons;
	descriptor.width = &obj->width;
	descriptor.height = &obj->height;
	descriptor.x = descriptor_of_axis(createReference<Axis>(&obj->X));
	descriptor.y = descriptor_of_axis(createReference<Axis>(&obj->Y));
	descriptor.z = descriptor_of_axis(createReference<Axis>(&obj->Z));

	return descriptor;
}

/**
 * Method: MouseState::MouseState
 */
INV_EXPORT InvHandle
INV_CALL new_mousestate_by_descriptor(MouseStateDescriptor* descriptor)
{
	MouseState* obj = new MouseState();

	InvHandle handle = createHandle<MouseState>(obj);
	*descriptor = descriptor_of_mousestate(handle);

	return handle;
}

/**
 * Method: MouseState::~MouseState
 */
INV_EXPORT void
INV_CALL delete_mousestate(InvHandle self)
{
	destroyHandle(self);
}

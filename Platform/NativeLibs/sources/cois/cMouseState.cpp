#include "cOIS.h"

MouseStateDescriptor descriptor_of_mousestate(InvHandle self)
{
	OIS::MouseState* obj = castHandle<OIS::MouseState>(self);

	MouseStateDescriptor descriptor;
	descriptor.self = self;
	descriptor.buttons = &obj->buttons;
	descriptor.width = &obj->width;
	descriptor.height = &obj->height;
	descriptor.x = descriptor_of_axis(createReference<OIS::Axis>(&obj->X));
	descriptor.y = descriptor_of_axis(createReference<OIS::Axis>(&obj->Y));
	descriptor.z = descriptor_of_axis(createReference<OIS::Axis>(&obj->Z));

	return descriptor;
}

/**
 * Method: MouseState::MouseState
 */
INV_EXPORT InvHandle
INV_CALL new_mousestate(MouseStateDescriptor* descriptor)
{
	OIS::MouseState* obj = new OIS::MouseState();

	InvHandle handle = createHandle<OIS::MouseState>(obj);
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

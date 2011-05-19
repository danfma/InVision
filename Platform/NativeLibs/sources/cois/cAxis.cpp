#include "cOIS.h"

using namespace invision;

AxisDescriptor
descriptor_of_axis(InvHandle handle)
{
	OIS::Axis* axis = castHandle<OIS::Axis>(handle);

	AxisDescriptor descriptor;
	descriptor.base = descriptor_of_component(handle);
	descriptor.abs = (_int*)&axis->abs;
	descriptor.rel = (_int*)&axis->rel;
	descriptor.absOnly = (_bool*)&axis->absOnly;

	return descriptor;
}

/**
 * Method: Axis::Axis
 */
INV_EXPORT InvHandle
INV_CALL new_axis(AxisDescriptor* descriptor)
{
	OIS::Axis* axis = new OIS::Axis();

	InvHandle self = createHandle<OIS::Axis>(axis);
	*descriptor = descriptor_of_axis(self);

	return self;
}

#include "cAxis.h"

AxisDescriptor
ois_descriptor_of_axis(_any handle, OIS::Axis* axis)
{
	AxisDescriptor descriptor;
	descriptor.base = ois_descriptor_of_component(handle, axis);
	descriptor.abs = &axis->abs;
	descriptor.rel = &axis->rel;
	descriptor.absOnly = &axis->absOnly;

	return descriptor;
}

INV_EXPORT AxisDescriptor
INV_CALL ois_new_axis()
{
	OIS::Axis* axis = new OIS::Axis();

	return ois_descriptor_of_axis(axis, axis);
}

INV_EXPORT void
INV_CALL ois_delete_axis(OIS::Axis* self)
{
	if (self == NULL)
		return;

	delete self;
}

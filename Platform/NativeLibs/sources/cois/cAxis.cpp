#include "cOIS.h"

using namespace invision;

AxisDescriptor
descriptor_of_axis(InvHandle handle)
{
	OIS::Axis* axis = castHandle<OIS::Axis>(handle);

	AxisDescriptor descriptor;
	descriptor.base = descriptor_of_component(handle);
	descriptor.absolute = (_int*)&axis->abs;
	descriptor.relative = (_int*)&axis->rel;
	descriptor.absoluteOnly = (_bool*)&axis->absOnly;

	return descriptor;
}

INV_EXPORT AxisDescriptor
INV_CALL new_axis()
{
	InvHandle handle = newHandleOf<OIS::Axis>();

	return descriptor_of_axis(handle);
}


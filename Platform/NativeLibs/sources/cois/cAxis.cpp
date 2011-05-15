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

INV_EXPORT AxisDescriptor
INV_CALL new_axis()
{
	InvHandle handle = newHandleOf<OIS::Axis>();

	return descriptor_of_axis(handle);
}


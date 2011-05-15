#include "cOIS.h"

using namespace invision;


ComponentDescriptor
descriptor_of_component(InvHandle handle)
{
	OIS::Component* cp = castHandle<OIS::Component>(handle);

	ComponentDescriptor descriptor;
	descriptor.handle = handle;
	descriptor.ctype = (_int*)&cp->cType;

	return descriptor;
}


INV_EXPORT ComponentDescriptor
INV_CALL new_component()
{
	InvHandle handle = newHandleOf<OIS::Component>();

	return descriptor_of_component(handle);
}


INV_EXPORT ComponentDescriptor
INV_CALL new_component_by_ctype(_int ctype)
{
	InvHandle handle = newHandleOf<OIS::Component, OIS::ComponentType>((OIS::ComponentType)ctype);

	return descriptor_of_component(handle);
}


INV_EXPORT void
INV_CALL delete_component(InvHandle handle)
{
	destroyHandle(handle);
}

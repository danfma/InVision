#include "cComponent.h"

using namespace invision;
using namespace invision::ois;

INV_EXPORT ComponentDescriptor
INV_CALL ois_descriptor_of_component(InvHandle handle)
{
	OIS::Component* cp = castHandle<OIS::Component>(handle);

	ComponentDescriptor descriptor;
	descriptor.handle = handle;
	descriptor.ctype = (COMPONENT_TYPE*)&cp->cType;

	return descriptor;
}


INV_EXPORT ComponentDescriptor
INV_CALL new_component()
{
	InvHandle handle = newHandleOf<OIS::Component>();

	return ois_descriptor_of_component(handle);
}


INV_EXPORT ComponentDescriptor
INV_CALL new_component_by_ctype(COMPONENT_TYPE ctype)
{
	InvHandle handle = newHandleOf<OIS::Component, OIS::ComponentType>(ctype);

	return ois_descriptor_of_component(handle);
}


INV_EXPORT void
INV_CALL delete_component(InvHandle handle)
{
	destroyHandle(handle);
}

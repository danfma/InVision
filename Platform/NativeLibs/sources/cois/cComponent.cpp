#include "cOIS.h"

using namespace invision;


ComponentDescriptor
descriptor_of_component(InvHandle handle)
{
	OIS::Component* cp = castHandle<OIS::Component>(handle);

	ComponentDescriptor descriptor;
	descriptor.ctype = (_int*)&cp->cType;

	return descriptor;
}


INV_EXPORT InvHandle
INV_CALL new_component_m1(ComponentDescriptor* descriptor)
{
	OIS::Component* obj = new OIS::Component();
	InvHandle self = createHandle< OIS::Component >(obj);
	*descriptor = descriptor_of_component(self);

	return self;
}

/**
 * Method: Component::Component
 */
INV_EXPORT InvHandle
INV_CALL new_component_m2(ComponentDescriptor* descriptor, COMPONENT_TYPE ctype)
{
	OIS::Component* obj = new OIS::Component((OIS::ComponentType)ctype);
	InvHandle self = createHandle< OIS::Component >(obj);
	*descriptor = descriptor_of_component(self);

	return self;
}

/**
 * Method: Component::~Component
 */
INV_EXPORT void
INV_CALL delete_component(InvHandle self)
{
	destroyHandle(self);
}

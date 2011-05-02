#include "cComponent.h"

using namespace invision::ois;


ComponentDescriptor
ois_descriptor_of_component(_any self, OIS::Component* component)
{
	ComponentDescriptor info;
	info.handle = self;
	info.ctype = &component->cType;

	return info;
}


/*
* OIS::Component
*/
INV_EXPORT ComponentDescriptor
INV_CALL ois_new_component(OIS::ComponentType ctype)
{
	OIS::Component* handle = new OIS::Component(ctype);

	return ois_descriptor_of_component(handle, handle);
}

INV_EXPORT void
INV_CALL ois_delete_component(OIS::Component* self)
{
	if (self == NULL)
		return;

	delete self;
}

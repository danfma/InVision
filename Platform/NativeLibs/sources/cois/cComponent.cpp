#include "cComponent.h"

using namespace invision::ois;

/*
* OIS::Component
*/
__export ComponentExtended __entry ois_component_new(_int ctype)
{
	OIS::Component* component = new OIS::Component((OIS::ComponentType)ctype);
	ComponentExtended cinfo;
	cinfo.handle = component;
	cinfo.componentType = (_int*) &(component->cType);

	return cinfo;
}

__export void __entry ois_component_delete(HComponent self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Component*)self;
}


__export ComponentWrapper* __entry ois_create_component_wrapper(OIS::ComponentType ctype)
{
	return new ComponentWrapper(ctype);
}

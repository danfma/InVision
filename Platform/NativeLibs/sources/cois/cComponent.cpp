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


__export ComponentProxyInfo __entry ois_new_component(OIS::ComponentType ctype)
{
	return ComponentProxy::createInfo(new ComponentProxy(ctype));
}

__export void __entry ois_delete_component(OIS::Component* self)
{
	if (self == NULL)
		return;

	delete self;
}

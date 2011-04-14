#include "cComponent.h"

using namespace invision::ois;

/*
* OIS::Component
*/
__export OISComponentHandleInfo __entry ois_component_new(_int ctype)
{
	OIS::Component* component = new OIS::Component((OIS::ComponentType)ctype);
	OISComponentHandleInfo cinfo;
	cinfo.handle = component;
	cinfo.componentType = (_int*) &(component->cType);

	return cinfo;
}

__export void __entry ois_component_delete(OISComponentHandle self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Component*)self;
}


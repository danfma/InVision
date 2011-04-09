#include "cComponent.h"

using namespace invision;

/*
* OIS::Component
*/
__export OISComponent* __entry newOISComponent()
{
	OIS::Component* component = new OIS::Component();
	
	OISComponent* self = new OISComponent();
	self->handle = component;
	refreshOISComponent(self);
	
	return self;
}

__export void __entry deleteOISComponent(OISComponent* self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Component*)(self->handle);
	delete self;
}

__export void __entry refreshOISComponent(OISComponent* self)
{
	if (!ensureNotNull(self) || !ensureNotNull(self->handle))
		return;
	
	const OIS::Component* aux = (OIS::Component*)self->handle;
	self->cType = aux->cType;
}

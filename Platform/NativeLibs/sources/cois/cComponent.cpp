#include "cComponent.h"

using namespace invision::ois;

/*
* OIS::Component
*/
__export OISComponent* __entry oisNewComponent()
{
	OIS::Component* component = new OIS::Component();
	
	OISComponent* self = new OISComponent();
	self->handle = component;
	oisRefreshComponent(self);
	
	return self;
}

__export void __entry oisDeleteComponent(OISComponent* self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Component*)(self->handle);
	delete self;
}

__export void __entry oisRefreshComponent(OISComponent* self)
{
	if (!ensureNotNull(self) || !ensureNotNull(self->handle))
		return;
	
	const OIS::Component* aux = (OIS::Component*)self->handle;
	self->cType = aux->cType;
}

#include "cVector3.h"

using namespace invision;

__export OISVector3* __entry newOISVector()
{
	OIS::Vector3* vector = new OIS::Vector3();
	
	OISVector3* self = new OISVector3();
	self->base.handle = vector;
	refreshOISVector(self);
	
	return self;
}

__export void __entry deleteOISVector(OISVector3* self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Vector3*)self->base.handle;
	delete self;
}

__export void __entry refreshOISAxis(OISVector3* self)
{
	if (!ensureNotNull(self) || !ensureNotNull(self->base.handle))
		return;
	
	OIS::Vector3* vector = (OIS::Vector3*)self->base.handle;
	
	self->x = vector->x;
	self->y = vector->y;
	self->z = vector->z;
	refreshOISComponent(&self->base);
}


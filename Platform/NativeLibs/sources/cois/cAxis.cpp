#include "cAxis.h"
#include "cComponent.h"

using namespace invision;

__export OISAxis* __entry newOISAxis()
{
	OIS::Axis* axis = new OIS::Axis();
	
	OISAxis* self = new OISAxis();
	self->base.handle = axis;
	refreshOISAxis(self);
	
	return self;
}

__export void __entry deleteOISAxis(OISAxis* self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Axis*)self->base.handle;
	delete self;
}

__export void __entry refreshOISAxis(OISAxis* self)
{
	if (!ensureNotNull(self) || !ensureNotNull(self->base.handle))
		return;
	
	OIS::Axis* axis = (OIS::Axis*)self->base.handle;
	self->abs = axis->abs;
	self->rel = axis->rel;
	self->absOnly = fromBool(axis->absOnly);
	refreshOISComponent(&self->base);
}

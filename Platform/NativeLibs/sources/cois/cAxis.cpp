#include "cAxis.h"
#include "cComponent.h"

using namespace invision::ois;

__export OISAxis* __entry oisNewAxis()
{
	OIS::Axis* axis = new OIS::Axis();
	
	OISAxis* self = new OISAxis();
	self->base.handle = axis;
	oisRefreshAxis(self);
	
	return self;
}

__export void __entry oisDeleteAxis(OISAxis* self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Axis*)self->base.handle;
	delete self;
}

__export void __entry oisRefreshAxis(OISAxis* self)
{
	if (!ensureNotNull(self) || !ensureNotNull(self->base.handle))
		return;
	
	OIS::Axis* axis = (OIS::Axis*)self->base.handle;
	self->abs = axis->abs;
	self->rel = axis->rel;
	self->absOnly = fromBool(axis->absOnly);
	oisRefreshComponent(&self->base);
}

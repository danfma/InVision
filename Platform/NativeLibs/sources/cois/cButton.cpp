#include "cButton.h"

using namespace invision::ois;


/*
 * OIS::Button
 */
__export OISButton* __entry oisNewButton()
{
	OIS::Button* button = new OIS::Button();
	
	OISButton* self = new OISButton();
	self->base.handle = button;
	self->pushed = fromBool(button->pushed);
	self->base.cType = button->cType;
	
	return self;
}

__export void __entry oisDeleteButton(OISButton* self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Button*)self->base.handle;
	delete self;
}

__export void __entry oisRefreshButton(OISButton* self)
{
	if (!ensureNotNull(self) || !ensureNotNull(self->base.handle))
		return;
	
	OIS::Button* aux = (OIS::Button*)self->base.handle;
	self->pushed = fromBool(aux->pushed);
	oisRefreshComponent(&self->base);
}

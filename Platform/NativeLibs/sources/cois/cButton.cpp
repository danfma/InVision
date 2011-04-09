#include "cButton.h"
#include "cComponent.h"

using namespace invision;


/*
 * OIS::Button
 */
__export OISButton* __entry newOISButton()
{
	OIS::Button* button = new OIS::Button();
	
	OISButton* self = new OISButton();
	self->base.handle = button;
	self->pushed = fromBool(button->pushed);
	self->base.cType = button->cType;
	
	return self;
}

__export void __entry deleteOISButton(OISButton* self)
{
	if (self == NULL)
		return;
	
	delete (OIS::Button*)self->base.handle;
	delete self;
}

__export void __entry refreshOISButton(OISButton* self)
{
	if (!ensureNotNull(self) || !ensureNotNull(self->base.handle))
		return;
	
	OIS::Button* aux = (OIS::Button*)self->base.handle;
	self->pushed = fromBool(aux->pushed);
	refreshOISComponent(&self->base);
}

#include "cOgre.h"

INV_EXPORT _wstring
INV_CALL overlayelement_get_caption(InvHandle self)
{
	Ogre::DisplayString text = asOverlayElement(self)->getCaption();

	return copyString(text.asWStr());
}

INV_EXPORT void
INV_CALL overlayelement_set_caption(InvHandle self, _wstring value)
{
	Ogre::DisplayString text = value;

	asOverlayElement(self)->setCaption(text);
}

INV_EXPORT void
INV_CALL overlayelement_show(InvHandle self)
{
	asOverlayElement(self)->show();
}

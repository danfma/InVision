#include "cOgre.h"

INV_EXPORT _string
INV_CALL overlayelement_get_caption(InvHandle self)
{
	_string text = const_cast<_string>(asOverlayElement(self)->getCaption().asUTF8_c_str());

	int length = strlen(text);
	_string textCopy = new _char[length];

	for (int i = 0; i < length; i++) {
		textCopy[i] = text[i];
	}

	return textCopy;
}

INV_EXPORT void
INV_CALL overlayelement_set_caption(InvHandle self, _string value)
{
	Ogre::DisplayString text = value;

	asOverlayElement(self)->setCaption(text);
}

INV_EXPORT void
INV_CALL overlayelement_show(InvHandle self)
{
	asOverlayElement(self)->show();
}

#include "cOgre.h"

INV_EXPORT _wstring
INV_CALL overlayelement_get_caption(InvHandle self)
{
	std::wstring text = asOverlayElement(self)->getCaption().asWStr();

	return copyString(text);
}

INV_EXPORT void
INV_CALL overlayelement_set_caption(InvHandle self, _wstring value)
{
	const std::wstring wtext = (wchar_t*)value;
	Ogre::DisplayString text = wtext;

	asOverlayElement(self)->setCaption(text);
}

INV_EXPORT void
INV_CALL overlayelement_show(InvHandle self)
{
	asOverlayElement(self)->show();
}

INV_EXPORT void
INV_CALL overlayelement_delete_wide_string(_wchar* pdata)
{
	if (pdata != NULL)
		delete[] pdata;
}

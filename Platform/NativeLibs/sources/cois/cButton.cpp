#include "cButton.h"

__export ButtonExtended __entry ois_button_new(_bool pushed)
{
	OIS::Button* button = new OIS::Button(fromBool(pushed));

	ButtonExtended btinfo;
	btinfo.base.handle = button;
	btinfo.base.componentType = (_int*) &button->cType;
	btinfo.pushed = (_bool*) &button->pushed;

	return btinfo;
}

__export void __entry ois_button_delete(HButton self)
{
	if (self == NULL)
		return;

	delete (OIS::Button*)self;
}

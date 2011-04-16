#include "cKeyEvent.h"

__export KeyEventExtended __entry ois_keyevent_new_from(HKeyEvent self)
{
	OIS::KeyEvent* e = asKeyEvent(self);

	KeyEventExtended x;
	x.base = ois_eventarg_new_from(e);
	x.key = (_int*) &e->key;
	x.text = (_uint*) &e->text;

	return x;
}

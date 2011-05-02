#include "cKeyEvent.h"

INV_EXPORT KeyEventDescriptor
INV_CALL ois_descriptor_of_keyevent(Handle self, OIS::KeyEvent* e)
{
	KeyEventDescriptor x;
	x.base = ois_descriptor_of_eventarg(self, e);
	x.key = const_cast<OIS::KeyCode*>(&e->key);
	x.text = &e->text;

	return x;
}

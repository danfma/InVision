#include "cOIS.h"

KeyEventDescriptor descriptor_of_keyevent(InvHandle handle)
{
	OIS::KeyEvent* obj = castHandle< OIS::KeyEvent >(handle);

	KeyEventDescriptor x;
	x.base = descriptor_of_eventarg(handle);
	x.key = (KEY_CODE*)const_cast<OIS::KeyCode*>(&obj->key);
	x.text = &obj->text;

	return x;
}

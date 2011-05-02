#ifndef KEYBOARD_H
#define KEYBOARD_H

#include "cOIS.h"
#include "cEventArgs.h"

extern "C"
{
	struct KeyEventDescriptor
	{
		EventArgDescriptor base;
		OIS::KeyCode* key;
		_uint* text;
	};

	INV_EXPORT KeyEventDescriptor
	INV_CALL ois_descriptor_of_keyevent(Handle self, OIS::KeyEvent* e);
}

#endif // KEYBOARD_H

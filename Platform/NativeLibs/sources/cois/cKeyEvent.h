#ifndef KEYBOARD_H
#define KEYBOARD_H

#include "cOIS.h"
#include "cEventArgs.h"

extern "C"
{
	struct KeyEventExtended
	{
		EventArgExtended base;
		_int* key;
		_uint* text;
	};

	__export KeyEventExtended __entry ois_keyevent_new_from(HKeyEvent self);
}

#ifdef __cplusplus

	inline OIS::KeyEvent* asKeyEvent(HKeyEvent handle)
	{
		return (OIS::KeyEvent*)handle;
	}

#endif // __cplusplus

#endif // KEYBOARD_H

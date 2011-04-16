#ifndef BUTTON_H
#define BUTTON_H

#include "cOIS.h"
#include "cComponent.h"

extern "C"
{
	struct ButtonExtended {
		ComponentExtended base;
		_bool* pushed;
	};

	/*
	 * OIS::Button
	 */
	__export ButtonExtended __entry ois_button_new(_bool pushed);
	__export void __entry ois_button_delete(HButton self);
}

#endif // BUTTON_H

#ifndef BUTTON_H
#define BUTTON_H

#include "cOIS.h"

extern "C"
{
	/*
	 * OIS::Button
	 */
	struct OISButton
	{
		OISComponent base;
		_bool pushed;
	};
	
	__export OISButton* __entry newOISButton();
	__export void __entry deleteOISButton(OISButton* self);
	__export void __entry refreshOISButton(OISButton* self);
}

#endif // BUTTON_H

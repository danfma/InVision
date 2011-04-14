#ifndef BUTTON_H
#define BUTTON_H

#include "cOIS.h"
#include "cComponent.h"

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
	
	__export OISButton* __entry oisNewButton();
	__export void __entry oisDeleteButton(OISButton* self);
	__export void __entry oisRefreshButton(OISButton* self);
}

#endif // BUTTON_H

#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"

extern "C"
{
	/*
	 * OIS::Component
	 */
	typedef struct _OISComponent
	{
		_any handle;
		_int cType;
	} OISComponent;
	
	__export OISComponent* __entry oisNewComponent();
	__export void __entry oisDeleteComponent(OISComponent* self);
	__export void __entry oisRefreshComponent(OISComponent* self);
}

#endif // CCOMPONENT_H

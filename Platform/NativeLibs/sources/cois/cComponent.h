#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"

extern "C"
{
	/*
	 * OIS::Component
	 */
	struct OISComponent 
	{
		_any handle;
		_int cType;
	};
	
	__export OISComponent* __entry newOISComponent();
	__export void __entry deleteOISComponent(OISComponent* self);
	__export void __entry refreshOISComponent(OISComponent* self);
}

#endif // CCOMPONENT_H

#ifndef CAXIS_H
#define CAXIS_H

#include "cOIS.h"
#include "cComponent.h"

extern "C"
{
	/*
	 * OIS::Axis
	 */
	struct OISAxis
	{
		OISComponent base;
		_int abs;
		_int rel;
		_bool absOnly;
	};
	
	__export OISAxis* __entry oisNewAxis();
	__export void __entry oisDeleteAxis(OISAxis* self);
	__export void __entry oisRefreshAxis(OISAxis* self);
}

#endif // CAXIS_H

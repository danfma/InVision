#ifndef FRAMELISTENER_H
#define FRAMELISTENER_H

#include "cOgre.h"

extern "C"
{
	/*
	 * Support
	 */

	__export HFrameListener __entry framelistener_new(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler);

	__export void __entry framelistener_delete(HFrameListener handle);
}

#endif // FRAMELISTENER_H

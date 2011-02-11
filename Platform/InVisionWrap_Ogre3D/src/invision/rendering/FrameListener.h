#ifndef FRAMELISTENER_H
#define FRAMELISTENER_H

#include "invision/Common.h"

extern "C"
{
	/*
	 * Support
	 */

	__EXPORT HFrameListener __ENTRY framelistener_new(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler);

	__EXPORT void __ENTRY framelistener_delete(HFrameListener handle);
}

#endif // FRAMELISTENER_H

#ifndef FRAMELISTENER_H
#define FRAMELISTENER_H

#include "cOgre.h"

extern "C"
{
	/*
	 * Support
	 */

	INV_EXPORT HFrameListener INV_CALL framelistener_new(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler);

	INV_EXPORT void INV_CALL framelistener_delete(HFrameListener handle);
}

#endif // FRAMELISTENER_H

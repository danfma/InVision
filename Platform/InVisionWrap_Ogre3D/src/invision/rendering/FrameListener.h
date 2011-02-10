#ifndef FRAMELISTENER_H
#define FRAMELISTENER_H

#include "invision/Common.h"

extern "C"
{
	/*
	 * Support
	 */

	__EXPORT HFrameListener __ENTRY FrmListenerNew(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler);

	__EXPORT void __ENTRY FrmListenerDelete(HFrameListener handle);
}

#endif // FRAMELISTENER_H

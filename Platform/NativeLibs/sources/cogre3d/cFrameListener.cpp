#include "FrameListener.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT HFrameListener INV_CALL framelistener_new(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler)
{
	return new CustomFrameListener(frameStartedHandler, frameEndedHandler);
}

INV_EXPORT void INV_CALL framelistener_delete(HFrameListener handle)
{
	delete asCustomFrameListener(handle);
}

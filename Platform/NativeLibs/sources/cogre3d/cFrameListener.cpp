#include "FrameListener.h"
#include "TypeConvert.h"

using namespace invision;

__export HFrameListener __entry framelistener_new(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler)
{
	return new CustomFrameListener(frameStartedHandler, frameEndedHandler);
}

__export void __entry framelistener_delete(HFrameListener handle)
{
	delete asCustomFrameListener(handle);
}

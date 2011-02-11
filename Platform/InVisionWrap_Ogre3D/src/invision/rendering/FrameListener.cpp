#include "invision/rendering/FrameListener.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT HFrameListener __ENTRY framelistener_new(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler)
{
	return new CustomFrameListener(frameStartedHandler, frameEndedHandler);
}

__EXPORT void __ENTRY framelistener_delete(HFrameListener handle)
{
	delete asCustomFrameListener(handle);
}

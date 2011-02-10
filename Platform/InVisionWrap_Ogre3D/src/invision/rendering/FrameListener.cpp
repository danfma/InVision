#include "invision/rendering/FrameListener.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT HFrameListener __ENTRY FrmListenerNew(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler)
{
	return new CustomFrameListener(frameStartedHandler, frameEndedHandler);
}

__EXPORT void __ENTRY FrmListenerDelete(HFrameListener handle)
{
	delete asCustomFrameListener(handle);
}

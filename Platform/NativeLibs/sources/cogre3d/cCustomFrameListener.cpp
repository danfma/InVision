#include "cOgre.h"


INV_EXPORT void
INV_CALL delete_framelistener(InvHandle self)
{
	destroyHandle(self);
}

INV_EXPORT _bool
INV_CALL framelistener_frame_started(InvHandle self, FrameEvent frameEvent)
{
	Ogre::FrameEvent evt;
	evt.timeSinceLastEvent = frameEvent.timeSinceLastEvent;
	evt.timeSinceLastFrame = frameEvent.timeSinceLastFrame;

	return toBool(
				asFrameListener(self)->frameStarted(evt));
}

INV_EXPORT _bool
INV_CALL framelistener_frame_rendering_queued(InvHandle self, FrameEvent frameEvent)
{
	Ogre::FrameEvent evt;
	evt.timeSinceLastEvent = frameEvent.timeSinceLastEvent;
	evt.timeSinceLastFrame = frameEvent.timeSinceLastFrame;

	return toBool(asFrameListener(self)->frameRenderingQueued(evt));
}

INV_EXPORT _bool
INV_CALL framelistener_frame_ended(InvHandle self, FrameEvent frameEvent)
{
	Ogre::FrameEvent evt;
	evt.timeSinceLastEvent = frameEvent.timeSinceLastEvent;
	evt.timeSinceLastFrame = frameEvent.timeSinceLastFrame;

	return toBool(asFrameListener(self)->frameEnded(evt));
}


INV_EXPORT InvHandle
INV_CALL new_customframelistener(FrameEventHandler frameStarted, FrameEventHandler frameEnded, FrameEventHandler frameRenderingQueued)
{
	return createHandle<CustomFrameListener>(
				new CustomFrameListener(frameStarted, frameEnded, frameRenderingQueued));
}

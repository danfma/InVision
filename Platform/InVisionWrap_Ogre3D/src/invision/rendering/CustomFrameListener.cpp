#include "invision/rendering/CustomFrameListener.h"

using namespace invision;

CustomFrameListener::CustomFrameListener(
		FrameEventHandler frameStartedHandler,
		FrameEventHandler frameEndedHandler)
{
	this->frameStartedHandler = frameStartedHandler;
	this->frameEndedHandler = frameEndedHandler;
}

CustomFrameListener::~CustomFrameListener()
{
	this->frameStartedHandler = NULL;
	this->frameEndedHandler = NULL;
}

void CustomFrameListener::copyEventData(const Ogre::FrameEvent &evt)
{
	event.timeSinceLastEvent = evt.timeSinceLastEvent;
	event.timeSinceLastFrame = evt.timeSinceLastFrame;
}

bool CustomFrameListener::frameStarted(const Ogre::FrameEvent &evt)
{
	copyEventData(evt);

	if (!frameStartedHandler)
		return true;

	return frameStartedHandler(&event) == TRUE;
}

bool CustomFrameListener::frameEnded(const Ogre::FrameEvent &evt)
{
	copyEventData(evt);

	if (!frameEndedHandler)
		return true;

	return frameEndedHandler(&event) == TRUE;
}

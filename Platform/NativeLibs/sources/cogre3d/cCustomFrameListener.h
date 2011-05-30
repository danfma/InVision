#ifndef CUSTOMFRAMELISTENER_H
#define CUSTOMFRAMELISTENER_H

#include "cOgre.h"

#ifdef __cplusplus
#include <Ogre.h>

namespace invision
{
	class CustomFrameListener : public Ogre::FrameListener
	{
	private:
		FrameEvent _event;
		FrameEventHandler _frameStarted;
		FrameEventHandler _frameEnded;
		FrameEventHandler _frameRenderingQueued;

		inline void copyEventData(const Ogre::FrameEvent &evt)
		{
			_event.timeSinceLastEvent = evt.timeSinceLastEvent;
			_event.timeSinceLastFrame = evt.timeSinceLastFrame;
		}

	public:
		CustomFrameListener(
			FrameEventHandler frameStartedHandler,
			FrameEventHandler frameEndedHandler,
			FrameEventHandler frameRenderingQueuedHandler)
			: _frameStarted(frameStartedHandler),
			  _frameEnded(frameEndedHandler),
			  _frameRenderingQueued(frameRenderingQueuedHandler)
		{
		}

		bool frameStarted(const Ogre::FrameEvent &evt)
		{
			copyEventData(evt);

			bool result = true;

			if (_frameStarted)
				result = fromBool(_frameStarted(_event));

			return result;
		}

		bool frameEnded(const Ogre::FrameEvent &evt)
		{
			copyEventData(evt);

			bool result = true;

			if (_frameEnded)
				result = fromBool(_frameEnded(_event));

			return result;
		}

		bool frameRenderingQueued(const Ogre::FrameEvent &evt)
		{
			copyEventData(evt);

			bool result = true;

			if (_frameRenderingQueued)
				result = fromBool(_frameRenderingQueued(_event));

			return result;
		}
	};
}

#endif

#endif // CUSTOMFRAMELISTENER_H

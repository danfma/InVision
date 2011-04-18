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
		FrameEvent event;
		FrameEventHandler frameStartedHandler;
		FrameEventHandler frameEndedHandler;

		void copyEventData(const Ogre::FrameEvent &evt);

	public:
		CustomFrameListener(
				FrameEventHandler frameStartedHandler,
				FrameEventHandler frameEndedHandler);

		~CustomFrameListener();

		bool frameStarted(const Ogre::FrameEvent &evt);
		bool frameEnded(const Ogre::FrameEvent &evt);
	};
}

#endif

#endif // CUSTOMFRAMELISTENER_H

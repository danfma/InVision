#ifndef __INVISIONNATIVE_OGRE_FRAME_EVENT_H__
#define __INVISIONNATIVE_OGRE_FRAME_EVENT_H__

#include <InvisionHandle.h>
#include "invisionnative_ogre.h"

extern "C"
{
	/**
	 * Type FrameEvent
	 */
	struct FrameEvent
	{
		_float timeSinceLastEvent;
		_float timeSinceLastFrame;
	};
	
}

#endif // __INVISIONNATIVE_OGRE_FRAME_EVENT_H__


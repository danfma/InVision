#ifndef __INVISIONNATIVE_OGRE_FRAME_STATS_H__
#define __INVISIONNATIVE_OGRE_FRAME_STATS_H__

#include <InvisionHandle.h>
#include "invisionnative_ogre.h"

extern "C"
{
	/**
	 * Type FrameStats
	 */
	struct FrameStats
	{
		_float lastFPS;
		_float avgFPS;
		_float bestFPS;
		_float worstFPS;
		_ulong bestFrameTime;
		_ulong worstFrameTime;
		_int triangleCount;
		_int batchCount;
	};
	
}

#endif // __INVISIONNATIVE_OGRE_FRAME_STATS_H__


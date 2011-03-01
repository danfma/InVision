#ifndef INVISION_OGRE_COMMON_H
#define INVISION_OGRE_COMMON_H

#include "invision/Common.h"

#ifdef __cplusplus
#include <Ogre.h>
#endif // __cplusplus

extern "C"
{
	typedef Handle HLogManager;
	typedef Handle HOverlayManager;
	typedef Handle HOverlay;
	typedef Handle HOverlayElement;


	struct FrameStats
	{
		float lastFPS;
		float avgFPS;
		float bestFPS;
		float worstFPS;
		UInt64 bestFrameTime;
		UInt64 worstFrameTime;
		Int32 triangleCount;
		Int32 batchCount;

#ifdef __cplusplus
		FrameStats(Ogre::RenderTarget::FrameStats& stats)
			: lastFPS(stats.lastFPS),
			  avgFPS(stats.avgFPS),
			  bestFPS(stats.bestFPS),
			  worstFPS(stats.worstFPS),
			  bestFrameTime(stats.bestFrameTime),
			  worstFrameTime(stats.worstFrameTime),
			  triangleCount(stats.triangleCount),
			  batchCount(stats.batchCount)
		{ }
#endif
	};


	__export void __entry delete_framestats(FrameStats* data);
}

#endif

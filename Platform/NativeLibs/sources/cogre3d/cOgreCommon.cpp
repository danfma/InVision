#include "OgreCommon.h"

__export void __entry delete_framestats(FrameStats* data)
{
	if (data != NULL)
		delete data;
}

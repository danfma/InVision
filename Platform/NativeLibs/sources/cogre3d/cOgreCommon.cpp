#include "OgreCommon.h"

INV_EXPORT void INV_CALL delete_framestats(FrameStats* data)
{
	if (data != NULL)
		delete data;
}

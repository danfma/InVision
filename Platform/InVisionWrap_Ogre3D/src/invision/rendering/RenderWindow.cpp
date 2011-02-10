#include "RenderWindow.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT UInt32 __ENTRY RndrWinGetWidth(HRenderWindow self)
{
	return asRenderWindow(self)->getWidth();
}

__EXPORT UInt32 __ENTRY RndrWinGetHeight(HRenderWindow self)
{
	return asRenderWindow(self)->getHeight();
}

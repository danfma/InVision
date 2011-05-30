#include "cOgre.h"

INV_EXPORT void
INV_CALL overlay_show(InvHandle self)
{
	return asOverlay(self)->show();
}

#include "cOgre.h"

using namespace Ogre;

/**
 * Method: RenderWindow::getCustomAttribute
 */
INV_EXPORT void
INV_CALL renderwindow_get_custom_attribute(InvHandle self, _string name, _any* data)
{
	asRenderWindow(self)->getCustomAttribute(name, data);
}

/**
 * Method: RenderWindow::addViewport
 */
INV_EXPORT InvHandle
INV_CALL renderwindow_add_viewport(InvHandle self, InvHandle camera, _int zOrder, _float left, _float top, _float width, _float height)
{
	return createReference<Viewport>(
				asRenderWindow(self)->addViewport(
					asCamera(camera),
					zOrder, left, top, width, height));
}

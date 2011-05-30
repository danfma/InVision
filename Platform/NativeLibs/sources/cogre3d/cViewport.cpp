#include "cOgre.h"

INV_EXPORT InvHandle
INV_CALL new_viewport(InvHandle camera, InvHandle renderTarget, _float left, _float top, _float width, _float height, _int zOrder)
{
	return createHandle<Ogre::Viewport>(
				new Ogre::Viewport(
					asCamera(camera),
					asRenderTarget(renderTarget),
					left,
					top,
					width,
					height,
					zOrder));
}

INV_EXPORT void
INV_CALL delete_viewport(InvHandle self)
{
	destroyHandle(self);
}

/**
 * Method: Viewport::setBackgroundColor
 */
INV_EXPORT void
INV_CALL viewport_set_background_color(InvHandle self, Color color)
{
	asViewport(self)->setBackgroundColour(color_convert_to_ogre(color));
}

INV_EXPORT Color
INV_CALL viewport_get_background_color(InvHandle self)
{
	return color_convert_from_ogre(
				asViewport(self)->getBackgroundColour());
}

INV_EXPORT void
INV_CALL viewport_update(InvHandle self)
{
	asViewport(self)->update();
}

INV_EXPORT void
INV_CALL viewport_clear(InvHandle self)
{
	asViewport(self)->clear();
}

INV_EXPORT InvHandle
INV_CALL viewport_get_camera(InvHandle self)
{
	return createReference<Ogre::Camera>(
				asViewport(self)->getCamera());
}

INV_EXPORT void
INV_CALL viewport_set_camera(InvHandle self, InvHandle camera)
{
	asViewport(self)->setCamera(asCamera(camera));
}

INV_EXPORT _float
INV_CALL viewport_get_left(InvHandle self)
{
	return asViewport(self)->getLeft();
}

INV_EXPORT _float
INV_CALL viewport_get_top(InvHandle self)
{
	return asViewport(self)->getTop();
}

INV_EXPORT _float
INV_CALL viewport_get_width(InvHandle self)
{
	return asViewport(self)->getWidth();
}

INV_EXPORT _float
INV_CALL viewport_get_height(InvHandle self)
{
	return asViewport(self)->getHeight();
}

INV_EXPORT _int
INV_CALL viewport_get_actual_left(InvHandle self)
{
	return asViewport(self)->getActualLeft();
}

INV_EXPORT _int
INV_CALL viewport_get_actual_top(InvHandle self)
{
	return asViewport(self)->getActualTop();
}

INV_EXPORT _int
INV_CALL viewport_get_actual_width(InvHandle self)
{
	return asViewport(self)->getActualWidth();
}

INV_EXPORT _int
INV_CALL viewport_get_actual_height(InvHandle self)
{
	return asViewport(self)->getActualHeight();
}

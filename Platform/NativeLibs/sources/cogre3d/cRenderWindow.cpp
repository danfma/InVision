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

/**
 * Method: RenderWindow::isClosed
 */
INV_EXPORT _bool
INV_CALL renderwindow_is_closed(InvHandle self)
{
	return toBool(asRenderWindow(self)->isClosed());
}

INV_EXPORT _string
INV_CALL renderwindow_write_contents_to_timestamped_file(InvHandle self, _string filenamePrefix, _string filenameSuffix)
{
	return copyString(asRenderWindow(self)->writeContentsToTimestampedFile(filenamePrefix, filenameSuffix));
}

INV_EXPORT FrameStats
INV_CALL renderwindow_get_statistics(InvHandle self)
{
	const Ogre::RenderWindow::FrameStats& result = asRenderWindow(self)->getStatistics();

	FrameStats stats;
	stats.avgFPS = result.avgFPS;
	stats.batchCount = result.batchCount;
	stats.bestFPS = result.bestFPS;
	stats.bestFrameTime = result.bestFrameTime;
	stats.lastFPS = result.lastFPS;
	stats.triangleCount = result.triangleCount;
	stats.worstFPS = result.worstFPS;
	stats.worstFrameTime = result.worstFrameTime;

	return stats;
}

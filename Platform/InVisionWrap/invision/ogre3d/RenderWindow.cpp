#include "RenderWindow.h"
#include "TypeConvert.h"

using namespace invision;

__export UInt32 __entry ogre_renderwindow_get_width(HRenderWindow self)
{
	return asRenderWindow(self)->getWidth();
}

__export UInt32 __entry ogre_renderwindow_get_height(HRenderWindow self)
{
	return asRenderWindow(self)->getHeight();
}

__export HViewport __entry ogre_renderwindow_add_viewport(
	HRenderWindow self,
	HCamera camera,
	int zOrder,
	float left,
	float top,
	float width,
	float height)
{
	return asRenderWindow(self)->addViewport(
				asCamera(camera),
				zOrder,
				left, top,
				width, height);
}

__export String __entry ogre_renderwindow_write_contents_to_timestamped_file(
	HRenderWindow self,
	ConstString prefix,
	ConstString suffix)
{
	Ogre::String s = asRenderWindow(self)->writeContentsToTimestampedFile(prefix, suffix);

	return copyString(s);
}

__export void __entry ogre_renderwindow_get_custom_attrib(
		HRenderWindow self,
		ConstString name,
		Any data)
{
	asRenderWindow(self)->getCustomAttribute(name, data);
}

__export FrameStats* __entry ogre_get_statistics(HRenderWindow self)
{
	Ogre::RenderTarget::FrameStats f = asRenderWindow(self)->getStatistics();

	return new FrameStats(f);
}

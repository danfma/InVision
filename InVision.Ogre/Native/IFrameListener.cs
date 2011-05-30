using InVision.Native;
using InVision.Ogre.Listeners;

namespace InVision.Ogre.Native
{
	[OgreClass("FrameListener")]
	public interface IFrameListener : ICppInstance
	{
		[Destructor(Implemented = true)]
		void Destruct();

		[Method(Implemented = true)]
		bool FrameStarted(FrameEvent frameEvent);

		[Method(Implemented = true)]
		bool FrameRenderingQueued(FrameEvent frameEvent);

		[Method(Implemented = true)]
		bool FrameEnded(FrameEvent frameEvent);
	}
}
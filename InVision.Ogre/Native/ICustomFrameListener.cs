using InVision.Native;
using InVision.Ogre.Listeners;

namespace InVision.Ogre.Native
{
	[CppClass("CustomFrameListener", DefinitionFile = "cCustomFrameListener.h", LocalDefinition = true)]
	public interface ICustomFrameListener : IFrameListener
	{
		[Constructor(Implemented = true)]
		ICustomFrameListener Construct(
			FrameEventHandler frameStarted,
			FrameEventHandler frameEnded,
			FrameEventHandler frameRenderingQueued = null);
	}
}
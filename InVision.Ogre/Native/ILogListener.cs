using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("LogListener")]
	public interface ILogListener : ICppInstance
	{
		[Destructor(Implemented = true)]
		void Destruct();
	}
}
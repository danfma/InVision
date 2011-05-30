using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("Singleton", Type = ClassType.Interface)]
	public interface ISingleton<out T> where T : ICppInstance
	{
		[Method(Static = true, Implemented = true)]
		T GetSingleton();
	}
}
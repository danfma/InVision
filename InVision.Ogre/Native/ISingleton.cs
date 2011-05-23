using InVision.Native;

namespace InVision.Ogre.Native
{
	[CppInterface("Singleton", CppInterfaceType = CppInterfaceType.Interface)]
	public interface ISingleton<out T> where T : ICppInterface
	{
		[Method(Static = true)]
		T GetSingleton();
	}
}
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("Overlay")]
	public interface IOverlay : ICppInstance
	{
		[Method(Implemented = true)]
		void Show();
	}
}
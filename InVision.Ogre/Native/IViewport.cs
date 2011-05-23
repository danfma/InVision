using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreInterface("Viewport")]
	public interface IViewport : ICppInterface
	{
		[Method]
		void SetBackgroundColor(Color color);
	}
}
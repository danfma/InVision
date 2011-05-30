using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("Light", BaseType = typeof(IMovableObject))]
	public interface ILight : IMovableObject
	{
		[Method(Implemented = true)]
		void SetPosition(float x, float y, float z);

		[Method(Implemented = true)]
		void SetPosition(Vector3 pos);

		[Method(Implemented = true)]
		Vector3 GetPosition();
	}
}
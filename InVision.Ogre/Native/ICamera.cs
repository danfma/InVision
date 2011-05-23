using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreInterface("Camera")]
	public interface ICamera : ICppInterface
	{
		[Method]
		void SetPosition(Vector3 pos);

		[Method]
		void LookAt(Vector3 direction);

		[Method]
		void SetNearClipDistance(float distance);

		[Method]
		void SetAspectRatio(float aspectRatio);
	}
}
using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("Camera")]
	public interface ICamera : IFrustum
	{
		[Method(Implemented = true)]
		Vector3 GetPosition();

		[Method(Implemented = true)]
		void SetPosition(Vector3 pos);

		[Method(Implemented = true)]
		void LookAt(Vector3 direction);

		[Method(Implemented = true)]
		float GetNearClipDistance();

		[Method(Implemented = true)]
		void SetNearClipDistance(float distance);

		[Method(Implemented = true)]
		float GetAspectRatio();

		[Method(Implemented = true)]
		void SetAspectRatio(float aspectRatio);

		[Method(Implemented = true)]
		float GetFarClipDistance();

		[Method(Implemented = true)]
		void SetFarClipDistance(float value);

		[Method(Implemented = true)]
		void SetAutoAspectRatio(bool value);

		[Method(Implemented = true)]
		PolygonMode GetPolygonMode();

		[Method(Implemented = true)]
		void SetPolygonMode(PolygonMode value);

		[Method(Implemented = true)]
		Vector3 GetDirection();

		[Method(Implemented = true)]
		Vector3 GetRight();

		[Method(Implemented = true)]
		Vector3 GetUp();

		[Method(Implemented = true)]
		void Move(Vector3 distance);

		[Method(Implemented = true)]
		void Yaw(float valueRadians);

		[Method(Implemented = true)]
		void Pitch(float valueRadians);

		[Method(Implemented = true)]
		float GetFovY();

		[Method(Implemented = true)]
		void SetFovY(float value);
	}
}
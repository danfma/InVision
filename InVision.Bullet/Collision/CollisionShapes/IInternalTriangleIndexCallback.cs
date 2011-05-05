using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public interface IInternalTriangleIndexCallback
	{
		void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex);
		void Cleanup();
	}
}
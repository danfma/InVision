using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public interface IDiscreteCollisionDetectorInterfaceResult
	{
		void SetShapeIdentifiersA(int partId0,int index0);
		void SetShapeIdentifiersB(int partId1, int index1);
		void AddContactPoint(Vector3 normalOnBInWorld, Vector3 pointInWorld, float depth);
		void AddContactPoint(ref Vector3 normalOnBInWorld,ref Vector3 pointInWorld,float depth);
	}
}
using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class SphereTriangleCreateFunc : CollisionAlgorithmCreateFunc
	{
		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0,CollisionObject body1)
		{
			return new SphereTriangleCollisionAlgorithm(ci.GetManifold(),ci,body0,body1,m_swapped);
		}
	}
}
using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class SphereSphereCreateFunc : CollisionAlgorithmCreateFunc
	{
		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0,CollisionObject body1)
		{
			return new SphereSphereCollisionAlgorithm(null,ci,body0,body1);
		}
	}
}
using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class EmptyCreateFunc :CollisionAlgorithmCreateFunc
	{
		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0,CollisionObject body1)
		{
			return new EmptyAlgorithm(ci);
		}
	}
}
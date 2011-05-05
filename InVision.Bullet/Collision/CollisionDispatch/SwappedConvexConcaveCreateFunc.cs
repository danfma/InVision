using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class SwappedConvexConcaveCreateFunc : CollisionAlgorithmCreateFunc
	{
		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0, CollisionObject body1)
		{
			return new ConvexConcaveCollisionAlgorithm(ci, body0, body1, true);
		}
	}
}
using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class BoxBoxCreateFunc :CollisionAlgorithmCreateFunc
	{
		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0,CollisionObject body1)
		{
			return new BoxBoxCollisionAlgorithm(null,ci,body0,body1);
		}
	}
}
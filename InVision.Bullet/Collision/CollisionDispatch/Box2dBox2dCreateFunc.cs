using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class Box2dBox2dCreateFunc : CollisionAlgorithmCreateFunc
	{
		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0, CollisionObject body1)
		{
			return new Box2dBox2dCollisionAlgorithm(null, ci, body0, body1);
		}
	}
}
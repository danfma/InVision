using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public interface INearCallback
	{
		void NearCallback(BroadphasePair collisionPair, CollisionDispatcher dispatcher, DispatcherInfo dispatchInfo);
	}
}
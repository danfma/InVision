namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public interface IOverlapFilterCallback
	{
		// return true when pairs need collision
		bool NeedBroadphaseCollision(BroadphaseProxy proxy0,BroadphaseProxy proxy1);
	}
}
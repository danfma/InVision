namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public interface IBroadphaseAabbCallback 
	{
		void Cleanup();
		bool Process(BroadphaseProxy proxy);
	}
}
namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public interface IOverlapCallback
	{
		//return true for deletion of the pair
		bool ProcessOverlap(BroadphasePair pair);
	}
}
namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class RemovingOverlapCallback : IOverlapCallback
	{
		public virtual bool	ProcessOverlap(BroadphasePair pair)
		{
			//(void)pair;
			//btAssert(0);
			return false;
		}
	}
}
namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class CheckOverlapCallback : IOverlapCallback
	{
		public virtual bool ProcessOverlap(BroadphasePair pair)
		{
			return (!SimpleBroadphase.AabbOverlap((SimpleBroadphaseProxy)(pair.m_pProxy0),(SimpleBroadphaseProxy)(pair.m_pProxy1)));
		}
	}
}
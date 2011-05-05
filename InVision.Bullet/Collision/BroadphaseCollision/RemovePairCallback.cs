namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class RemovePairCallback : IOverlapCallback
	{
		private BroadphaseProxy m_obsoleteProxy;

		public RemovePairCallback(BroadphaseProxy obsoleteProxy)
		{
			m_obsoleteProxy = obsoleteProxy;
		}
		public virtual bool ProcessOverlap(BroadphasePair pair)
		{
			return (pair != null && ((pair.m_pProxy0 == m_obsoleteProxy) ||
			                         (pair.m_pProxy1 == m_obsoleteProxy)));
		}
	}
}
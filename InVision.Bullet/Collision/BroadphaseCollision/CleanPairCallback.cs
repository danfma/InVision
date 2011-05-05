namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class CleanPairCallback : IOverlapCallback
	{
		private BroadphaseProxy m_cleanProxy;
		private IOverlappingPairCache m_pairCache;
		private IDispatcher m_dispatcher;

		public CleanPairCallback(BroadphaseProxy cleanProxy,IOverlappingPairCache pairCache,IDispatcher dispatcher)
		{
			m_cleanProxy = cleanProxy;
			m_pairCache = pairCache;
			m_dispatcher = dispatcher;
		}
		public virtual bool ProcessOverlap(BroadphasePair pair)
		{
			if (pair != null && ((pair.m_pProxy0 == m_cleanProxy) ||
			                     (pair.m_pProxy1 == m_cleanProxy)))
			{
				m_pairCache.CleanOverlappingPair(pair,m_dispatcher);
			}
			return false;
		}
	}
}
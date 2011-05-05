using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	///interface for iterating all overlapping collision pairs, no matter how those pairs are stored (array, set, map etc)
	///this is useful for the collision dispatcher.
	public class CollisionPairCallback : IOverlapCallback
	{
		public CollisionPairCallback(DispatcherInfo dispatchInfo,CollisionDispatcher dispatcher)
		{
			m_dispatchInfo = dispatchInfo;
			m_dispatcher = dispatcher;
		}

		/*btCollisionPairCallback& operator=(btCollisionPairCallback& other)
	    {
		    m_dispatchInfo = other.m_dispatchInfo;
		    m_dispatcher = other.m_dispatcher;
		    return *this;
	    }
	    */

		public virtual void cleanup()
		{
		}

		public virtual bool	ProcessOverlap(BroadphasePair pair)
		{
			m_dispatcher.GetNearCallback().NearCallback(pair, m_dispatcher, m_dispatchInfo);
			return false;
		}
		DispatcherInfo m_dispatchInfo;
		CollisionDispatcher	m_dispatcher;
	}
}
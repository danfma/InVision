using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class PairCachingGhostObject : GhostObject
	{
		public PairCachingGhostObject()
		{
			m_hashPairCache = new HashedOverlappingPairCache();
		}

		public override void Cleanup()
		{
			m_hashPairCache.Cleanup();
			m_hashPairCache = null;
		}

		///this method is mainly for expert/internal use only.
		public override void AddOverlappingObjectInternal(BroadphaseProxy otherProxy, BroadphaseProxy thisProxy)
		{
			BroadphaseProxy actualThisProxy = thisProxy != null ? thisProxy : GetBroadphaseHandle();
			System.Diagnostics.Debug.Assert(actualThisProxy != null);

			CollisionObject otherObject = (CollisionObject)otherProxy.m_clientObject;
			System.Diagnostics.Debug.Assert(otherObject != null);
			if(!m_overlappingObjects.Contains(otherObject))
			{
				m_overlappingObjects.Add(otherObject);
				m_hashPairCache.AddOverlappingPair(actualThisProxy, otherProxy);
			}
		}

		public override void RemoveOverlappingObjectInternal(BroadphaseProxy otherProxy, IDispatcher dispatcher, BroadphaseProxy thisProxy)
		{
			CollisionObject otherObject = (CollisionObject)otherProxy.m_clientObject;
			BroadphaseProxy actualThisProxy = thisProxy != null ? thisProxy : GetBroadphaseHandle();
			System.Diagnostics.Debug.Assert(actualThisProxy != null);

			System.Diagnostics.Debug.Assert(otherObject != null);
			if(m_overlappingObjects.Contains(otherObject))
			{
				m_overlappingObjects.Remove(otherObject);
				m_hashPairCache.RemoveOverlappingPair(actualThisProxy, otherProxy, dispatcher);
			}
		}

		public HashedOverlappingPairCache GetOverlappingPairCache()
		{
			return m_hashPairCache;
		}

		private HashedOverlappingPairCache	m_hashPairCache;

	}
}
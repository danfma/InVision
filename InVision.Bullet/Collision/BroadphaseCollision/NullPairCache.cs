using System;
using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	///btNullPairCache skips add/removal of overlapping pairs. Userful for benchmarking and unit testing.
	public class NullPairCache : IOverlappingPairCache
	{
		private ObjectArray<BroadphasePair> m_overlappingPairArray;

		//public virtual BroadphasePair	getOverlappingPairArrayPtr()
		//{
		//    return &m_overlappingPairArray[0];
		//}

		public virtual void Cleanup()
		{
		}


		public ObjectArray<BroadphasePair> GetOverlappingPairArray()
		{
			return m_overlappingPairArray;
		}
    	
		public virtual void CleanOverlappingPair(BroadphasePair pair,IDispatcher disaptcher)
		{

		}

		public virtual int GetNumOverlappingPairs()
		{
			return 0;
		}

		public virtual void	CleanProxyFromPairs(BroadphaseProxy proxy,IDispatcher dispatcher)
		{

		}

		public virtual void SetOverlapFilterCallback(IOverlapFilterCallback callback)
		{
		}

		public virtual void	ProcessAllOverlappingPairs(IOverlapCallback callback,IDispatcher dispatcher)
		{
		}

		public virtual BroadphasePair FindPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return null;
		}

		public virtual bool	HasDeferredRemoval()
		{
			return true;
		}

		public virtual void	SetInternalGhostPairCallback(IOverlappingPairCallback ghostPairCallback)
		{

		}

		public virtual BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0,BroadphaseProxy proxy1)
		{
			return null;
		}

		public virtual Object RemoveOverlappingPair(BroadphaseProxy proxy0,BroadphaseProxy proxy1,IDispatcher dispatcher)
		{
			return null;
		}

		public virtual void	RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy0,IDispatcher dispatcher)
		{
		}
    	
		public virtual void	SortOverlappingPairs(IDispatcher dispatcher)
		{
		}
	}
}
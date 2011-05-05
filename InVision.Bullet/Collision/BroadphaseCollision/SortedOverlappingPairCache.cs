using System;
using System.Diagnostics;
using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	///btSortedOverlappingPairCache maintains the objects with overlapping AABB
	///Typically managed by the Broadphase, Axis3Sweep or btSimpleBroadphase
	public class SortedOverlappingPairCache : IOverlappingPairCache
	{
		public SortedOverlappingPairCache()
		{
			m_blockedForChanges = false;
			m_hasDeferredRemoval = true;
			m_overlapFilterCallback = null;
			m_ghostPairCallback = null;
			m_overlappingPairArray = new ObjectArray<BroadphasePair>(2);
		}

		//virtual ~btSortedOverlappingPairCache();
		public virtual void Cleanup()
		{
		}

		public virtual void ProcessAllOverlappingPairs(IOverlapCallback callback, IDispatcher dispatcher)
		{
			for (int i = 0; i < m_overlappingPairArray.Count; )
			{
				BroadphasePair pair = m_overlappingPairArray[i];
				if (callback.ProcessOverlap(pair))
				{
					CleanOverlappingPair(pair, dispatcher);
					pair.m_pProxy0 = null;
					pair.m_pProxy1 = null;
					m_overlappingPairArray.RemoveAt(m_overlappingPairArray.Count - 1);
					OverlappingPairCacheGlobals.gOverlappingPairs--;
				}
				else
				{
					i++;
				}
			}
		}

		public Object RemoveOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1, IDispatcher dispatcher)
		{
			if (!HasDeferredRemoval())
			{
				BroadphasePair findPair = new BroadphasePair(proxy0,proxy1);

				int findIndex = m_overlappingPairArray.IndexOf(findPair);
				if (findIndex >= 0 && findIndex < m_overlappingPairArray.Count)
				{
					OverlappingPairCacheGlobals.gOverlappingPairs--;
					BroadphasePair pair = m_overlappingPairArray[findIndex];
					Object userData = pair.m_internalInfo1;
					CleanOverlappingPair(pair,dispatcher);
					if (m_ghostPairCallback != null)
					{
						m_ghostPairCallback.RemoveOverlappingPair(proxy0, proxy1,dispatcher);
					}
					//BroadphasePair temp = m_overlappingPairArray[findIndex];
					//m_overlappingPairArray[findIndex] = m_overlappingPairArray[m_overlappingPairArray.Count-1];
					//m_overlappingPairArray[m_overlappingPairArray.Count-1] = temp;
					m_overlappingPairArray.RemoveAt(m_overlappingPairArray.Count - 1);
					return userData;
				}
			}

			return 0;
		}

		public void CleanOverlappingPair(BroadphasePair pair, IDispatcher dispatcher)
		{
			if (pair.m_algorithm != null)
			{
				{
					pair.m_algorithm.Cleanup();
					dispatcher.FreeCollisionAlgorithm(pair.m_algorithm);
					pair.m_algorithm = null;
					OverlappingPairCacheGlobals.gRemovePairs--;
				}
			}
		}

		public BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			//don't add overlap with own
			Debug.Assert(proxy0 != proxy1);

			if (!NeedsBroadphaseCollision(proxy0,proxy1))
			{
				return null;
			}
			// MAN - 2.76 - uses expand noninitializing....??
			BroadphasePair pair = new BroadphasePair(proxy0,proxy1);
			m_overlappingPairArray.Add(pair);

			OverlappingPairCacheGlobals.gOverlappingPairs++;
			OverlappingPairCacheGlobals.gAddedPairs++;

			if (m_ghostPairCallback != null)
			{
				m_ghostPairCallback.AddOverlappingPair(proxy0, proxy1);
			}
			return pair;
		}

		public BroadphasePair FindPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			if (!NeedsBroadphaseCollision(proxy0,proxy1))
			{
				return null;
			}

			BroadphasePair tmpPair = new BroadphasePair(proxy0,proxy1);
			int index = m_overlappingPairArray.IndexOf(tmpPair);
			if (index != -1)
			{
				return m_overlappingPairArray[index];
			}
			return null;
		}

		public void CleanProxyFromPairs(BroadphaseProxy proxy, IDispatcher dispatcher)
		{
			CleanPairCallback cleanPairs = new CleanPairCallback(proxy,this,dispatcher);
			ProcessAllOverlappingPairs(cleanPairs,dispatcher);
		}

		public void RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy, IDispatcher dispatcher)
		{
			RemovePairCallback removeCallback = new RemovePairCallback(proxy);
			ProcessAllOverlappingPairs(removeCallback,dispatcher);
		}

		public bool NeedsBroadphaseCollision(BroadphaseProxy proxy0,BroadphaseProxy proxy1)
		{
			if (m_overlapFilterCallback != null)
			{
				return m_overlapFilterCallback.NeedBroadphaseCollision(proxy0,proxy1);
			}
			bool collides = (proxy0.m_collisionFilterGroup & proxy1.m_collisionFilterMask) != 0;
			collides = collides && ((proxy1.m_collisionFilterGroup & proxy0.m_collisionFilterMask) != 0);
			return collides;
		}

		public ObjectArray<BroadphasePair> GetOverlappingPairArray()
		{
			return m_overlappingPairArray;
		}

		public int GetNumOverlappingPairs()
		{
			return m_overlappingPairArray.Count;
		}
		
		public IOverlapFilterCallback GetOverlapFilterCallback()
		{
			return m_overlapFilterCallback;
		}

		public void SetOverlapFilterCallback(IOverlapFilterCallback callback)
		{
			m_overlapFilterCallback = callback;
		}

		public virtual bool	HasDeferredRemoval()
		{
			return m_hasDeferredRemoval;
		}

		public virtual void	SetInternalGhostPairCallback(IOverlappingPairCallback ghostPairCallback)
		{
			m_ghostPairCallback = ghostPairCallback;
		}

		public virtual void SortOverlappingPairs(IDispatcher dispatcher)
		{
			//should already be sorted
		}
		//avoid brute-force finding all the time
		protected ObjectArray<BroadphasePair> m_overlappingPairArray;

		//during the dispatch, check that user doesn't destroy/create proxy
		protected bool m_blockedForChanges;

		///by default, do the removal during the pair traversal
		protected bool m_hasDeferredRemoval;
		
		//if set, use the callback instead of the built in filter in needBroadphaseCollision
		protected IOverlapFilterCallback m_overlapFilterCallback;

		protected IOverlappingPairCallback	m_ghostPairCallback;

	}
}
using System;
using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	///The btGhostPairCallback interfaces and forwards adding and removal of overlapping pairs from the btBroadphaseInterface to btGhostObject.
	public class GhostPairCallback : IOverlappingPairCallback
	{
		public GhostPairCallback()
		{
		}

		public virtual void cleanup()
		{
		}

		public virtual BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0,BroadphaseProxy proxy1)
		{
			CollisionObject colObj0 = (CollisionObject) proxy0.m_clientObject;
			CollisionObject colObj1 = (CollisionObject) proxy1.m_clientObject;
			GhostObject ghost0 = GhostObject.Upcast(colObj0);
			GhostObject ghost1 = GhostObject.Upcast(colObj1);
			if (ghost0 != null)
			{
				ghost0.AddOverlappingObjectInternal(proxy1, proxy0);
			}
			if (ghost1 != null)
			{
				ghost1.AddOverlappingObjectInternal(proxy0, proxy1);
			}
			return null;
		}

		public virtual Object RemoveOverlappingPair(BroadphaseProxy proxy0,BroadphaseProxy proxy1,IDispatcher dispatcher)
		{
			CollisionObject colObj0 = (CollisionObject) proxy0.m_clientObject;
			CollisionObject colObj1 = (CollisionObject) proxy1.m_clientObject;
			GhostObject ghost0 = GhostObject.Upcast(colObj0);
			GhostObject ghost1 = GhostObject.Upcast(colObj1);
			if (ghost0 != null)
			{
				ghost0.RemoveOverlappingObjectInternal(proxy1, dispatcher, proxy0);
			}
			if (ghost1 != null)
			{
				ghost1.RemoveOverlappingObjectInternal(proxy0, dispatcher, proxy1);
			}
			return null;
		}

		public virtual void RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy0,IDispatcher dispatcher)
		{
			System.Diagnostics.Debug.Assert(false);
			//need to keep track of all ghost objects and call them here
			//m_hashPairCache->removeOverlappingPairsContainingProxy(proxy0,dispatcher);
		}
	}
}
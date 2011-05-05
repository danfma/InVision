using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionDispatch;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Dynamics
{
	public class ClosestNotMeConvexResultCallback : ClosestConvexResultCallback
	{
		public CollisionObject m_me;
		public float m_allowedPenetration;
		public IOverlappingPairCache m_pairCache;
		public IDispatcher m_dispatcher;

		public ClosestNotMeConvexResultCallback(CollisionObject me, Vector3 fromA, Vector3 toA, IOverlappingPairCache pairCache, IDispatcher dispatcher)
			: this(me, ref fromA, ref toA, pairCache, dispatcher)
		{
		}
		public ClosestNotMeConvexResultCallback(CollisionObject me, ref Vector3 fromA, ref Vector3 toA, IOverlappingPairCache pairCache, IDispatcher dispatcher) :
			base(ref fromA, ref toA)
		{
			m_allowedPenetration = 0.0f;
			m_me = me;
			m_pairCache = pairCache;
			m_dispatcher = dispatcher;
		}

		public override float AddSingleResult(LocalConvexResult convexResult, bool normalInWorldSpace)
		{
			if (convexResult.m_hitCollisionObject == m_me)
				return 1.0f;

			//ignore result if there is no contact response
			if (!convexResult.m_hitCollisionObject.HasContactResponse())
				return 1.0f;

			Vector3 linVelA, linVelB;
			linVelA = m_convexToWorld - m_convexFromWorld;
			linVelB = Vector3.Zero;//toB.getOrigin()-fromB.getOrigin();

			Vector3 relativeVelocity = (linVelA - linVelB);
			//don't report time of impact for motion away from the contact normal (or causes minor penetration)
			if (Vector3.Dot(convexResult.m_hitNormalLocal, relativeVelocity) >= -m_allowedPenetration)
				return 1f;

			return base.AddSingleResult(convexResult, normalInWorldSpace);
		}

		public override bool NeedsCollision(BroadphaseProxy proxy0)
		{
			//don't collide with itself
			if (proxy0.m_clientObject == m_me)
				return false;

			///don't do CCD when the collision filters are not matching
			if (!base.NeedsCollision(proxy0))
				return false;

			CollisionObject otherObj = (CollisionObject)proxy0.m_clientObject;

			//call needsResponse, see http://code.google.com/p/bullet/issues/detail?id=179
			if (m_dispatcher.NeedsResponse(m_me, otherObj))
			{
				///don't do CCD when there are already contact points (touching contact/penetration)
				ObjectArray<PersistentManifold> manifoldArray = new ObjectArray<PersistentManifold>();
				BroadphasePair collisionPair = m_pairCache.FindPair(m_me.GetBroadphaseHandle(), proxy0);
				if (collisionPair != null)
				{
					if (collisionPair.m_algorithm != null)
					{
						collisionPair.m_algorithm.GetAllContactManifolds(manifoldArray);
						int length = manifoldArray.Count;
						for (int i = 0; i < length; ++i)
						{
							if (manifoldArray[i].GetNumContacts() > 0)
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}
	}
}
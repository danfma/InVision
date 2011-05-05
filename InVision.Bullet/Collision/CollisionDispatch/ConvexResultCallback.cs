using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	///RayResultCallback is used to report new raycast results
	public abstract class ConvexResultCallback
	{
		public ConvexResultCallback()
		{
			m_closestHitFraction = 1f;
			m_collisionFilterGroup = CollisionFilterGroups.DefaultFilter;
			m_collisionFilterMask = CollisionFilterGroups.AllFilter;
		}

		public bool hasHit()
		{
			return (m_closestHitFraction < 1f);
		}

		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			bool collides = (proxy0.m_collisionFilterGroup & m_collisionFilterMask) != 0;
			collides = collides && ((m_collisionFilterGroup & proxy0.m_collisionFilterMask) != 0);
			return collides;
		}

		public abstract float AddSingleResult(LocalConvexResult convexResult,bool normalInWorldSpace);

		public float m_closestHitFraction;
		public CollisionFilterGroups m_collisionFilterGroup;
		public CollisionFilterGroups m_collisionFilterMask;
		
	};
}
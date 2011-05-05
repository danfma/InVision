using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.NarrowPhaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	///RayResultCallback is used to report new raycast results
	public abstract class RayResultCallback
	{

		public bool	HasHit()
		{
			return (m_collisionObject != null);
		}

		public RayResultCallback()
		{
			m_closestHitFraction = 1f;
			m_collisionObject = null;
			m_collisionFilterGroup = CollisionFilterGroups.DefaultFilter;
			m_collisionFilterMask = CollisionFilterGroups.AllFilter;
			//@BP Mod
			m_flags = 0;
		}

		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			bool collides = (proxy0.m_collisionFilterGroup & m_collisionFilterMask) != 0;
			collides = collides && ((m_collisionFilterGroup & proxy0.m_collisionFilterMask)!=0);
			return collides;
		}

		public abstract float AddSingleResult(LocalRayResult rayResult,bool normalInWorldSpace);
		public virtual void Cleanup()
		{
		}

		public float m_closestHitFraction;
		public CollisionObject m_collisionObject;
		public CollisionFilterGroups m_collisionFilterGroup;
		public CollisionFilterGroups m_collisionFilterMask;
		//@BP Mod - Custom flags, currently used to enable backface culling on tri-meshes, see btRaycastCallback
		public EFlags m_flags;
	}
}
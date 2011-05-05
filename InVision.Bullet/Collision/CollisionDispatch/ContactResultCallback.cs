using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.NarrowPhaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	///ContactResultCallback is used to report contact points
	public abstract class ContactResultCallback
	{
		public CollisionFilterGroups m_collisionFilterGroup;
		public CollisionFilterGroups m_collisionFilterMask;
		
		public ContactResultCallback()
		{
			m_collisionFilterGroup = CollisionFilterGroups.DefaultFilter;
			m_collisionFilterMask = CollisionFilterGroups.AllFilter;
		}
		
		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			bool collides = (proxy0.m_collisionFilterGroup & m_collisionFilterMask) != 0;
			collides = collides && ((m_collisionFilterGroup & proxy0.m_collisionFilterMask) != 0);
			return collides;
		}

		public abstract float AddSingleResult(ManifoldPoint cp,	CollisionObject colObj0,int partId0,int index0,CollisionObject colObj1,int partId1,int index1);
	}
}
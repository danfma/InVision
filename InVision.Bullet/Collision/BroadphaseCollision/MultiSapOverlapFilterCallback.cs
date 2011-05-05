namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class MultiSapOverlapFilterCallback : IOverlapFilterCallback
	{
		~MultiSapOverlapFilterCallback()
		{}
		// return true when pairs need collision
		public virtual bool NeedBroadphaseCollision(BroadphaseProxy childProxy0,BroadphaseProxy childProxy1)
		{
			BroadphaseProxy multiProxy0 = (BroadphaseProxy)childProxy0.m_multiSapParentProxy;
			BroadphaseProxy multiProxy1 = (BroadphaseProxy)childProxy1.m_multiSapParentProxy;
			
			bool collides = (multiProxy0.m_collisionFilterGroup & multiProxy1.m_collisionFilterMask) != 0;
			collides = collides && ((multiProxy1.m_collisionFilterGroup & multiProxy0.m_collisionFilterMask) != 0);
	
			return collides;
		}
	}
}
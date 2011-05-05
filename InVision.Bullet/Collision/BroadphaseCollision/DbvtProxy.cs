using System;
using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class DbvtProxy : BroadphaseProxy
	{
		/* Fields		*/ 
		//btDbvtAabbMm	aabb;
		public DbvtNode m_leaf;
		public DbvtNode leaf
		{
			get 
			{ 
				return m_leaf; 
			}
			set 
			{ 
				m_leaf = value;
				if (m_leaf.parent == null)
				{
					int ibreak = 0;
				}
			}
		}

		public DbvtProxy[] links = new DbvtProxy[2];
		public int	stage;
		/* ctor			*/
		public DbvtProxy(ref Vector3 aabbMin, ref Vector3 aabbMax, Object userPtr, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask) :
			base(ref aabbMin,ref aabbMax,userPtr,collisionFilterGroup,collisionFilterMask,null)
		{
			links[0]=links[1]=null;
		}
	}
}
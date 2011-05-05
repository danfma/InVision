using System;
using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class SimpleBroadphaseProxy : BroadphaseProxy
	{
		public SimpleBroadphaseProxy(int position)
		{
			m_position = position;
		}

		public SimpleBroadphaseProxy(int position,ref Vector3 minpt, ref Vector3 maxpt, BroadphaseNativeTypes shapeType, Object userPtr, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask, Object multiSapProxy)
			:   base(ref minpt,ref maxpt,userPtr,collisionFilterGroup,collisionFilterMask,multiSapProxy)
		{
			// bit of a cheat/hack - store the position in the array as we can't find it for freehandle otherwise.
			m_position = position;
		}

		public int GetNextFree()
		{
			return m_nextFree;
		}

		public int GetPosition()
		{
			return m_position;
		}

		public void SetNextFree(int nextFree)
		{
			m_nextFree = nextFree;
		}

		private int m_nextFree;
		private int m_position;
	}
}
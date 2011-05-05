using System;
using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class MultiSapProxy	: BroadphaseProxy
	{
		///array with all the entries that this proxy belongs to
		public IList<BridgeProxy> m_bridgeProxies;
		//public Vector3	m_aabbMin;
		//public Vector3	m_aabbMax;

		public BroadphaseNativeTypes m_shapeType;

/*		void*	m_userPtr;
		short int	m_collisionFilterGroup;
		short int	m_collisionFilterMask;
*/
		public MultiSapProxy(ref Vector3 aabbMin, ref Vector3 aabbMax, BroadphaseNativeTypes shapeType,
		                     Object userPtr, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask)
			: base(ref aabbMin, ref aabbMax, userPtr, collisionFilterGroup, collisionFilterMask, null)
		{
			m_aabbMin = aabbMin;
			m_aabbMax = aabbMax;
			m_shapeType = shapeType;
			m_multiSapParentProxy =this;
		}
	}
}
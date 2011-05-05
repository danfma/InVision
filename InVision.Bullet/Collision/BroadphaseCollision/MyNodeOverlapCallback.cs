namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class MyNodeOverlapCallback : INodeOverlapCallback
	{
		MultiSapBroadphase	m_multiSap;
		MultiSapProxy		m_multiProxy;
		IDispatcher			m_dispatcher;

		public MyNodeOverlapCallback(MultiSapBroadphase multiSap,MultiSapProxy multiProxy,IDispatcher dispatcher)
		{
			m_multiSap = multiSap;
			m_multiProxy = multiProxy;
			m_dispatcher = dispatcher;

		}

		public virtual void ProcessNode(int nodeSubPart, int broadphaseIndex)
		{
			IBroadphaseInterface childBroadphase = m_multiSap.GetBroadphaseArray()[broadphaseIndex];

			int containingBroadphaseIndex = -1;
			//already found?
			for (int i=0;i<m_multiProxy.m_bridgeProxies.Count;i++)
			{

				if (m_multiProxy.m_bridgeProxies[i].m_childBroadphase == childBroadphase)
				{
					containingBroadphaseIndex = i;
					break;
				}
			}
			if (containingBroadphaseIndex<0)
			{
				//add it
				BroadphaseProxy childProxy = childBroadphase.CreateProxy(ref m_multiProxy.m_aabbMin,ref m_multiProxy.m_aabbMax,m_multiProxy.m_shapeType,m_multiProxy.m_clientObject,m_multiProxy.m_collisionFilterGroup,m_multiProxy.m_collisionFilterMask, m_dispatcher,m_multiProxy);
				m_multiSap.AddToChildBroadphase(m_multiProxy,childProxy,childBroadphase);
			}
		}

		public virtual void Cleanup()
		{
		}
	}
}
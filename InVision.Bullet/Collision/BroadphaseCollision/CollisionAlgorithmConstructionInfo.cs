using InVision.Bullet.Collision.NarrowPhaseCollision;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class CollisionAlgorithmConstructionInfo
	{
		public CollisionAlgorithmConstructionInfo()
		{
			m_dispatcher1 = null;
			m_manifold = null;
		}

		public CollisionAlgorithmConstructionInfo(IDispatcher dispatcher, int temp)
		{
			m_dispatcher1 = dispatcher;
			//(void)temp;
		}

		public int GetDispatcherId()
		{
			return 0;
		}

		public void SetManifold(PersistentManifold manifold)
		{
			m_manifold = manifold;
		}

		public PersistentManifold GetManifold()
		{
			return m_manifold;
		}

		public IDispatcher GetDispatcher()
		{
			return m_dispatcher1;
		}

		public void SetDispatcher(IDispatcher dispatcher)
		{
			m_dispatcher1 = dispatcher;
		}

		private IDispatcher m_dispatcher1;
		private PersistentManifold m_manifold;


	};
}
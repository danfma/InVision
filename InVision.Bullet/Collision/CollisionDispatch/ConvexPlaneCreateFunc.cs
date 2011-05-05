using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class ConvexPlaneCreateFunc : CollisionAlgorithmCreateFunc
	{
		public int	m_numPerturbationIterations;
		public int m_minimumPointsPerturbationThreshold;
			
		public ConvexPlaneCreateFunc()
		{
			m_numPerturbationIterations = 1;
			m_minimumPointsPerturbationThreshold = 1;
		}
		
		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0,CollisionObject body1)
		{
			if (!m_swapped)
			{
				return new ConvexPlaneCollisionAlgorithm(null,ci,body0,body1,false,m_numPerturbationIterations,m_minimumPointsPerturbationThreshold);
			} 
			else
			{
				return new ConvexPlaneCollisionAlgorithm(null,ci,body0,body1,true,m_numPerturbationIterations,m_minimumPointsPerturbationThreshold);
			}
		}
	};
}
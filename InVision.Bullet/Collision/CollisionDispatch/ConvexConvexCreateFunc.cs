using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.NarrowPhaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class ConvexConvexCreateFunc : CollisionAlgorithmCreateFunc
	{
		public ConvexConvexCreateFunc(ISimplexSolverInterface simplexSolver,IConvexPenetrationDepthSolver depthSolver)
		{
			m_numPerturbationIterations = 0;
			m_minimumPointsPerturbationThreshold =3;
			m_simplexSolver = simplexSolver;
			m_pdSolver = depthSolver;
		}

		public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci, CollisionObject body0, CollisionObject body1)
		{
			return new ConvexConvexAlgorithm(ci.GetManifold(), ci, body0, body1, m_simplexSolver, m_pdSolver, m_numPerturbationIterations, m_minimumPointsPerturbationThreshold);
		}
    	
		public IConvexPenetrationDepthSolver m_pdSolver;
		public ISimplexSolverInterface m_simplexSolver;
		public int m_numPerturbationIterations;
		public int m_minimumPointsPerturbationThreshold;
	}
}
namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public class ContactSolverInfoData
	{
		public float m_tau;
		public float m_damping;
		public float m_friction;
		public float m_timeStep;
		public float m_restitution;
		public int m_numIterations;
		public float m_maxErrorReduction;
		public float m_sor;
		public float m_erp;//used as Baumgarte factor
		public float m_erp2;//used in Split Impulse
		public float m_globalCfm;//constraint force mixing
		public bool m_splitImpulse;
		public float m_splitImpulsePenetrationThreshold;
		public float m_linearSlop;
		public float m_warmstartingFactor;

		public SolverMode m_solverMode;
		public int m_restingContactRestitutionThreshold;
		public int m_minimumSolverBatchSize;

	}
}
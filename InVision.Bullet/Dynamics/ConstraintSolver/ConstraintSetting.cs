namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public class ConstraintSetting
	{
		public ConstraintSetting()
		{
			m_tau = 0.3f;
			m_damping = 1f;
			m_impulseClamp = 0f;
		}
		public float m_tau;
		public float m_damping;
		public float m_impulseClamp;
	}
}
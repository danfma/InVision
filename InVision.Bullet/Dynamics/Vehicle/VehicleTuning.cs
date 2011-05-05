namespace InVision.Bullet.Dynamics.Vehicle
{
	public class VehicleTuning
	{
		public VehicleTuning()
		{
			m_suspensionStiffness = 5.88f;
			m_suspensionCompression = 0.83f;
			m_suspensionDamping = 0.88f;
			m_maxSuspensionTravelCm = 500f;
			m_frictionSlip = 10.5f;
			m_maxSuspensionForce = 6000f;

		}
		public float m_suspensionStiffness;
		public float m_suspensionCompression;
		public float m_suspensionDamping;
		public float m_maxSuspensionTravelCm;
		public float m_frictionSlip;
		public float m_maxSuspensionForce;

	}
}
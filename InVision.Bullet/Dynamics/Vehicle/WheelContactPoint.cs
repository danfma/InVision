using InVision.Bullet.Dynamics.Dynamics;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Vehicle
{
	public class WheelContactPoint
	{
		public RigidBody m_body0;
		public RigidBody m_body1;
		public Vector3 m_frictionPositionWorld;
		public Vector3 m_frictionDirectionWorld;
		public float m_jacDiagABInv;
		public float m_maxImpulse;

		public WheelContactPoint(RigidBody body0,RigidBody body1,ref Vector3 frictionPosWorld,ref Vector3 frictionDirectionWorld, float maxImpulse)
		{
			m_body0 = body0;
			m_body1 = body1;
			m_frictionPositionWorld = frictionPosWorld;
			m_frictionDirectionWorld = frictionDirectionWorld;
			m_maxImpulse = maxImpulse;
			float denom0 = body0.ComputeImpulseDenominator(ref frictionPosWorld,ref frictionDirectionWorld);
			float denom1 = body1.ComputeImpulseDenominator(ref frictionPosWorld,ref frictionDirectionWorld);
			float relaxation = 1f;
			m_jacDiagABInv = relaxation/(denom0+denom1);
		}
	}
}
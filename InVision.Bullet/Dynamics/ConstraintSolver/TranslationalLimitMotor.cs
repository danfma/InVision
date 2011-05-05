using InVision.Bullet.Dynamics.Dynamics;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public class TranslationalLimitMotor
	{
		public Vector3 m_lowerLimit;//!< the constraint lower limits
		public Vector3 m_upperLimit;//!< the constraint upper limits
		public Vector3 m_accumulatedImpulse;
		public float m_limitSoftness;//!< Softness for linear limit
		public float m_damping;//!< Damping for linear limit
		public float m_restitution;//! Bounce parameter for linear limit
		public Vector3 m_normalCFM;//!< Constraint force mixing factor
		public Vector3 m_stopERP;//!< Error tolerance factor when joint is at limit
		public Vector3 m_stopCFM;//!< Constraint force mixing factor when joint is at limit
		public bool[] m_enableMotor = new bool[3];
		public Vector3 m_targetVelocity;//!< target motor velocity
		public Vector3 m_maxMotorForce;//!< max force on motor
		public Vector3 m_currentLimitError;//!  How much is violated this limit
		public Vector3 m_currentLinearDiff;//!  Current relative offset of constraint frames
		public int[] m_currentLimit = new int[3];//!< 0=free, 1=at lower limit, 2=at upper limit

		public TranslationalLimitMotor()
		{
			m_lowerLimit = Vector3.Zero;
			m_upperLimit = Vector3.Zero;
			m_accumulatedImpulse = Vector3.Zero;
			m_normalCFM = Vector3.Zero;
			m_stopERP = new Vector3(0.2f, 0.2f, 0.2f);
			m_stopCFM = Vector3.Zero;

			m_limitSoftness = 0.7f;
			m_damping = 1f;
			m_restitution = 0.5f;

			for(int i=0; i < 3; i++) 
			{
				m_enableMotor[i] = false;
			}
			m_targetVelocity = Vector3.Zero;
			m_maxMotorForce = Vector3.Zero;
		}

		public TranslationalLimitMotor(TranslationalLimitMotor other )
		{
			m_lowerLimit = other.m_lowerLimit;
			m_upperLimit = other.m_upperLimit;
			m_accumulatedImpulse = other.m_accumulatedImpulse;

			m_limitSoftness = other.m_limitSoftness ;
			m_damping = other.m_damping;
			m_restitution = other.m_restitution;
			m_normalCFM = other.m_normalCFM;
			m_stopERP = other.m_stopERP;
			m_stopCFM = other.m_stopCFM;

			for(int i=0; i < 3; i++) 
			{
				m_enableMotor[i] = other.m_enableMotor[i];
			}
			m_targetVelocity = other.m_targetVelocity;
			m_maxMotorForce = other.m_maxMotorForce;

		}

		//! Test limit
		/*!
        - free means upper < lower,
        - locked means upper == lower
        - limited means upper > lower
        - limitIndex: first 3 are linear, next 3 are angular
        */
		public bool	IsLimited(int limitIndex)
		{
			return MathUtil.VectorComponent(ref m_upperLimit,limitIndex) >= MathUtil.VectorComponent(ref m_lowerLimit,limitIndex);
		}
		public bool NeedApplyForce(int limitIndex)
		{
			if(m_currentLimit[limitIndex] == 0 && m_enableMotor[limitIndex] == false)
			{
				return false;
			}
			return true;
		}

		public int TestLimitValue(int limitIndex, float test_value)
		{
			float loLimit = MathUtil.VectorComponent(ref m_lowerLimit,limitIndex);
			float hiLimit = MathUtil.VectorComponent(ref m_upperLimit,limitIndex);
			if (loLimit > hiLimit)
			{
				m_currentLimit[limitIndex] = 0;//Free from violation
				MathUtil.VectorComponent(ref m_currentLimitError,limitIndex,0f);
				return 0;
			}

			if (test_value < loLimit)
			{
				m_currentLimit[limitIndex] = 2;//low limit violation
				MathUtil.VectorComponent(ref m_currentLimitError,limitIndex,test_value - loLimit);
				return 2;
			}
			else if (test_value > hiLimit)
			{
				m_currentLimit[limitIndex] = 1;//High limit violation
				MathUtil.VectorComponent(ref m_currentLimitError,limitIndex, test_value - hiLimit);
				return 1;
			};

			m_currentLimit[limitIndex] = 0;//Free from violation
			MathUtil.VectorComponent(ref m_currentLimitError,limitIndex,0f);
			return 0;
		}

		public float SolveLinearAxis(
			float timeStep,
			float jacDiagABInv,
			RigidBody body1, ref Vector3 pointInA,
			RigidBody body2, ref Vector3 pointInB,
			int limit_index,
			ref Vector3 axis_normal_on_a,
			ref Vector3 anchorPos)
		{
			///find relative velocity
			//    Vector3 rel_pos1 = pointInA - body1.getCenterOfMassPosition();
			//    Vector3 rel_pos2 = pointInB - body2.getCenterOfMassPosition();
			Vector3 rel_pos1 = anchorPos - body1.GetCenterOfMassPosition();
			Vector3 rel_pos2 = anchorPos - body2.GetCenterOfMassPosition();

			Vector3 vel1 = Vector3.Zero;
			body1.InternalGetVelocityInLocalPointObsolete(ref rel_pos1,ref vel1);
			Vector3 vel2 = Vector3.Zero;;
			body2.InternalGetVelocityInLocalPointObsolete(ref rel_pos2,ref vel2);
			Vector3 vel = vel1 - vel2;

			float rel_vel = Vector3.Dot(axis_normal_on_a,vel);

			/// apply displacement correction

			//positional error (zeroth order error)
			float depth = -Vector3.Dot((pointInA - pointInB),axis_normal_on_a);
			float	lo = float.MinValue;
			float	hi = float.MaxValue;

			float minLimit = MathUtil.VectorComponent(ref m_lowerLimit,limit_index);
			float maxLimit = MathUtil.VectorComponent(ref m_upperLimit,limit_index);

			//handle the limits
			if (minLimit < maxLimit)
			{
				{
					if (depth > maxLimit)
					{
						depth -= maxLimit;
						lo = 0f;

					}
					else
					{
						if (depth < minLimit)
						{
							depth -= minLimit;
							hi = 0f;
						}
						else
						{
							return 0.0f;
						}
					}
				}
			}

			float normalImpulse= m_limitSoftness*(m_restitution*depth/timeStep - m_damping*rel_vel) * jacDiagABInv;

			float oldNormalImpulse = MathUtil.VectorComponent(ref m_accumulatedImpulse,limit_index);
			float sum = oldNormalImpulse + normalImpulse;
			MathUtil.VectorComponent(ref m_accumulatedImpulse,limit_index,(sum > hi ? 0f: sum < lo ? 0f : sum));
			normalImpulse = MathUtil.VectorComponent(ref m_accumulatedImpulse,limit_index) - oldNormalImpulse;

			Vector3 impulse_vector = axis_normal_on_a * normalImpulse;
			//body1.applyImpulse( impulse_vector, rel_pos1);
			//body2.applyImpulse(-impulse_vector, rel_pos2);

			Vector3 ftorqueAxis1 = Vector3.Cross(rel_pos1,axis_normal_on_a);
			Vector3 ftorqueAxis2 = Vector3.Cross(rel_pos2,axis_normal_on_a);
			body1.InternalApplyImpulse(axis_normal_on_a*body1.GetInvMass(), Vector3.TransformNormal(ftorqueAxis1,body1.GetInvInertiaTensorWorld()),normalImpulse);
			body2.InternalApplyImpulse(axis_normal_on_a * body2.GetInvMass(), Vector3.TransformNormal(ftorqueAxis2,body2.GetInvInertiaTensorWorld()), -normalImpulse);

			return normalImpulse;

		}
	}
}
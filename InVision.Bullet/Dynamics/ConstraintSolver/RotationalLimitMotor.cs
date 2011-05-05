using InVision.Bullet.Dynamics.Dynamics;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public class RotationalLimitMotor
	{
		//! limit_parameters
		//!@{
		public float m_loLimit;//!< joint limit
		public float m_hiLimit;//!< joint limit
		public float m_targetVelocity;//!< target motor velocity
		public float m_maxMotorForce;//!< max force on motor
		public float m_maxLimitForce;//!< max force on limit
		public float m_damping;//!< Damping.
		public float m_limitSoftness;//! Relaxation factor
		public float m_normalCFM;//!< Constraint force mixing factor
		public float m_stopERP;//!< Error tolerance factor when joint is at limit
		public float m_stopCFM;//!< Constraint force mixing factor when joint is at limit
		public float m_bounce;//!< restitution factor
		public bool m_enableMotor;

		//!@}

		//! temp_variables
		//!@{
		public float m_currentLimitError;//!  How much is violated this limit
		public float m_currentPosition;     //!  current value of angle 
		public int m_currentLimit;//!< 0=free, 1=at lo limit, 2=at hi limit
		public float m_accumulatedImpulse;
		//!@}

		public RotationalLimitMotor()
		{
			m_accumulatedImpulse = 0f;
			m_targetVelocity = 0;
			m_maxMotorForce = 0.1f;
			m_maxLimitForce = 300.0f;
			m_loLimit = 1.0f;
			m_hiLimit = -1.0f;
			m_normalCFM = 0.0f;
			m_stopERP = 0.2f;
			m_stopCFM = 0.0f;
			m_bounce = 0.0f;
			m_damping = 1.0f;
			m_limitSoftness = 0.5f;
			m_currentLimit = 0;
			m_currentLimitError = 0;
			m_enableMotor = false;
		}

		public RotationalLimitMotor(RotationalLimitMotor  limot)
		{
			m_targetVelocity = limot.m_targetVelocity;
			m_maxMotorForce = limot.m_maxMotorForce;
			m_limitSoftness = limot.m_limitSoftness;
			m_loLimit = limot.m_loLimit;
			m_hiLimit = limot.m_hiLimit;
			m_normalCFM = limot.m_normalCFM;
			m_stopERP = limot.m_stopERP;
			m_stopCFM = limot.m_stopCFM;
			m_bounce = limot.m_bounce;
			m_currentLimit = limot.m_currentLimit;
			m_currentLimitError = limot.m_currentLimitError;
			m_enableMotor = limot.m_enableMotor;
		}



		//! Is limited
		public bool IsLimited()
		{
			if(m_loLimit > m_hiLimit) return false;
			return true;
		}

		//! Need apply correction
		public bool NeedApplyTorques()
		{
			if(m_currentLimit == 0 && m_enableMotor == false) return false;
			return true;
		}

		//! calculates  error
		/*!
	    calculates m_currentLimit and m_currentLimitError.
	    */
		public int TestLimitValue(float test_value)
		{
			if(m_loLimit>m_hiLimit)
			{
				m_currentLimit = 0;//Free from violation
				return 0;
			}

			if (test_value < m_loLimit)
			{
				m_currentLimit = 1;//low limit violation
				m_currentLimitError =  test_value - m_loLimit;
				return 1;
			}
			else if (test_value> m_hiLimit)
			{
				m_currentLimit = 2;//High limit violation
				m_currentLimitError = test_value - m_hiLimit;
				return 2;
			};

			m_currentLimit = 0;//Free from violation
			return 0;
		}

		//! apply the correction impulses for two bodies
		public float SolveAngularLimits(float timeStep,ref Vector3 axis, float jacDiagABInv,RigidBody body0, RigidBody body1)
		{
			if (NeedApplyTorques() == false)
			{
				return 0.0f;
			}

			float target_velocity = m_targetVelocity;
			float maxMotorForce = m_maxMotorForce;

			//current error correction
			if (m_currentLimit!=0)
			{
				target_velocity = -m_stopERP*m_currentLimitError/(timeStep);
				maxMotorForce = m_maxLimitForce;
			}

			maxMotorForce *= timeStep;

			// current velocity difference

			Vector3 angVelA = Vector3.Zero;
			body0.InternalGetAngularVelocity(ref angVelA);
			Vector3 angVelB = Vector3.Zero;
			body1.InternalGetAngularVelocity(ref angVelB);

			Vector3 vel_diff = angVelA-angVelB;

			float rel_vel = Vector3.Dot(axis,vel_diff);

			// correction velocity
			float motor_relvel = m_limitSoftness*(target_velocity  - m_damping*rel_vel);

			if ( motor_relvel < MathUtil.SIMD_EPSILON && motor_relvel > -MathUtil.SIMD_EPSILON  )
			{
				return 0.0f;//no need for applying force
			}


			// correction impulse
			float unclippedMotorImpulse = (1+m_bounce)*motor_relvel*jacDiagABInv;

			// clip correction impulse
			float clippedMotorImpulse;

			///@todo: should clip against accumulated impulse
			if (unclippedMotorImpulse>0.0f)
			{
				clippedMotorImpulse =  unclippedMotorImpulse > maxMotorForce? maxMotorForce: unclippedMotorImpulse;
			}
			else
			{
				clippedMotorImpulse =  unclippedMotorImpulse < -maxMotorForce ? -maxMotorForce: unclippedMotorImpulse;
			}


			// sort with accumulated impulses
			float	lo = float.MinValue;
			float	hi = float.MaxValue;

			float oldaccumImpulse = m_accumulatedImpulse;
			float sum = oldaccumImpulse + clippedMotorImpulse;
			m_accumulatedImpulse = sum > hi ? 0f : sum < lo ? 0f : sum;

			clippedMotorImpulse = m_accumulatedImpulse - oldaccumImpulse;

			Vector3 motorImp = clippedMotorImpulse * axis;

			//body0.applyTorqueImpulse(motorImp);
			//body1.applyTorqueImpulse(-motorImp);

			body0.InternalApplyImpulse(Vector3.Zero, Vector3.TransformNormal(axis,body0.GetInvInertiaTensorWorld()),clippedMotorImpulse);
			body1.InternalApplyImpulse(Vector3.Zero, Vector3.TransformNormal(axis,body1.GetInvInertiaTensorWorld()),-clippedMotorImpulse);

			return clippedMotorImpulse;
		}
	}
}
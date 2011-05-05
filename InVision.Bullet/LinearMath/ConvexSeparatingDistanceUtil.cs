using InVision.GameMath;

namespace InVision.Bullet.LinearMath
{
	///The btConvexSeparatingDistanceUtil can help speed up convex collision detection 
	///by conservatively updating a cached separating distance/vector instead of re-calculating the closest distance
	public class ConvexSeparatingDistanceUtil
	{
		private Quaternion m_ornA;
		private Quaternion m_ornB;
		private Vector3 m_posA;
		private Vector3 m_posB;

		private Vector3 m_separatingNormal;

		private float m_boundingRadiusA;
		private float m_boundingRadiusB;
		private float m_separatingDistance;

		public ConvexSeparatingDistanceUtil(float boundingRadiusA, float boundingRadiusB)
		{
			m_boundingRadiusA = boundingRadiusA;
			m_boundingRadiusB = boundingRadiusB;
			m_separatingDistance = 0f;
		}

		public float GetConservativeSeparatingDistance()
		{
			return m_separatingDistance;
		}

		public void UpdateSeparatingDistance(ref Matrix transA, ref Matrix transB)
		{
			Vector3 toPosA = transA.Translation;
			Vector3 toPosB = transB.Translation;
			Quaternion toOrnA = TransformUtil.GetRotation(ref transA);
			Quaternion toOrnB = TransformUtil.GetRotation(ref transB);

			if (m_separatingDistance > 0.0f)
			{
				Vector3 linVelA = Vector3.Zero;
				Vector3 angVelA = Vector3.Zero;
				Vector3 linVelB = Vector3.Zero;
				Vector3 angVelB = Vector3.Zero;

				TransformUtil.CalculateVelocityQuaternion(ref m_posA, ref toPosA, ref m_ornA, ref toOrnA, 1f, ref linVelA, ref angVelA);
				TransformUtil.CalculateVelocityQuaternion(ref m_posB, ref toPosB, ref m_ornB, ref toOrnB, 1f, ref linVelB, ref angVelB);
				float maxAngularProjectedVelocity = angVelA.Length() * m_boundingRadiusA + angVelB.Length() * m_boundingRadiusB;
				Vector3 relLinVel = (linVelB - linVelA);
				float relLinVelocLength = Vector3.Dot((linVelB - linVelA), m_separatingNormal);
				if (relLinVelocLength < 0f)
				{
					relLinVelocLength = 0f;
				}

				float projectedMotion = maxAngularProjectedVelocity + relLinVelocLength;
				m_separatingDistance -= projectedMotion;
			}

			m_posA = toPosA;
			m_posB = toPosB;
			m_ornA = toOrnA;
			m_ornB = toOrnB;
		}

		void InitSeparatingDistance(ref Vector3 separatingVector, float separatingDistance, ref Matrix transA, ref Matrix transB)
		{
			m_separatingNormal = separatingVector;
			m_separatingDistance = separatingDistance;
    		
			Vector3 toPosA = transA.Translation;
			Vector3 toPosB = transB.Translation;
			Quaternion toOrnA = TransformUtil.GetRotation(ref transA);
			Quaternion toOrnB = TransformUtil.GetRotation(ref transB);
			m_posA = toPosA;
			m_posB = toPosB;
			m_ornA = toOrnA;
			m_ornB = toOrnB;
		}
	}
}
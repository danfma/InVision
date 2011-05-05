using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class ClosestConvexResultCallback : ConvexResultCallback
	{
		public ClosestConvexResultCallback(Vector3 convexFromWorld, Vector3 convexToWorld)
			: this(ref convexFromWorld, ref convexToWorld)
		{
		}

		public ClosestConvexResultCallback(ref Vector3 convexFromWorld,ref Vector3 convexToWorld)
		{
			m_convexFromWorld = convexFromWorld;
			m_convexToWorld = convexToWorld;
			m_hitCollisionObject = null;
		}

		public override float AddSingleResult(LocalConvexResult convexResult,bool normalInWorldSpace)
		{
			//caller already does the filter on the m_closestHitFraction
			//btAssert(convexResult.m_hitFraction <= m_closestHitFraction);
						
			m_closestHitFraction = convexResult.m_hitFraction;
			m_hitCollisionObject = convexResult.m_hitCollisionObject;
			if (normalInWorldSpace)
			{
				m_hitNormalWorld = convexResult.m_hitNormalLocal;
			} else
			{
				///need to transform normal into worldspace
				m_hitNormalWorld = Vector3.TransformNormal(convexResult.m_hitNormalLocal,m_hitCollisionObject.GetWorldTransform());
			}
			m_hitPointWorld = convexResult.m_hitPointLocal;
			return convexResult.m_hitFraction;
		}

		public Vector3	m_convexFromWorld;//used to calculate hitPointWorld from hitFraction
		public Vector3 m_convexToWorld;

		public Vector3 m_hitNormalWorld;
		public Vector3 m_hitPointWorld;
		public CollisionObject m_hitCollisionObject;
	}
}
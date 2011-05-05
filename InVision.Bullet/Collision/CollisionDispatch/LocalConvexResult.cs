using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class LocalConvexResult
	{
		public LocalConvexResult(CollisionObject hitCollisionObject, 
		                         LocalShapeInfo	localShapeInfo,
		                         ref Vector3 hitNormalLocal,
		                         ref Vector3 hitPointLocal,
		                         float hitFraction
			)
		{
			m_hitCollisionObject = hitCollisionObject;
			m_localShapeInfo = localShapeInfo;
			m_hitNormalLocal = hitNormalLocal;
			m_hitPointLocal = hitPointLocal;
			m_hitFraction = hitFraction;
		}

		public CollisionObject	m_hitCollisionObject;
		public LocalShapeInfo m_localShapeInfo;
		public Vector3 m_hitNormalLocal;
		public Vector3 m_hitPointLocal;
		public float m_hitFraction;
	};
}
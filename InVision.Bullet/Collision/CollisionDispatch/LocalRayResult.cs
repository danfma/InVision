using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class LocalRayResult
	{
		public LocalRayResult(CollisionObject	collisionObject, 
		                      LocalShapeInfo	localShapeInfo,
		                      ref Vector3	hitNormalLocal,
		                      float hitFraction)
		{
			m_collisionObject = collisionObject;
			m_localShapeInfo = localShapeInfo;
			m_hitNormalLocal = hitNormalLocal;
			m_hitFraction = hitFraction;
		}

		public CollisionObject m_collisionObject;
		public LocalShapeInfo m_localShapeInfo;
		public Vector3 m_hitNormalLocal;
		public float m_hitFraction;

	};
}
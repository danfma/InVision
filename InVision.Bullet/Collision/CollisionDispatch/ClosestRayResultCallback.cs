using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class ClosestRayResultCallback : RayResultCallback
	{

		public ClosestRayResultCallback(Vector3 rayFromWorld, Vector3 rayToWorld)
		{
			m_rayFromWorld = rayFromWorld;
			m_rayToWorld = rayToWorld;
		}


		public ClosestRayResultCallback(ref Vector3 rayFromWorld, ref Vector3 rayToWorld)
		{
			m_rayFromWorld = rayFromWorld;
			m_rayToWorld = rayToWorld;
		}

		public Vector3	m_rayFromWorld;//used to calculate hitPointWorld from hitFraction
		public Vector3 m_rayToWorld;

		public Vector3 m_hitNormalWorld;
		public Vector3 m_hitPointWorld;
			
		public override float AddSingleResult(LocalRayResult rayResult,bool normalInWorldSpace)
		{
			//caller already does the filter on the m_closestHitFraction
			//btAssert(rayResult.m_hitFraction <= m_closestHitFraction);
			
			m_closestHitFraction = rayResult.m_hitFraction;
			m_collisionObject = rayResult.m_collisionObject;
			if (normalInWorldSpace)
			{
				m_hitNormalWorld = rayResult.m_hitNormalLocal;
			} 
			else
			{
				///need to transform normal into worldspace
				m_hitNormalWorld = Vector3.TransformNormal(rayResult.m_hitNormalLocal,m_collisionObject.GetWorldTransform());
			}
			m_hitPointWorld = MathUtil.Interpolate3(ref m_rayFromWorld,ref m_rayToWorld,rayResult.m_hitFraction);
			return rayResult.m_hitFraction;
		}

	}
}
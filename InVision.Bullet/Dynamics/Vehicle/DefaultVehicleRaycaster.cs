using System;
using InVision.Bullet.Collision.CollisionDispatch;
using InVision.Bullet.Dynamics.Dynamics;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Vehicle
{
	public class DefaultVehicleRaycaster : IVehicleRaycaster
	{
		private DynamicsWorld m_dynamicsWorld;

		private struct DataCopy
		{
			Vector3 m_from;
			Vector3 m_to;
			VehicleRaycasterResult m_result;

			public DataCopy(Vector3 from,Vector3 to,VehicleRaycasterResult result)
			{
				m_from = from;
				m_to = to;
				m_result = result;
			}
		}

		public DefaultVehicleRaycaster(DynamicsWorld world)
		{
			m_dynamicsWorld = world;
		}

		public virtual Object CastRay(ref Vector3 from,ref Vector3 to, ref VehicleRaycasterResult result)
		{
			//	RayResultCallback& resultCallback;
			ClosestRayResultCallback rayCallback = new ClosestRayResultCallback(ref from,ref to);

			m_dynamicsWorld.RayTest(ref from, ref to, rayCallback);

			if (rayCallback.HasHit())
			{

				RigidBody body = RigidBody.Upcast(rayCallback.m_collisionObject);
				if (body != null && body.HasContactResponse())
				{
					result.m_hitPointInWorld = rayCallback.m_hitPointWorld;
					result.m_hitNormalInWorld = rayCallback.m_hitNormalWorld;
					result.m_hitNormalInWorld.Normalize();
					result.m_distFraction = rayCallback.m_closestHitFraction;
					return body;
				}
			}
			else
			{
				int ibreak = 0;
				ClosestRayResultCallback rayCallback2 = new ClosestRayResultCallback(ref from, ref to);

				m_dynamicsWorld.RayTest(ref from, ref to, rayCallback2);

			}
			rayCallback.Cleanup();
			return null;
		}
	}
}
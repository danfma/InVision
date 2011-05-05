using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class SingleRayCallback : BroadphaseRayCallback
	{
		public SingleRayCallback(ref Vector3 rayFromWorld,ref Vector3 rayToWorld,CollisionWorld world,RayResultCallback resultCallback)
		{
			m_rayFromWorld = rayFromWorld;
			m_rayToWorld = rayToWorld;
			m_world = world;
			m_resultCallback = resultCallback;
			m_rayFromTrans = Matrix.Identity;
			m_rayFromTrans.Translation = m_rayFromWorld;
			m_rayToTrans = Matrix.Identity;
			m_rayToTrans.Translation = m_rayToWorld;

			Vector3 rayDir = (rayToWorld-rayFromWorld);

			rayDir.Normalize();
			///what about division by zero? -. just set rayDirection[i] to INF/1e30
			m_rayDirectionInverse.X = MathUtil.FuzzyZero(rayDir.X) ? float.MaxValue : 1f / rayDir.X;
			m_rayDirectionInverse.Y = MathUtil.FuzzyZero(rayDir.Y) ? float.MaxValue : 1f / rayDir.Y;
			m_rayDirectionInverse.Z = MathUtil.FuzzyZero(rayDir.Z) ? float.MaxValue : 1f / rayDir.Z;
			m_signs[0] = m_rayDirectionInverse.X < 0.0f;
			m_signs[1] = m_rayDirectionInverse.Y < 0.0f;
			m_signs[2] = m_rayDirectionInverse.Z < 0.0f;

			m_lambda_max = Vector3.Dot(rayDir,(m_rayToWorld-m_rayFromWorld));
		}

		public override bool Process(BroadphaseProxy proxy)
		{
			///terminate further ray tests, once the closestHitFraction reached zero
			if (MathUtil.FuzzyZero(m_resultCallback.m_closestHitFraction))
			{   
				return false;
			}
			CollisionObject	collisionObject = (CollisionObject)proxy.m_clientObject;

			//only perform raycast if filterMask matches
			if(m_resultCallback.NeedsCollision(collisionObject.GetBroadphaseHandle())) 
			{
				//RigidcollisionObject* collisionObject = ctrl.GetRigidcollisionObject();
				//Vector3 collisionObjectAabbMin,collisionObjectAabbMax;
				//#if 0
				//#ifdef RECALCULATE_AABB
				//            Vector3 collisionObjectAabbMin,collisionObjectAabbMax;
				//            collisionObject.getCollisionShape().getAabb(collisionObject.getWorldTransform(),collisionObjectAabbMin,collisionObjectAabbMax);
				//#else
				//getBroadphase().getAabb(collisionObject.getBroadphaseHandle(),collisionObjectAabbMin,collisionObjectAabbMax);
				Vector3 collisionObjectAabbMin = collisionObject.GetBroadphaseHandle().m_aabbMin;
				Vector3 collisionObjectAabbMax = collisionObject.GetBroadphaseHandle().m_aabbMax;
				//#endif
				//#endif
				//float hitLambda = m_resultCallback.m_closestHitFraction;
				//culling already done by broadphase
				//if (btRayAabb(m_rayFromWorld,m_rayToWorld,collisionObjectAabbMin,collisionObjectAabbMax,hitLambda,m_hitNormal))
				{
					Matrix trans = collisionObject.GetWorldTransform();
					m_world.RayTestSingle(ref m_rayFromTrans,ref m_rayToTrans,
					                      collisionObject,
					                      collisionObject.GetCollisionShape(),
					                      ref trans,
					                      m_resultCallback);
				}
			}
			return true;
		}
		Vector3	m_rayFromWorld;
		Vector3	m_rayToWorld;
		Matrix	m_rayFromTrans;
		Matrix	m_rayToTrans;
		Vector3	m_hitNormal;
		CollisionWorld	m_world;
		RayResultCallback m_resultCallback;

	}
}
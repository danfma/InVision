using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class SingleSweepCallback : BroadphaseRayCallback
	{

		Matrix	m_convexFromTrans;
		Matrix	m_convexToTrans;
		Vector3	m_hitNormal;
		CollisionWorld	m_world;
		ConvexResultCallback	m_resultCallback;
		float m_allowedCcdPenetration;
		ConvexShape m_castShape;


		public SingleSweepCallback(ConvexShape castShape, ref Matrix convexFromTrans,ref Matrix convexToTrans,CollisionWorld world,ConvexResultCallback resultCallback,float allowedPenetration)
		{
			m_convexFromTrans = convexFromTrans;
			m_convexToTrans = convexToTrans;
			m_world = world;
			m_resultCallback = resultCallback;
			m_allowedCcdPenetration = allowedPenetration;
			m_castShape = castShape;
			Vector3 unnormalizedRayDir = (m_convexToTrans.Translation-m_convexFromTrans.Translation);
			Vector3 rayDir = unnormalizedRayDir;
			rayDir.Normalize();
			///what about division by zero? -. just set rayDirection[i] to INF/1e30
			m_rayDirectionInverse.X = MathUtil.CompareFloat(rayDir.X ,0.0f) ? float.MaxValue : 1f / rayDir.X;
			m_rayDirectionInverse.Y = MathUtil.CompareFloat(rayDir.Y ,0.0f) ? float.MaxValue : 1f / rayDir.Y;
			m_rayDirectionInverse.Z = MathUtil.CompareFloat(rayDir.Z ,0.0f) ? float.MaxValue : 1f / rayDir.Z;

			m_signs[0] = m_rayDirectionInverse.X < 0.0;
			m_signs[1] = m_rayDirectionInverse.Y < 0.0;
			m_signs[2] = m_rayDirectionInverse.Z < 0.0;

			m_lambda_max = Vector3.Dot(rayDir,unnormalizedRayDir);

		}

		public override bool Process(BroadphaseProxy proxy)
		{
			///terminate further convex sweep tests, once the closestHitFraction reached zero
			if (MathUtil.FuzzyZero(m_resultCallback.m_closestHitFraction))
			{
				return false;
			}
			CollisionObject	collisionObject = (CollisionObject)proxy.m_clientObject;

			//only perform raycast if filterMask matches
			if(m_resultCallback.NeedsCollision(collisionObject.GetBroadphaseHandle())) 
			{
				//RigidcollisionObject* collisionObject = ctrl.GetRigidcollisionObject();
				Matrix temp = collisionObject.GetWorldTransform();
				CollisionWorld.ObjectQuerySingle(m_castShape, ref m_convexFromTrans,ref m_convexToTrans,
				                                 collisionObject,
				                                 collisionObject.GetCollisionShape(),
				                                 ref temp,
				                                 m_resultCallback,
				                                 m_allowedCcdPenetration);
			}
    		
			return true;
		}
	}
}
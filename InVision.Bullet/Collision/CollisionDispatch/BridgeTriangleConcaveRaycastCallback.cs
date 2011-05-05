using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class BridgeTriangleConcaveRaycastCallback : TriangleRaycastCallback
	{

		public BridgeTriangleConcaveRaycastCallback(ref Vector3 from, ref Vector3 to,
		                                            RayResultCallback resultCallback, CollisionObject collisionObject, ConcaveShape triangleMesh, ref Matrix colObjWorldTransform) :
		                                            	//@BP Mod
		                                            	base(ref from, ref to, resultCallback.m_flags)
		{
			m_resultCallback = resultCallback;
			m_collisionObject = collisionObject;
			m_triangleMesh = triangleMesh;
			m_colObjWorldTransform = colObjWorldTransform;
		}


		public override float ReportHit(ref Vector3 hitNormalLocal, float hitFraction, int partId, int triangleIndex)
		{
			LocalShapeInfo shapeInfo = new LocalShapeInfo();
			shapeInfo.m_shapePart = partId;
			shapeInfo.m_triangleIndex = triangleIndex;

			Vector3 hitNormalWorld = Vector3.TransformNormal(hitNormalLocal,m_colObjWorldTransform);

			LocalRayResult rayResult = new LocalRayResult
				(m_collisionObject,
				 shapeInfo,
				 ref hitNormalWorld,
				 hitFraction);

			bool normalInWorldSpace = true;
			return m_resultCallback.AddSingleResult(rayResult, normalInWorldSpace);
		}


		public Matrix m_colObjWorldTransform;
		RayResultCallback m_resultCallback;
		CollisionObject m_collisionObject;
		ConcaveShape m_triangleMesh;
	}
}
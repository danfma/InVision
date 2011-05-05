using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class BridgeTriangleRaycastCallback : TriangleRaycastCallback
	{
		public RayResultCallback m_resultCallback;
		public CollisionObject m_collisionObject;
		public TriangleMeshShape m_triangleMesh;
		public Matrix m_colObjWorldTransform;

		public BridgeTriangleRaycastCallback( ref Vector3 from,ref Vector3 to,
		                                      RayResultCallback resultCallback, CollisionObject collisionObject, TriangleMeshShape triangleMesh, ref Matrix colObjWorldTransform) :
		                                      	base(ref from,ref to, resultCallback.m_flags)
		{
			//@BP Mod
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

			Vector3 hitNormalWorld = Vector3.TransformNormal(hitNormalLocal, m_colObjWorldTransform);

			LocalRayResult rayResult = new LocalRayResult
				(m_collisionObject,
				 shapeInfo,
				 ref hitNormalWorld,
				 hitFraction);

			bool normalInWorldSpace = true;
			return m_resultCallback.AddSingleResult(rayResult,normalInWorldSpace);
		}

		public virtual void Cleanup()
		{
		}
	}
}
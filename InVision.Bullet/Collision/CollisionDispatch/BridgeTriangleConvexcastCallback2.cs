using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class BridgeTriangleConvexcastCallback2 : TriangleConvexcastCallback
	{

		public BridgeTriangleConvexcastCallback2(ConvexShape castShape, ref Matrix from, ref Matrix to,
		                                         ConvexResultCallback resultCallback, CollisionObject collisionObject, ConcaveShape triangleMesh, ref Matrix triangleToWorld) :
		                                         	base(castShape, ref from, ref to, ref triangleToWorld, triangleMesh.Margin)
		{
			m_resultCallback = resultCallback;
			m_collisionObject = collisionObject;
			m_triangleMesh = triangleMesh;
		}


		public override float ReportHit(ref Vector3 hitNormalLocal, ref Vector3 hitPointLocal, float hitFraction, int partId, int triangleIndex)
		{
			LocalShapeInfo shapeInfo = new LocalShapeInfo();
			shapeInfo.m_shapePart = partId;
			shapeInfo.m_triangleIndex = triangleIndex;
			if (hitFraction <= m_resultCallback.m_closestHitFraction)
			{
				LocalConvexResult convexResult = new LocalConvexResult
					(m_collisionObject,
					 shapeInfo,
					 ref hitNormalLocal,
					 ref hitPointLocal,
					 hitFraction);

				bool normalInWorldSpace = false;

				return m_resultCallback.AddSingleResult(convexResult, normalInWorldSpace);
			}
			return hitFraction;
		}
		ConvexResultCallback m_resultCallback;
		CollisionObject m_collisionObject;
		ConcaveShape m_triangleMesh;

	}
}
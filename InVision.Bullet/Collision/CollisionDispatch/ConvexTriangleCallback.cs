using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.Debuging;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class ConvexTriangleCallback : ITriangleCallback
	{
		private CollisionObject m_convexBody;
		private CollisionObject m_triBody;

		private Vector3	m_aabbMin;
		private Vector3	m_aabbMax ;

		private ManifoldResult m_resultOut;
		private IDispatcher	m_dispatcher;
		private DispatcherInfo m_dispatchInfoPtr;
		private float m_collisionMarginTriangle;
	
		public int	m_triangleCount;
	
		public PersistentManifold m_manifoldPtr;

		public ConvexTriangleCallback(IDispatcher dispatcher, CollisionObject body0, CollisionObject body1, bool isSwapped)
		{
			m_dispatcher = dispatcher;
			m_convexBody = isSwapped ? body1 : body0;
			m_triBody = isSwapped ? body0 : body1;
			m_manifoldPtr = m_dispatcher.GetNewManifold(m_convexBody, m_triBody);
			ClearCache();
		}

		public virtual void Cleanup()
		{
			ClearCache();
			m_dispatcher.ReleaseManifold(m_manifoldPtr);
		}


		public void SetTimeStepAndCounters(float collisionMarginTriangle, DispatcherInfo dispatchInfo, ManifoldResult resultOut)
		{
			m_dispatchInfoPtr = dispatchInfo;
			m_collisionMarginTriangle = collisionMarginTriangle;
			m_resultOut = resultOut;

			//recalc aabbs
			//Matrix convexInTriangleSpace = MathUtil.bulletMatrixMultiply(Matrix.Invert(m_triBody.getWorldTransform()) , m_convexBody.getWorldTransform());
			Matrix convexInTriangleSpace = MathUtil.InverseTimes(m_triBody.GetWorldTransform(), m_convexBody.GetWorldTransform());
			CollisionShape convexShape = m_convexBody.GetCollisionShape();
			convexShape.GetAabb(ref convexInTriangleSpace,ref m_aabbMin,ref m_aabbMax);
			float extraMargin = collisionMarginTriangle;
			Vector3 extra = new Vector3(extraMargin,extraMargin,extraMargin);

			m_aabbMax += extra;
			m_aabbMin -= extra;
		}

		public virtual void ProcessTriangle(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			//aabb filter is already applied!	
			CollisionAlgorithmConstructionInfo ci = new CollisionAlgorithmConstructionInfo();
			ci.SetDispatcher(m_dispatcher);

			CollisionObject ob = (CollisionObject)m_triBody;
        	
			///debug drawing of the overlapping triangles
			///

			if (m_dispatchInfoPtr != null && m_dispatchInfoPtr.getDebugDraw() != null&& ((m_dispatchInfoPtr.getDebugDraw().GetDebugMode() & DebugDrawModes.DBG_DrawWireframe) > 0))
			{
				Vector3 color = new Vector3(1,1,0);
				Matrix tr = ob.GetWorldTransform();
				Vector3[] transformedTriangles = new Vector3[3];
				for(int i=0;i<transformedTriangles.Length;++i)
				{
					transformedTriangles[i] = Vector3.Transform(triangle[i],tr);
				}
				m_dispatchInfoPtr.getDebugDraw().DrawLine(ref transformedTriangles[0], ref transformedTriangles[1], ref color);
				m_dispatchInfoPtr.getDebugDraw().DrawLine(ref transformedTriangles[1], ref transformedTriangles[2], ref color);
				m_dispatchInfoPtr.getDebugDraw().DrawLine(ref transformedTriangles[2], ref transformedTriangles[0], ref color);

			}

			if (m_convexBody.GetCollisionShape().IsConvex())
			{
				TriangleShape tm = new TriangleShape(triangle[0],triangle[1],triangle[2]);	
				tm.Margin = m_collisionMarginTriangle;
        		
				CollisionShape tmpShape = ob.GetCollisionShape();
				ob.InternalSetTemporaryCollisionShape(tm);
        		
				CollisionAlgorithm colAlgo = ci.GetDispatcher().FindAlgorithm(m_convexBody,m_triBody,m_manifoldPtr);
				///this should use the btDispatcher, so the actual registered algorithm is used
				//		btConvexConvexAlgorithm cvxcvxalgo(m_manifoldPtr,ci,m_convexBody,m_triBody);

				if (m_resultOut.GetBody0Internal() == m_triBody)
				{
					m_resultOut.SetShapeIdentifiersA(partId, triangleIndex);
				}
				else
				{
					m_resultOut.SetShapeIdentifiersB(partId, triangleIndex);
				}

				colAlgo.ProcessCollision(m_convexBody,m_triBody,m_dispatchInfoPtr, m_resultOut);
				colAlgo.Cleanup();
				ci.GetDispatcher().FreeCollisionAlgorithm(colAlgo);
				colAlgo = null;

				ob.InternalSetTemporaryCollisionShape( tmpShape);
			}
		}

		public void ClearCache()
		{
			m_dispatcher.ClearManifold(m_manifoldPtr);
		}

		public Vector3 GetAabbMin()
		{
			return m_aabbMin;
		}
		public Vector3 GetAabbMax()
		{
			return m_aabbMax;
		}

	}
}
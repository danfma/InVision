using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public abstract class TriangleConvexcastCallback : ITriangleCallback
	{
		public TriangleConvexcastCallback(ConvexShape convexShape, ref Matrix convexShapeFrom, ref Matrix convexShapeTo, ref Matrix triangleToWorld, float triangleCollisionMargin)
		{
			m_convexShape = convexShape;
			m_convexShapeFrom = convexShapeFrom;
			m_convexShapeTo = convexShapeTo;
			m_triangleToWorld = triangleToWorld;
			m_triangleCollisionMargin = triangleCollisionMargin;
		}

		public virtual void ProcessTriangle(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			TriangleShape triangleShape = new TriangleShape(triangle[0], triangle[1], triangle[2]);
			triangleShape.Margin = m_triangleCollisionMargin;

			VoronoiSimplexSolver simplexSolver = new VoronoiSimplexSolver();
			GjkEpaPenetrationDepthSolver gjkEpaPenetrationSolver = new GjkEpaPenetrationDepthSolver();

			//#define  USE_SUBSIMPLEX_CONVEX_CAST 1
			//if you reenable USE_SUBSIMPLEX_CONVEX_CAST see commented ref code below
#if USE_SUBSIMPLEX_CONVEX_CAST
	        SubsimplexConvexCast convexCaster = new SubsimplexConvexCast(m_convexShape, triangleShape, simplexSolver);
#else
			//btGjkConvexCast	convexCaster(m_convexShape,&triangleShape,&simplexSolver);
			ContinuousConvexCollision convexCaster = new ContinuousConvexCollision(m_convexShape,triangleShape,simplexSolver,gjkEpaPenetrationSolver);
#endif //#USE_SUBSIMPLEX_CONVEX_CAST
	
			CastResult castResult = new CastResult();
			castResult.m_fraction = 1f;
			if (convexCaster.CalcTimeOfImpact(ref m_convexShapeFrom,ref m_convexShapeTo,ref m_triangleToWorld, ref m_triangleToWorld, castResult))
			{
				//add hit
				if (castResult.m_normal.LengthSquared() > 0.0001f)
				{					
					if (castResult.m_fraction < m_hitFraction)
					{
						/* btContinuousConvexCast's normal is already in world space */
						/*
                        #ifdef USE_SUBSIMPLEX_CONVEX_CAST
				                        //rotate normal into worldspace
				                        castResult.m_normal = m_convexShapeFrom.getBasis() * castResult.m_normal;
                        #endif //USE_SUBSIMPLEX_CONVEX_CAST
                        */
						castResult.m_normal.Normalize();

						ReportHit (ref castResult.m_normal,ref castResult.m_hitPoint,castResult.m_fraction,partId,triangleIndex);
					}
				}
			}
		}

		public virtual void Cleanup()
		{
		}

		public abstract float ReportHit (ref Vector3 hitNormalLocal, ref Vector3 hitPointLocal, float hitFraction, int partId, int triangleIndex);
	    
		public ConvexShape m_convexShape;
		public Matrix m_convexShapeFrom;
		public Matrix m_convexShapeTo;
		public Matrix m_triangleToWorld;
		public float m_hitFraction;
		public float m_triangleCollisionMargin;
	}
}
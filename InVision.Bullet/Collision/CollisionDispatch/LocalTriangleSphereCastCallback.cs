using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class LocalTriangleSphereCastCallback : ITriangleCallback
	{
		public Matrix m_ccdSphereFromTrans;
		public Matrix m_ccdSphereToTrans;
		public Matrix m_meshTransform;

		public float m_ccdSphereRadius;
		public float m_hitFraction;
	

		public LocalTriangleSphereCastCallback(ref Matrix from,ref Matrix to,float ccdSphereRadius,float hitFraction)
		{
			m_ccdSphereFromTrans = from;
			m_ccdSphereToTrans = to;
			m_ccdSphereRadius = ccdSphereRadius;
			m_hitFraction = hitFraction;
		}

		public virtual void Cleanup()
		{
		}

		public void ProcessTriangle(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			//do a swept sphere for now
			Matrix ident = Matrix.Identity;
			CastResult castResult = new CastResult();
			castResult.m_fraction = m_hitFraction;
			SphereShape	pointShape = new SphereShape(m_ccdSphereRadius);
			TriangleShape triShape = new TriangleShape(triangle[0],triangle[1],triangle[2]);
			VoronoiSimplexSolver	simplexSolver = new VoronoiSimplexSolver();
			SubSimplexConvexCast convexCaster = new SubSimplexConvexCast(pointShape,triShape,simplexSolver);
			//GjkConvexCast	convexCaster(&pointShape,convexShape,&simplexSolver);
			//ContinuousConvexCollision convexCaster(&pointShape,convexShape,&simplexSolver,0);
			//local space?

			if (convexCaster.CalcTimeOfImpact(ref m_ccdSphereFromTrans,ref m_ccdSphereToTrans,
			                                  ref ident,ref ident,castResult))
			{
				if (m_hitFraction > castResult.m_fraction)
				{
					m_hitFraction = castResult.m_fraction;
				}
			}

		}

	};
}
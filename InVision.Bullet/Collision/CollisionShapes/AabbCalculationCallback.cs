using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class AabbCalculationCallback : IInternalTriangleIndexCallback
	{
		public Vector3 m_aabbMin;
		public Vector3 m_aabbMax;

		public AabbCalculationCallback()
		{
			m_aabbMin = MathUtil.MAX_VECTOR;
			m_aabbMax = MathUtil.MIN_VECTOR;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			Vector3 t1 = triangle[0];
			Vector3 t2 = triangle[1];
			Vector3 t3 = triangle[2];

			MathUtil.VectorMin(ref t1,ref m_aabbMin);
			MathUtil.VectorMax(ref t1,ref m_aabbMax);
			MathUtil.VectorMin(ref t2,ref m_aabbMin);
			MathUtil.VectorMax(ref t2,ref m_aabbMax);
			MathUtil.VectorMin(ref t3,ref m_aabbMin);
			MathUtil.VectorMax(ref t3,ref m_aabbMax);
		}

		public void Cleanup()
		{
		}
	};
}
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class SupportVertexCallback : ITriangleCallback
	{

		private Vector3 m_supportVertexLocal;
		public Matrix m_worldTrans;
		public float m_maxDot;
		public Vector3 m_supportVecLocal;

		public SupportVertexCallback(ref Vector3 supportVecWorld,ref Matrix trans)
		{
			m_supportVertexLocal = Vector3.Zero;
			m_worldTrans = trans;
			m_maxDot = -MathUtil.BT_LARGE_FLOAT;
			m_supportVecLocal = MathUtil.TransposeTransformNormal(supportVecWorld, m_worldTrans);
			//m_supportVecLocal = Vector3.TransformNormal(supportVecWorld, m_worldTrans);
		}

		public virtual void ProcessTriangle(ObjectArray<Vector3> triangle,int partId, int triangleIndex)
		{
			Vector3[] rawData = triangle.GetRawArray();
			for (int i=0;i<3;i++)
			{
				float dot;
				Vector3.Dot(ref m_supportVecLocal,ref rawData[i],out dot);
				if (dot > m_maxDot)
				{
					m_maxDot = dot;
					m_supportVertexLocal = triangle[i];
				}
			}
		}

		public Vector3 GetSupportVertexWorldSpace()
		{
			return Vector3.Transform(m_supportVertexLocal, m_worldTrans);
			//return MathUtil.transposeTransformNormal(m_supportVertexLocal, m_worldTrans);
		}

		public Vector3 GetSupportVertexLocal()
		{
			return m_supportVertexLocal;
		}

		public virtual void Cleanup()
		{
		}
	}
}
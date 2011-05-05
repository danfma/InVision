using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class LocalSupportVertexCallback: IInternalTriangleIndexCallback
	{
		public LocalSupportVertexCallback(ref Vector3 supportVecLocal)
		{
			m_supportVertexLocal = Vector3.Zero;
			m_supportVecLocal = supportVecLocal;
			m_maxDot = float.MinValue;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			for (int i=0;i<3;i++)
			{
				float dot = Vector3.Dot(m_supportVecLocal,triangle[i]);
				if (dot > m_maxDot)
				{
					m_maxDot = dot;
					m_supportVertexLocal = triangle[i];
				}
			}
		}
    	
		public Vector3 GetSupportVertexLocal()
		{
			return m_supportVertexLocal;
		}

		public void Cleanup()
		{
		}

		private Vector3 m_supportVertexLocal;
		public float m_maxDot;
		public Vector3 m_supportVecLocal;

	};
}
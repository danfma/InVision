using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class FilteredCallback : IInternalTriangleIndexCallback
	{
		public ITriangleCallback m_callback;
		public Vector3 m_aabbMin;
		public Vector3 m_aabbMax;

		public FilteredCallback(ITriangleCallback callback,ref Vector3 aabbMin,ref Vector3 aabbMax)
		{
			m_callback = callback;
			m_aabbMin = aabbMin;
			m_aabbMax = aabbMax;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle,int partId,int triangleIndex)
		{
			if (AabbUtil2.TestTriangleAgainstAabb2(triangle,ref m_aabbMin,ref m_aabbMax))
			{
				//check aabb in triangle-space, before doing this
				m_callback.ProcessTriangle(triangle,partId,triangleIndex);
			}
			
		}
		public virtual void Cleanup()
		{
		}

	}
}
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class StorageResult : IDiscreteCollisionDetectorInterfaceResult
	{
		public StorageResult() 
		{
			m_distance = float.MaxValue;
		}

		public virtual void AddContactPoint(Vector3 normalOnBInWorld, Vector3 pointInWorld, float depth)
		{
			AddContactPoint(ref normalOnBInWorld, ref pointInWorld, depth);
		}

		public virtual void AddContactPoint(ref Vector3 normalOnBInWorld,ref Vector3 pointInWorld,float depth)
		{
			if (depth < m_distance)
			{
				m_normalOnSurfaceB = normalOnBInWorld;
				m_closestPointInB = pointInWorld;
				m_distance = depth;
			}
		}

		public virtual void SetShapeIdentifiersA(int partId0, int index0)
		{
		}

		public virtual void SetShapeIdentifiersB(int partId1, int index1)
		{
		}

		Vector3	m_normalOnSurfaceB;
		Vector3	m_closestPointInB;
		float	m_distance; //negative means penetration !

	}
}
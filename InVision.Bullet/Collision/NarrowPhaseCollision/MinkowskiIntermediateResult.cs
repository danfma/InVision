using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class MinkowskiIntermediateResult : IDiscreteCollisionDetectorInterfaceResult
	{
		public MinkowskiIntermediateResult()
		{
			m_hasResult = false;
		}

		public virtual void SetShapeIdentifiersA(int partId0,int index0)
		{
		}

		public virtual void SetShapeIdentifiersB(int partId1, int index1)
		{
		}

		public void AddContactPoint(Vector3 normalOnBInWorld, Vector3 pointInWorld, float depth)
		{
			AddContactPoint(ref normalOnBInWorld, ref pointInWorld, depth);
		}

		public void AddContactPoint(ref Vector3 normalOnBInWorld,ref Vector3 pointInWorld,float depth)
		{
			m_normalOnBInWorld = normalOnBInWorld;
			m_pointInWorld = pointInWorld;
			m_depth = depth;
			m_hasResult = true;
		}
		
		public Vector3 m_normalOnBInWorld;
		public Vector3 m_pointInWorld;
		public float m_depth;
		public bool	m_hasResult;

	}
}
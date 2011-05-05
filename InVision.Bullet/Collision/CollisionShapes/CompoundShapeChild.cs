using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class CompoundShapeChild
	{
		public Matrix m_transform;
		public CollisionShape m_childShape;
		public BroadphaseNativeTypes m_childShapeType;
		public float m_childMargin;
		public DbvtNode m_treeNode;

		public override bool Equals(object obj)
		{
			CompoundShapeChild other = (CompoundShapeChild)obj;
			return (m_transform == other.m_transform &&
			        m_childShape == other.m_childShape &&
			        m_childShapeType == other.m_childShapeType &&
			        m_childMargin == other.m_childMargin);
		}

	}
}
using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	/// btOptimizedBvhNode contains both internal and leaf node information.
	/// Total node size is 44 bytes / node. You can use the compressed version of 16 bytes.
	public class OptimizedBvhNode
	{
		public OptimizedBvhNode()
		{

			int ibreak = 0;
		}
		//32 bytes
		public Vector3 m_aabbMinOrg;
		public Vector3 m_aabbMaxOrg;

		//4
		public int m_escapeIndex;

		//8
		//for child nodes
		public int m_subPart;
		public int m_triangleIndex;
		//int	m_padding[5];//bad, due to alignment
	}
}
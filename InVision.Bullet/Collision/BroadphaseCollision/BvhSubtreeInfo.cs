using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	///btBvhSubtreeInfo provides info to gather a subtree of limited size
	public class BvhSubtreeInfo
	{
		//12 bytes - hah yeah right...

		public UShortVector3 m_quantizedAabbMin;
		public UShortVector3 m_quantizedAabbMax;

		//4 bytes, points to the root of the subtree
		public int m_rootNodeIndex;
		//4 bytes
		public int m_subtreeSize;
		//int			m_padding[3];

		public void SetAabbFromQuantizeNode(QuantizedBvhNode quantizedNode)
		{
			m_quantizedAabbMin = quantizedNode.m_quantizedAabbMin;
			m_quantizedAabbMax = quantizedNode.m_quantizedAabbMax;
		}
	}
}
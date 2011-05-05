using System.Diagnostics;
using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	///btQuantizedBvhNode is a compressed aabb node, 16 bytes.
	///Node can be used for leafnode or internal node. Leafnodes can point to 32-bit triangle index (non-negative range).
	///

	public class QuantizedBvhNode
	{
		//12 bytes - hah yeah right...
		public UShortVector3 m_quantizedAabbMin;
		public UShortVector3 m_quantizedAabbMax;
        
		//4 bytes
		public int m_escapeIndexOrTriangleIndex;

		public bool IsLeafNode()
		{
			//skipindex is negative (internal node), triangleindex >=0 (leafnode)
			return (m_escapeIndexOrTriangleIndex >= 0);
		}
		public int GetEscapeIndex()
		{
			Debug.Assert(!IsLeafNode());
			return -m_escapeIndexOrTriangleIndex;
		}

		public int GetTriangleIndex()
		{
			// relax this as we're using it in a cheat on the recursive walker.
			//Debug.Assert(isLeafNode());
			// Get only the lower bits where the triangle index is stored
			int result = (m_escapeIndexOrTriangleIndex & ~((~0) << (31 - QuantizedBvh.MAX_NUM_PARTS_IN_BITS)));
			int result2 = (m_escapeIndexOrTriangleIndex &~((~0) << (31 - QuantizedBvh.MAX_NUM_PARTS_IN_BITS)));

			return result;
		}
		public int GetPartId()
		{
			Debug.Assert(IsLeafNode());
			// Get only the highest bits where the part index is stored
			return (m_escapeIndexOrTriangleIndex >> (31 - QuantizedBvh.MAX_NUM_PARTS_IN_BITS));
		}
	}
}
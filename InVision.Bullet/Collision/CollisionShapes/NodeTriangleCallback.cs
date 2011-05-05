using System.Collections.Generic;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class NodeTriangleCallback : IInternalTriangleIndexCallback
	{
		IList<OptimizedBvhNode> m_triangleNodes = null;
			
		//NodeArray&	m_triangleNodes;

		//NodeTriangleCallback& operator=(NodeTriangleCallback& other)
		//{
		//    m_triangleNodes = other.m_triangleNodes;
		//    return *this;
		//}

		public NodeTriangleCallback(ObjectArray<OptimizedBvhNode> triangleNodes)
		{
			m_triangleNodes = triangleNodes;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			Vector3 t1 = triangle[0];
			Vector3 t2 = triangle[1];
			Vector3 t3 = triangle[2];

			OptimizedBvhNode node = new OptimizedBvhNode();
			Vector3	aabbMin = MathUtil.MAX_VECTOR;
			Vector3 aabbMax = MathUtil.MIN_VECTOR;
			MathUtil.VectorMax(ref t1,ref aabbMax);
			MathUtil.VectorMin(ref t1,ref aabbMin);
			MathUtil.VectorMax(ref t2,ref aabbMax);
			MathUtil.VectorMin(ref t2,ref aabbMin);
			MathUtil.VectorMax(ref t3,ref aabbMax);
			MathUtil.VectorMin(ref t3,ref aabbMin);

			//with quantization?
			node.m_aabbMinOrg = aabbMin;
			node.m_aabbMaxOrg = aabbMax;

			node.m_escapeIndex = -1;
	
			//for child nodes
			node.m_subPart = partId;
			node.m_triangleIndex = triangleIndex;
			m_triangleNodes.Add(node);
		}

		public virtual void Cleanup()
		{
		}
	}
}
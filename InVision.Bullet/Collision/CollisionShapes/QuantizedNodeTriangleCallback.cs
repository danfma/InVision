using System.Collections.Generic;
using System.Diagnostics;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class QuantizedNodeTriangleCallback : IInternalTriangleIndexCallback
	{
		private IList<QuantizedBvhNode> m_triangleNodes;
		QuantizedBvh m_optimizedTree; // for quantization

		public QuantizedNodeTriangleCallback(ObjectArray<QuantizedBvhNode> triangleNodes, QuantizedBvh tree)
		{
			m_triangleNodes = triangleNodes;
			m_optimizedTree = tree;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			// The partId and triangle index must fit in the same (positive) integer
			Debug.Assert(partId < (1<<MAX_NUM_PARTS_IN_BITS));
			Debug.Assert(triangleIndex < (1 << (31 - MAX_NUM_PARTS_IN_BITS)));
			//negative indices are reserved for escapeIndex
			Debug.Assert(triangleIndex >= 0);

			QuantizedBvhNode node = new QuantizedBvhNode();
			Vector3	aabbMin,aabbMax;
			aabbMin = MathUtil.MAX_VECTOR;
			aabbMax = MathUtil.MIN_VECTOR;

			Vector3 t1 = triangle[0];
			Vector3 t2 = triangle[1];
			Vector3 t3 = triangle[2];

			MathUtil.VectorMin(ref t1, ref aabbMin);
			MathUtil.VectorMax(ref t1, ref aabbMax);
			MathUtil.VectorMin(ref t2, ref aabbMin);
			MathUtil.VectorMax(ref t2, ref aabbMax);
			MathUtil.VectorMin(ref t3, ref aabbMin);
			MathUtil.VectorMax(ref t3, ref aabbMax);
		
			//PCK: add these checks for zero dimensions of aabb
			float MIN_AABB_DIMENSION = 0.002f;
			float MIN_AABB_HALF_DIMENSION = 0.001f;
			if (aabbMax.X - aabbMin.X < MIN_AABB_DIMENSION)
			{
				aabbMax.X = (aabbMax.X + MIN_AABB_HALF_DIMENSION);
				aabbMin.X = (aabbMin.X - MIN_AABB_HALF_DIMENSION);
			}
			if (aabbMax.Y - aabbMin.Y < MIN_AABB_DIMENSION)
			{
				aabbMax.Y = (aabbMax.Y + MIN_AABB_HALF_DIMENSION);
				aabbMin.Y = (aabbMin.Y - MIN_AABB_HALF_DIMENSION);
			}
			if (aabbMax.Z - aabbMin.Z < MIN_AABB_DIMENSION)
			{
				aabbMax.Z = (aabbMax.Z + MIN_AABB_HALF_DIMENSION);
				aabbMin.Z = (aabbMin.Z - MIN_AABB_HALF_DIMENSION);
			}

			m_optimizedTree.Quantize(ref node.m_quantizedAabbMin,ref aabbMin,false);
			m_optimizedTree.Quantize(ref node.m_quantizedAabbMax,ref aabbMax,true);

			node.m_escapeIndexOrTriangleIndex = (partId<<(31-MAX_NUM_PARTS_IN_BITS)) | triangleIndex;

			m_triangleNodes.Add(node);
		}

		public virtual void Cleanup()
		{
		}

		public const int MAX_NUM_PARTS_IN_BITS = 10;

	}
}
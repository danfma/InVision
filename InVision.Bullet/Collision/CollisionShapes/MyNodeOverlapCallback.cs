using System;
using System.Diagnostics;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class MyNodeOverlapCallback : INodeOverlapCallback
	{
		public StridingMeshInterface m_meshInterface;
		public ITriangleCallback m_callback;
		ObjectArray<Vector3> m_triangle = new ObjectArray<Vector3>(3);

		public MyNodeOverlapCallback(ITriangleCallback callback, StridingMeshInterface meshInterface)
		{
			m_meshInterface = meshInterface;
			m_callback = callback;
			// populate with basic data.
			m_triangle.Add(Vector3.One);
			m_triangle.Add(Vector3.One);
			m_triangle.Add(Vector3.One);

		}

		public virtual void ProcessNode(int nodeSubPart, int nodeTriangleIndex)
		{
			//m_triangle.Clear();            
			Object vertexBase;
			int numVerts;
			PHY_ScalarType type;
			int stride;
			Object indexBase;
			int indexStride;
			int numfaces;
			PHY_ScalarType indicesType;

			m_meshInterface.getLockedReadOnlyVertexIndexBase(
				out vertexBase,
				out numVerts,
				out type,
				out stride,
				out indexBase,
				out indexStride,
				out numfaces,
				out indicesType,
				nodeSubPart);

			//unsigned int* gfxbase = (unsigned int*)(indexbase+nodeTriangleIndex*indexstride);
			int indexIndex = nodeTriangleIndex*indexStride;
            
			Debug.Assert(indicesType==PHY_ScalarType.PHY_INTEGER||indicesType==PHY_ScalarType.PHY_SHORT);
	
            

			Vector3 meshScaling = m_meshInterface.GetScaling();
			Vector3[] vertexBaseRaw = ((ObjectArray<Vector3>)vertexBase).GetRawArray();
			Vector3[] localRaw = m_triangle.GetRawArray();
			int[] indexRaw = ((ObjectArray<int>)indexBase).GetRawArray();
			for (int j=2;j>=0;j--)
			{
				int graphicsIndex = indexRaw[indexIndex+j];
				
				if (type == PHY_ScalarType.PHY_FLOAT)
				{
					int floatIndex = graphicsIndex * stride;
					if (vertexBase is ObjectArray<Vector3>)
					{
						localRaw[j] = vertexBaseRaw[floatIndex];
						Vector3.Multiply(ref localRaw[j],ref meshScaling,out localRaw[j]);
					}
					else if(vertexBase is ObjectArray<float>)
					{
						ObjectArray<float> floats = (ObjectArray<float>)vertexBase;
						m_triangle[j] = new Vector3(floats[floatIndex] * meshScaling.X, floats[floatIndex + 1] * meshScaling.Y, floats[floatIndex + 2] * meshScaling.Z);		
					}
					else
					{
						Debug.Assert(false,"Unsupported type.");
					}
				}
			}


			//FIXME - Debug here and on quantized Bvh walking
			if (BulletGlobals.g_streamWriter != null && BvhTriangleMeshShape.debugBVHTriangleMesh)
			{
				BulletGlobals.g_streamWriter.WriteLine("BVH Triangle");
				MathUtil.PrintVector3(BulletGlobals.g_streamWriter, m_triangle[0]);
				MathUtil.PrintVector3(BulletGlobals.g_streamWriter, m_triangle[1]);
				MathUtil.PrintVector3(BulletGlobals.g_streamWriter, m_triangle[2]);
			}
			/* Perform ray vs. triangle collision here */
			m_callback.ProcessTriangle(m_triangle,nodeSubPart,nodeTriangleIndex);
			m_meshInterface.UnLockReadOnlyVertexBase(nodeSubPart);
		}

		public virtual void Cleanup()
		{
		}
	}
}
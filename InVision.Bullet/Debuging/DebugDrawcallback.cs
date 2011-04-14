using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Debuging
{
	public class DebugDrawcallback : ITriangleCallback, IInternalTriangleIndexCallback
	{
		private readonly IDebugDraw m_debugDrawer;
		private readonly Matrix m_worldTrans;
		private Vector3 m_color;

		public DebugDrawcallback(IDebugDraw debugDrawer, ref Matrix worldTrans, ref Vector3 color)
		{
			m_debugDrawer = debugDrawer;
			m_color = color;
			m_worldTrans = worldTrans;
		}

		#region IInternalTriangleIndexCallback Members

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			ProcessTriangle(triangle, partId, triangleIndex);
		}

		#endregion

		#region ITriangleCallback Members

		public virtual void ProcessTriangle(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			//(void)partId;
			//(void)triangleIndex;

			Vector3 wv0, wv1, wv2;
			wv0 = Vector3.Transform(triangle[0], m_worldTrans);
			wv1 = Vector3.Transform(triangle[1], m_worldTrans);
			wv2 = Vector3.Transform(triangle[2], m_worldTrans);

			m_debugDrawer.DrawLine(ref wv0, ref wv1, ref m_color);
			m_debugDrawer.DrawLine(ref wv1, ref wv2, ref m_color);
			m_debugDrawer.DrawLine(ref wv2, ref wv0, ref m_color);
		}

		//public static void drawUnitSphere(GraphicsDevice gd)
		//{
		//    gd.VertexDeclaration = s_vertexDeclaration;
		//    int primCount = s_sphereIndices.Length / 3;
		//    //int primCount = 2;
		//    int indexStart = 0;
		//    gd.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, s_sphereVertices, 0, s_sphereVertices.Length, s_sphereIndices, indexStart, primCount);
		//}
		public virtual void Cleanup()
		{
		}

		#endregion
	}
}
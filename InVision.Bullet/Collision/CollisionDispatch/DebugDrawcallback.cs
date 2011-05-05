using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Debuging;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class DebugDrawcallback : ITriangleCallback, IInternalTriangleIndexCallback
	{
		public IDebugDraw	m_debugDrawer;
		public Vector3	m_color;
		public Matrix m_worldTrans;

		public static bool debugCollisionWorld = true;

		public DebugDrawcallback(IDebugDraw	debugDrawer,ref Matrix worldTrans,ref Vector3 color)
		{
			m_debugDrawer = debugDrawer;
			m_color = color;
			m_worldTrans = worldTrans;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			ProcessTriangle(triangle,partId,triangleIndex);
		}

		public virtual void ProcessTriangle(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			//(voidpartId;
			//(void)triangleIndex;

			Vector3 wv0 = Vector3.Transform(triangle[0],m_worldTrans);
			Vector3 wv1 = Vector3.Transform(triangle[1],m_worldTrans);
			Vector3 wv2 = Vector3.Transform(triangle[2],m_worldTrans);
			Vector3 center = (wv0+wv1+wv2)*(1f/3f);

			Vector3 normal = Vector3.Cross((wv1-wv0),(wv2-wv0));
			normal.Normalize();
			Vector3 normalColor = new Vector3(1,1,0);
			m_debugDrawer.DrawLine(center,center+normal,normalColor);

			m_debugDrawer.DrawLine(ref wv0,ref wv1,ref m_color);
			m_debugDrawer.DrawLine(ref wv1,ref wv2,ref m_color);
			m_debugDrawer.DrawLine(ref wv2,ref wv0,ref m_color);
		}
		public void Cleanup()
		{
		}
	}
}
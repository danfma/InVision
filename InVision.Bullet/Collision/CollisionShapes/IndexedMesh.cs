using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class IndexedMesh
	{
		public int m_numTriangles;
		public ObjectArray<int> m_triangleIndexBase = new ObjectArray<int>();
		public int m_triangleIndexStride;
		public int m_numVertices;
		public ObjectArray<Vector3> m_vertexBase = new ObjectArray<Vector3>();
		public int m_vertexStride;
		//// The index type is set when adding an indexed mesh to the
		//// btTriangleIndexVertexArray, do not set it manually
		public PHY_ScalarType	m_indexType = PHY_ScalarType.PHY_INTEGER;
	}
}
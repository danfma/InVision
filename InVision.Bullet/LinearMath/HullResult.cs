using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Bullet.LinearMath
{
	public class HullResult
	{
		public HullResult()
		{
			mPolygons = true;
			mNumOutputVertices = 0;
			mNumFaces = 0;
			mNumIndices = 0;
		}
		public bool                    mPolygons;                  // true if indices represents polygons, false indices are triangles
		public int            mNumOutputVertices;         // number of vertices in the output hull
		public IList<Vector3>	m_OutputVertices = new List<Vector3>();            // array of vertices
		public int            mNumFaces;                  // the number of faces produced
		public int            mNumIndices;                // the total number of indices
		public IList<int>    m_Indices = new List<int>();                   // pointer to indices.

// If triangles, then indices are array indexes into the vertex list.
// If polygons, indices are in the form (number of points in face) (p1, p2, p3, ..) etc..
	}
}
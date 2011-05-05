using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Bullet.LinearMath
{
	public class ConvexH 
	{
		public class HalfEdge
		{
			public short ea;         // the other half of the edge (index into edges list)
			public byte v;  // the vertex at the start of this edge (index into vertices list)
			public byte p;  // the facet on which this edge lies (index into facets list)
			public HalfEdge(){}
			HalfEdge(short _ea,byte _v, byte _p)
			{
				ea = _ea;
				v = _v;
				p = _p;
			}
		}
		ConvexH()
		{
		}
		public IList<Vector3> vertices = new ObjectArray<Vector3>();
		public IList<HalfEdge> edges = new ObjectArray<HalfEdge>();
		public IList<Plane> facets = new ObjectArray<Plane>();
	
		public ConvexH(int vertices_size,int edges_size,int facets_size)
		{
			//vertices.Capacity = vertices_size;
			//edges.Capacity = edges_size;
			//facets.Capacity = facets_size;
		}
	}
}
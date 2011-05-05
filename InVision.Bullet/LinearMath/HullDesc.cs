using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Bullet.LinearMath
{
	public class HullDesc
	{
		public HullDesc()
		{
			mFlags          = HullFlag.QF_DEFAULT;
			mVcount         = 0;
			//mVertices       = 0;
			//mVertexStride   = sizeof(btVector3);
			mNormalEpsilon  = 0.001f;
			mMaxVertices	= 4096; // maximum number of points to be considered for a convex hull.
			mMaxFaces	= 4096;
		}

		public HullDesc(HullFlag flag,
		                int vcount,
		                IList<Vector3> vertices)
		{
			mFlags          = flag;
			mVcount         = vcount;
			mVertices       = vertices;
			//mVertexStride   = stride;
			mNormalEpsilon  = 0.001f;
			mMaxVertices    = 4096;
		}

		public bool HasHullFlag(HullFlag flag)
		{
			return ( (mFlags & flag) != 0 );
		}

		void SetHullFlag(HullFlag flag)
		{
			mFlags|=flag;
		}

		void ClearHullFlag(HullFlag flag)
		{
			mFlags&=~flag;
		}

		public HullFlag mFlags;           // flags to use when generating the convex hull.
		public int mVcount;          // number of vertices in the input point cloud
		public IList<Vector3> mVertices = new List<Vector3>();        // the array of vertices.
		public int mVertexStride;    // the stride of each vertex, in bytes.
		public float mNormalEpsilon;   // the epsilon for removing duplicates.  This is a normalized value, if normalized bit is on.
		public int mMaxVertices;     // maximum number of vertices to be considered for the hull!
		public int mMaxFaces;
	}
}
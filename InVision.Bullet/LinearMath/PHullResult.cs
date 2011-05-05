using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Bullet.LinearMath
{
	public class PHullResult
	{
		public PHullResult()
		{
			mVcount = 0;
			mIndexCount = 0;
			mFaceCount = 0;
		}

		public int mVcount;
		public int mIndexCount;
		public int mFaceCount;
		public IList<Vector3> mVertices = new List<Vector3>();
		public IList<int> m_Indices = new List<int>();
	}
}
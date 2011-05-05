using System;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class Element : IComparable<Element>
	{
		public int m_id;
		public int m_sz;

		public int CompareTo(Element obj)
		{
			// Original 
			//bool operator() ( const btElement& lhs, const btElement& rhs )
			//{
			//    return lhs.m_id < rhs.m_id;
			//}
			return m_id - obj.m_id;
		}
	}
}
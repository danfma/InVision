using System;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class BroadphasePair : IComparable
	{
		public BroadphasePair ()
		{
			m_pProxy0 = null;
			m_pProxy1 = null;
			m_algorithm = null;
			m_internalInfo1 = null;
		}

		public BroadphasePair(ref BroadphasePair other)
		{
			m_pProxy0 = other.m_pProxy0;
			m_pProxy1 = other.m_pProxy1;
			m_algorithm = other.m_algorithm;
			m_internalInfo1 = other.m_internalInfo1;
		}
	
		public BroadphasePair(BroadphaseProxy proxy0,BroadphaseProxy proxy1)
		{
			//keep them sorted, so the std::set operations work
			if (proxy0.GetUid() < proxy1.GetUid())
			{ 
				m_pProxy0 = proxy0; 
				m_pProxy1 = proxy1; 
			}
			else 
			{ 
				m_pProxy0 = proxy1; 
				m_pProxy1 = proxy0; 
			}

			m_algorithm = null;
			m_internalInfo1 = null;
		}
	

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			else
			{
				if (obj is BroadphasePair)
				{
					BroadphasePair that = (BroadphasePair)obj;
					return ReferenceEquals(this.m_pProxy0, that.m_pProxy0) && ReferenceEquals(this.m_pProxy1, that.m_pProxy1);
				}
			}
			return false;
		}

		public static bool IsLessThen(BroadphasePair a,BroadphasePair b)
		{
			int uidA0 = a.m_pProxy0 != null ? a.m_pProxy0.GetUid() : -1;
			int uidB0 = b.m_pProxy0 != null ? b.m_pProxy0.GetUid() : -1;
			int uidA1 = a.m_pProxy1 != null ? a.m_pProxy1.GetUid() : -1;
			int uidB1 = b.m_pProxy1 != null ? b.m_pProxy1.GetUid() : -1;

			//return uidA0 > uidB0 || 
			//   (a.m_pProxy0 == b.m_pProxy0 && uidA1 > uidB1) ||
			//   (a.m_pProxy0 == b.m_pProxy0 && a.m_pProxy1 == b.m_pProxy1 && a.m_algorithm > b.m_algorithm); 
			return uidA0 > uidB0 ||
			       (a.m_pProxy0 == b.m_pProxy0 && uidA1 > uidB1) ||
			       (a.m_pProxy0 == b.m_pProxy0 && a.m_pProxy1 == b.m_pProxy1); 
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			return (IsLessThen(this, (BroadphasePair)obj) ? -1 : 1);
		}

		#endregion



		public BroadphaseProxy m_pProxy0;
		public BroadphaseProxy m_pProxy1;
    	
		public CollisionAlgorithm m_algorithm;
		//don't use this data, it will be removed in future version.
		public Object m_internalInfo1;
		public int m_internalTmpValue;
	}
}